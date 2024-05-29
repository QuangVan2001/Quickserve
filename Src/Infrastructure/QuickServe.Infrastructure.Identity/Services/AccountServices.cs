using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuickServe.Application.DTOs.Account.Requests;
using QuickServe.Application.DTOs.Account.Responses;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.UserInterfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Dtos;
using QuickServe.Infrastructure.Identity.Models;
using QuickServe.Utils.Enums;
using QuickServe.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Error = QuickServe.Application.Wrappers.Error;

namespace QuickServe.Infrastructure.Identity.Services
{
    public class AccountServices(UserManager<ApplicationUser> userManager, IAuthenticatedUserService authenticatedUser, SignInManager<ApplicationUser> signInManager, ITranslator translator, IConfiguration configuration) : IAccountServices
    {
        public async Task<BaseResult> ChangePassword(ChangePasswordRequest model)
        {
            var user = await userManager.FindByIdAsync(authenticatedUser.UserId);

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var identityResult = await userManager.ResetPasswordAsync(user, token, model.Password);

            if (identityResult.Succeeded)
                return new BaseResult();

            return new BaseResult(identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)));
        }

        public async Task<BaseResult> ChangeUserName(ChangeUserNameRequest model)
        {
            var user = await userManager.FindByIdAsync(authenticatedUser.UserId);

            user.UserName = model.UserName;

            var identityResult = await userManager.UpdateAsync(user);

            if (identityResult.Succeeded)
                return new BaseResult();

            return new BaseResult(identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)));
        }

        public async Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return new BaseResult<AuthenticationResponse>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.AccountMessages.Account_notfound_with_UserName(login.Email)), nameof(login.Email)));
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName, login.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return new BaseResult<AuthenticationResponse>(new Error(ErrorCode.FieldDataInvalid, translator.GetString(TranslatorMessages.AccountMessages.Invalid_password()), nameof(login.Password)));
            }

            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);

            var token = await CreateToken(user, true);

            AuthenticationResponse response = new AuthenticationResponse()
            {
                Id = user.Id.ToString(),
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
                Email = user.Email,
                UserName = user.UserName,
                Roles = rolesList.ToList(),
                IsVerified = user.EmailConfirmed,
            };

            return new BaseResult<AuthenticationResponse>(response);
        }

        public async Task<BaseResult<AuthenticationResponse>> AuthenticateByUserName(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new BaseResult<AuthenticationResponse>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.AccountMessages.Account_notfound_with_UserName(username)), nameof(username)));
            }

            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);

            var token = await CreateToken(user, true); 

            AuthenticationResponse response = new AuthenticationResponse()
            {
                Id = user.Id.ToString(),
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
                Email = user.Email,
                UserName = user.UserName,
                Roles = rolesList.ToList(),
                IsVerified = user.EmailConfirmed,
            };

            return new BaseResult<AuthenticationResponse>(response);
        }

        public async Task<BaseResult<string>> RegisterGostAccount()
        {
            var user = new ApplicationUser()
            {
                UserName = GenerateRandomString(7)
            };

            var identityResult = await userManager.CreateAsync(user);

            if (identityResult.Succeeded)
                return new BaseResult<string>(user.UserName);

            return new BaseResult<string>(identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)));

            string GenerateRandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                var result = new StringBuilder(length);

                for (int i = 0; i < length; i++)
                {
                    int index = random.Next(chars.Length);
                    result.Append(chars[index]);
                }

                return result.ToString();
            }
        }

        public async Task<TokenDto> CreateToken(ApplicationUser user, bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            if (populateExp)
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"])), SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var result = await signInManager.ClaimsFactory.CreateAsync(user);
            return result.Claims.ToList();
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: configuration["JWTSettings:Issuer"],
                audience: configuration["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["JWTSettings:DurationInMinutes"])),
                signingCredentials: signingCredentials
           );
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(random);
            return Convert.ToBase64String(random);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"])),
                ValidateLifetime = true,
                ValidIssuer = configuration["JWTSettings:Issuer"],
                ValidAudience = configuration["JWTSettings:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public async Task<BaseResult<TokenDto>> RefreshToken(TokenDto token)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(token.AccessToken);

                var user = await userManager.FindByNameAsync(principal.Identity.Name);
                if (user == null || user.RefreshToken != token.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                    throw new SecurityTokenException("Invalid token");
                var newToken = await CreateToken(user, false);
                return new BaseResult<TokenDto>(newToken);
            } catch (Exception ex)
            {
                return new BaseResult<TokenDto>(new Error(ErrorCode.ErrorInIdentity, ex.Message));
            }

        }

        public async Task<BaseResult> CreateAccount(CreateAccountRequest request)
        {
            // Assgin role to exist account
            var existUser = await userManager.FindByEmailAsync(request.Email);
            if (existUser != null)
            {
                var roleExist = await userManager.GetRolesAsync(existUser);
                if (roleExist.Any(p => p == request.Role))
                    return new BaseResult(new Error(ErrorCode.Duplicate, translator.GetString(TranslatorMessages.AccountMessages.Account_already_exist_with_Email(request.Email)), nameof(request.Email)));

                var assignRoleResult = await userManager.AddToRoleAsync(existUser, request.Role);
                if (assignRoleResult.Succeeded)
                    return new BaseResult();

                return new BaseResult(assignRoleResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)));
            }

            // Create new account
            var user = new ApplicationUser()
            {
                UserName = request.UserName,
                Email = request.Email
            };
            var identityResult = await userManager.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {
                identityResult = await userManager.AddToRoleAsync(user, request.Role);
            }
            if (identityResult.Succeeded)
                return new BaseResult();

            return new BaseResult(identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)));
        }
    }
}
