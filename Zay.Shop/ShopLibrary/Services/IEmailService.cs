using IdentityProjectPractise.Models;
using ShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProjectPractise.Services
{
    public interface IEmailService
    {

        //Task SendTestEmail(EmailRequest request);

        //Task SendEmailForEmailConfirmation(EmailRequest request);

        //Task SendEmailForForgotPassword(EmailRequest request);

        Task SendEmail(Message request);
    }
}
