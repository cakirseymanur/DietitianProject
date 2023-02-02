using AutoMapper;
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
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto p)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = _mapper.Map<AppUser>(p);
                appUser.MailCode = new Random().Next(10000, 999999).ToString();
               
                if (p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(appUser, p.Password);
                    if (result.Succeeded)
                    {
                        SendEmail(appUser.Email, appUser.MailCode,p.UserName);
                        return RedirectToAction("EmailConfirmed", "Register");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("ConfirmPassword", "Şifreler uyuşmuyor.");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EmailConfirmed()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(EmailConfirmedDto p)
        {
            if (ModelState.IsValid)
            { 
                var user = await _userManager.FindByEmailAsync(p.Email);
                if (user.MailCode == p.MailCode)
                {
                    user.EmailConfirmed = true;
               
                    var result = await _userManager.UpdateAsync(user);
                    return RedirectToAction("Index", "Login");
                }
                ModelState.AddModelError("MailCode","Email ve onay kodu uyuşmuyor.");
            }
            
            return View();
        }
        public void SendEmail(string email, string emailcode, string username)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("dietdeal", "symnr1cakir@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

            MailboxAddress mailboxAddressTo = new MailboxAddress(username, email);
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

            mimeMessage.Subject = "Üyelik Kaydı Onay Kodu"; //Gönderilecek mailin başlığı

            SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("symnr1cakir@gmail.com", "ovdzzruhpkjokckm");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
        }
    }
}
