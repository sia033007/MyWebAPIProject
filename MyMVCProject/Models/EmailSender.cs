﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyMVCProject.Models
{
    //public class EmailSender : IEmailSender
    //{
    //    private readonly IOptions<SmtpSettings> _smtpSettings;
    //    public EmailSender(IOptions<SmtpSettings> smtpSettings)
    //    {
    //        _smtpSettings = smtpSettings;
    //    }

    //    public async Task SendAsync(string from, string to, string subject, string body)
    //    {
    //        var message = new MailMessage(from, to, subject, body);

    //        using (var smtp = new SmtpClient(_smtpSettings.Value.Host, _smtpSettings.Value.Port))
    //        {
    //            smtp.EnableSsl = true;
    //            smtp.Credentials = new NetworkCredential(
    //                _smtpSettings.Value.User, _smtpSettings.Value.Password);
    //            await smtp.SendMailAsync(message);
    //        }
    //    }
    //}
}
