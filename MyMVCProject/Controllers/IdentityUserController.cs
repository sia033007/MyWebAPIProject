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
            TempData["success"] = "Registered Successfully";
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
                ModelState.AddModelError("", "Invalid UserName or Password");
                TempData["badrequest"] = "Invalid UserName or Password";
                return View(loginViewModel);
            }
            TempData["success"] = "Logged In Successfully";
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> LogoutUser()
        {
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
            TempData["success"] = "Password Reset Successfully";
            return RedirectToAction("LoginUser", "IdentityUser");
        }
    }
}
