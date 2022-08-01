namespace IdentityProjectPractise.Services
{
    public interface IUserService
    {
        string GetUserId();

        bool IsAuthenticated();
    }
}