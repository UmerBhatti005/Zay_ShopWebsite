using IdentityProjectPractise.Models;
using IdentityProjectPractise.Repository;
using IdentityProjectPractise.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Zay.Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IAccountRepository _accountRepository;

        public RoleManager<IdentityRole> _roleManager { get; }

        public AccountController(IAccountRepository accountRepository, UserManager<ApplicationUser> userManager, IEmailService emailService, RoleManager<IdentityRole> roleManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("/users")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = _userManager.Users.ToList().ToModelList();
                foreach (var c in users)
                {
                    var d = await _roleManager.FindByIdAsync(c.role);
                    c.role = d.Name;
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Username}")]
        [Authorize]
        public IActionResult GetdeptId(string Username)
        {
            try
            {
                var dept = _userManager.Users.Where(d => d.UserName == Username).FirstOrDefault().ToModel();
                return Ok(dept);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(userModel.role);
                var user = new ApplicationUser()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastNme,
                    Email = userModel.Email,
                    UserName = userModel.Username,
                    role = userModel.role
                };
                //This is image, We signup With the image
                user.Image = Convert.FromBase64String(userModel.Image);
                var result = await _userManager.CreateAsync(user, userModel.Password);
                var a = await _userManager.AddToRoleAsync(user, role.Name);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError(error.Code, error.Description);
                    }
                    return Ok(userModel);
                }
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new List<string> { userModel.Email }, "Confirmation email link", confirmationLink);
                await _emailService.SendEmail(message);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return BadRequest("Error");
                }
                var result = await _userManager.ConfirmEmailAsync(user, token);
                return Ok(result.Succeeded ? nameof(ConfirmEmail) : BadRequest());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInUserModel signInUserModel, string returnUrl)
        {
            try
            {
                var result = await _accountRepository.LoginAsync(signInUserModel);
                var User = await _accountRepository.GetUserByEmailAsync(signInUserModel.Email);
                var role = await _roleManager.FindByIdAsync(User.role);
                DateTimeOffset now = DateTimeOffset.UtcNow;
                long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();

                //Console.WriteLine(unixTimeMilliseconds);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Ok(returnUrl);
                }
                else if (string.IsNullOrEmpty(result) || role == null)
                {
                    return Unauthorized();
                }

                return Ok(new { TokenOptions = result, username = signInUserModel.Email, role = role.Name, rememberme = signInUserModel.Rememberme, setupTime = unixTimeMilliseconds });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("Logout")]
        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await _accountRepository.signOutAsync();
            return Ok();
        }

        [Route("change-password")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _accountRepository.ChangePasswordAsync(model);
                    if (result.Succeeded)
                    {
                        //ViewBag.IsSuccess = true;
                        ModelState.Clear();
                        return Ok();
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous, HttpPost("forgot-password")]

        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var user = await _accountRepository.GetUserByEmailAsync(model.Email);

                    if (user != null)
                    {
                        //await _accountRepository GenerateForgotPasswordTokenAsync(user);
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        if (!string.IsNullOrEmpty(token))
                        {
                            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);
                            var message = new Message(new List<string> { model.Email }, "Confirmation email link", confirmationLink);
                            await _emailService.SendEmail(message);
                            return Ok();
                        }
                        return BadRequest("No Token Here");
                    }
                    ModelState.Clear();
                    model.EmailSent = true;
                }

                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Token = model.Token.Replace(' ', '+');
                    var result = await _accountRepository.ResetPasswordAsync(model);
                    if (result.Succeeded)
                    {
                        ModelState.Clear();
                        model.IsSuccess = true;
                        return Ok(model);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
