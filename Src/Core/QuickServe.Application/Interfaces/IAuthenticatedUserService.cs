namespace QuickServe.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        string UserName { get; }
        string[] Roles { get; }
    }

}
