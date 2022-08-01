using IdentityProjectPractise.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Repository
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        //Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        //Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<SignInResult> PasswordSignInAsync(SignInUserModel userModel);
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
        Task signOutAsync();

        //Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);

        Task<string> LoginAsync(SignInUserModel signInModel);
    }
}
