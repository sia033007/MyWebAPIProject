using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMVCProject.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MyMVCProject.Controllers
{

    public class IdentityUserController : Controller
    {
        private readonly SignInManager<MyUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly UserManager<MyUser> _userManager;
        public IdentityUserController(UserManager<MyUser> userManager, IMapper mapper, SignInManager<MyUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
                
        }
        public ViewResult RegisterUser() => View();
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterViewModel registerViewModel)
        {
            if(registerViewModel == null)
            {
                return View(registerViewModel);
            }
            var user = _mapper.Map<MyUser>(registerViewModel);
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                    TempData["badrequest"] = "Something Went Wrong";
                }
                return View(registerViewModel);
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim("FirstName", registerViewModel.FirstName ?? string.Empty),
                new Claim("LastName", registerViewModel.LastName ?? string.Empty),
                new Claim("City", registerViewModel.City ?? string.Empty),
                new Claim("Profession", registerViewModel.Profession ?? string.Empty)
            };
            await _userManager.AddClaimsAsync(user, claims);
            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.ActionLink(action:"ConfirmEmail", controller:"IdentityUser",
                values: new { userId = user.Id, token = confirmationToken });
            var message = new MailMessage("siavashmehmandoost@gmail.com", registerViewModel.Email,
                "Confirm Your Email Here", $"Click this link to confirm your email : {confirmationLink}");
            using(var emailClient = new SmtpClient("smtp.gmail.com", 587))
            {
                emailClient.EnableSsl = true;
                emailClient.Credentials = new NetworkCredential(
                    "siavashmehmandoost@gmail.com", "azaoawwhxtiyvwja");
                await emailClient.SendMailAsync(message);
            }
            TempData["success"] = "Registered Successfully, Now check your email to confirm your account";
            return RedirectToAction("LoginUser", "IdentityUser");
        }
        public ViewResult LoginUser() => View();
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password,
                loginViewModel.RememberMe, false);
            if(!result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    TempData["badrequest"] = "Email not confirmed";
                    return View(loginViewModel);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                    TempData["badrequest"] = "Invalid UserName or Password";
                    return View(loginViewModel);
                }
            }
            TempData["success"] = "Logged In Successfully";
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            TempData["success"] = "Logged out Successfully";
            return RedirectToAction("Index", "Home");
        }
        public ViewResult ForgotPassword() => View();
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
            if(user == null)
            {
                ModelState.AddModelError("", "Not found such a user");
                TempData["notfound"] = "Not found such a user";
                return View(forgotPasswordViewModel);
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.ActionLink(action: "ResetPassword", controller: "IdentityUser", values: new
            { userId = user.Id, token = resetToken });
            var message = new MailMessage("siavashmehmandoost@gmail.com",
                forgotPasswordViewModel.Email, "Reset Your Password",
                $"Click this link to reset your password :{resetLink}");
            using(var emailClient = new SmtpClient("smtp.gmail.com", 587))
            {
                emailClient.EnableSsl = true;
                emailClient.Credentials = new NetworkCredential(
                    "siavashmehmandoost@gmail.com", "azaoawwhxtiyvwja");
                await emailClient.SendMailAsync(message);
            }
            TempData["success"] = "Reset password email was sent to your email address";
            return RedirectToAction("LoginUser", "IdentityUser");
        }
        public ViewResult ResetPassword(string userId, string token)
        {
            var resetPasswordViewModel = new ResetPasswordViewModel
            {
                userId = userId,
                token = token,
                Password = string.Empty,
                ConfirmPassword = string.Empty
            };
            return View(resetPasswordViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) return View(resetPasswordViewModel);
            var user = await _userManager.FindByIdAsync(resetPasswordViewModel.userId);
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.token,
                resetPasswordViewModel.Password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    TempData["badrequest"] = "Something went wrong";
                    return View(resetPasswordViewModel);
                }
            }
            TempData["success"] = $"Password Reset Successfully for {user.UserName}";
            return RedirectToAction("LoginUser", "IdentityUser");
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                TempData["notfound"] = "Not found such a user";
                return View();
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    TempData["badrequest"] = "Something went wrong";
                }
                return View();
            }
            TempData["success"] = "Successfully confirmed email, You can log in now";
            return RedirectToAction("LoginUser", "IdentityUser");
        }
        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            UserProfieViewModel profileModel = new UserProfieViewModel();
            var (user, userName, email, cityClaim, firstNameClaim, lastNameClaim, professionClaim) = await GetUserInfo();

            profileModel.UserName = userName;
            profileModel.Email = email;
            profileModel.FirstName = firstNameClaim?.Value;
            profileModel.LastName = lastNameClaim?.Value;
            profileModel.City = cityClaim?.Value;
            profileModel.Profession = professionClaim?.Value;
            return View(profileModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UserProfile(UserProfieViewModel profileModel)
        {
            var (user, userName, email, cityClaim, firstNameClaim, lastNameClaim, professionClaim) = await GetUserInfo();
            try
            {
                await _userManager.ReplaceClaimAsync(user, cityClaim, new Claim(cityClaim.Type, profileModel.City));
                await _userManager.ReplaceClaimAsync(user, firstNameClaim, new Claim(firstNameClaim.Type, profileModel.FirstName));
                await _userManager.ReplaceClaimAsync(user, lastNameClaim, new Claim(lastNameClaim.Type, profileModel.LastName));
                await _userManager.ReplaceClaimAsync(user, professionClaim, new Claim(professionClaim.Type, profileModel.Profession));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong while saving data");
                TempData["badrequest"] = "Something went wrong";

            }
            TempData["success"] = "User profile updated successfully";
            return View();
        }
        private async Task<( MyUser, string, string, Claim, Claim, Claim, Claim)> GetUserInfo()
        {
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            var email = await _userManager.GetEmailAsync(user);
            var claims = await _userManager.GetClaimsAsync(user);
            var cityClaim = claims.FirstOrDefault(c => c.Type == "City");
            var firstNameClaim = claims.FirstOrDefault(c => c.Type == "FirstName");
            var lastNameClaim = claims.FirstOrDefault(c => c.Type == "LastName");
            var professionClaim = claims.FirstOrDefault(c => c.Type == "Profession");
            return (user, userName, email, cityClaim, firstNameClaim, lastNameClaim, professionClaim);
        }
    }
}
