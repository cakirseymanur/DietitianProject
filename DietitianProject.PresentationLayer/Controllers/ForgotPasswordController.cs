using DietitianProject.BusinessLayer.ValidationRules.AppUserValidator;
using DietitianProject.DtoLayer.DTOs.AppUserDTOs;
using DietitianProject.EntityLayer.Concrete;
using FluentValidation;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietitianProject.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class ForgotPasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly IValidator<ForgotPasswordDto> _forgotPasswordValidator;
        //private readonly IValidator<ResetPasswordDto> _resetPasswordValidator;

        public ForgotPasswordController(UserManager<AppUser> userManager/*, IValidator<ForgotPasswordDto> forgotPasswordValidator, IValidator<ResetPasswordDto> resetPasswordValidator*/)
        {
            _userManager = userManager;
            //_forgotPasswordValidator = forgotPasswordValidator;
            //_resetPasswordValidator = resetPasswordValidator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto p)
        { 
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(p.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "ForgotPassword", new { email = p.Email, token = token,username= user.UserName }, Request.Scheme);
                    return RedirectToAction("ForgotPasswordConfirmation", new { url = passwordResetLink, email = p.Email });
                }
                ModelState.AddModelError("Email", "Mail adresiniz yanlış.");
            } 
            return View();
        }
        public IActionResult ResetPassword(string email, string token)
        {
            if (email == null && token == null)
            {
                ModelState.AddModelError("All", "Geçersiz İşlem");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            //var validationResult = _resetPasswordValidator.Validate(resetPasswordDto);
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Login");
                    }
                }
            }
            //else
            //{
            //    foreach (var failure in validationResult.Errors)
            //    {
            //        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            //    }
            //}
            return View();
        }


        public IActionResult ForgotPasswordConfirmation(string url, string email,string username)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("dietdeal", "symnr1cakir@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

            MailboxAddress mailboxAddressTo = new MailboxAddress(username, email);
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = url;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

            mimeMessage.Subject = "Şifre Sıfırlama"; //Gönderilecek mailin başlığı

            SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("symnr1cakir@gmail.com", "ovdzzruhpkjokckm");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
            return RedirectToAction("Index");
        }
    }
}
