using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using QuickServe.Application.DTOs.Account.Requests;
using QuickServe.Application.DTOs.Account.Responses;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.UserInterfaces;
using QuickServe.Application.Wrappers;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Error = QuickServe.Application.Wrappers.Error;

namespace QuickServe.Infrastructure.Identity.Services
{
    public class AccountServices(UserManager<IdentityUser> userManager, IAuthenticatedUserService authenticatedUser, SignInManager<IdentityUser> signInManager, ITranslator translator, HttpClient httpClient, IConfiguration configuration) : IAccountServices
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

        public async Task<BaseResult<AuthenticationResponse>> Authenticate(AuthenticationRequest login, bool? useCookies, bool? useSessionCookies)
        {
            var endpoint = $"{configuration["ApiBaseUrl"]}/api/v1/identity/login";
            if (useCookies.HasValue)
                endpoint += $"?useCookies={useCookies.Value}";
            if (useSessionCookies.HasValue)
                endpoint += $"&useSessionCookies={useSessionCookies.Value}";

            var jsonContent = new StringContent(
            JsonSerializer.Serialize(new
            {
                email = login.Email,
                password = login.Password
            }),
            Encoding.UTF8,
            "application/json");
            var response = await httpClient.PostAsync(endpoint, jsonContent);
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                return new BaseResult<AuthenticationResponse>(new Error(ErrorCode.AccessDenied, response.ReasonPhrase));
            }

            var responseData = await response.Content.ReadAsStringAsync();

            var user = await userManager.FindByEmailAsync(login.Email);
            var roles = await userManager.GetRolesAsync(user);

            var result = new AuthenticationResponse()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.Email,
                Roles = [.. roles],
                IsVerified = user.EmailConfirmed
            };

            if (!string.IsNullOrEmpty(responseData))
            {
                var responseJson = JsonSerializer.Deserialize<AuthenticationResponse>(responseData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                });
                result.AccessToken = responseJson.AccessToken;
                result.RefreshToken = responseJson.RefreshToken;
                result.TokenType = responseJson.TokenType;
                result.ExpiresIn = responseJson.ExpiresIn;
            }

            return new BaseResult<AuthenticationResponse>(result);
        }

        public async Task<BaseResult<AuthenticationResponse>> AuthenticateByUserName(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new BaseResult<AuthenticationResponse>(new Error(ErrorCode.NotFound, translator.GetString(TranslatorMessages.AccountMessages.Account_notfound_with_UserName(username)), nameof(username)));
            }

            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);

            //var jwToken = await GenerateJwtToken(user); 

            AuthenticationResponse response = new AuthenticationResponse()
            {
                Id = user.Id.ToString(),
                //JWToken = new JwtSecurityTokenHandler().WriteToken(jwToken),
                Email = user.Email,
                UserName = user.UserName,
                Roles = rolesList.ToList(),
                IsVerified = user.EmailConfirmed,
            };

            return new BaseResult<AuthenticationResponse>(response);
        }

        public async Task<BaseResult<string>> RegisterGostAccount()
        {
            var user = new IdentityUser()
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
        //private async Task<JwtSecurityToken> GenerateJwtToken(IdentityUser user)
        //{
        //    await userManager.UpdateSecurityStampAsync(user);

        //    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        //    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        //    var jwtSecurityToken = new JwtSecurityToken(
        //        issuer: jwtSettings.Issuer,
        //        audience: jwtSettings.Audience,
        //        claims: await GetClaimsAsync(),
        //        expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
        //        signingCredentials: signingCredentials);
        //    return jwtSecurityToken;

        //    async Task<IList<Claim>> GetClaimsAsync()
        //    {
        //        var result = await signInManager.ClaimsFactory.CreateAsync(user);
        //        return result.Claims.ToList();
        //    }
        //}

    }
}
