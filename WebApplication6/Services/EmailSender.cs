using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Services
{
    public class EmailSender : ISender
    {
        private IConfiguration conf;
        public EmailSender(IConfiguration conf)
        {
            this.conf = conf;
        }
        public void Send()
        {
            var client = new SmtpClient();
            client.EnableSsl = true;
            var set = new ServiceMail();
            conf.Bind(set);
            set = conf.Get<ServiceMail>();
            client.Credentials = new NetworkCredential()
            {
                UserName = set.SenderMail,
                Password = set.SenderPassword
            };
            client.Send(set.SenderMail, set.SupportMail, set.MailHead, set.LetterText);
        }
    }
}
