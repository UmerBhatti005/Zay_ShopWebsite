
using IdentityProjectPractise.Models;
using IdentityProjectPractise.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountRepository(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUserService userService,
            IEmailService emailService,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByNameAsync(email);
        }

        //public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        //{
        //    var user = new ApplicationUser()
        //    {
        //        FirstName = userModel.FirstName,
        //        LastName = userModel.LastNme,
        //        Email = userModel.Email,
        //        UserName = userModel.Email
        //    };
        //    var result = await _userManager.CreateAsync(user, userModel.Password);
        //    if (result.Succeeded)
        //    {
        //        await GenerateEmailConfirmationTokenAsync(user);
        //    }
        //    return result;
        //}

        //public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        //{
        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        await SendEmailConfirmation(user, token);
        //    }
        //}

        //public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        //{
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        await SendForgotPasswordEmail(user, token);
        //    }
        //}

        public async Task<SignInResult> PasswordSignInAsync(SignInUserModel signInUserModel)
        {
            return await _signInManager.PasswordSignInAsync(signInUserModel.Email, signInUserModel.Password, signInUserModel.Rememberme, false);
        }

        public async Task signOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
            return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);
        }


        public async Task<string> LoginAsync(SignInUserModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
