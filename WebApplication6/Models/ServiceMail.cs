using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class ServiceMail
    {
        public string SenderMail { get; set; }
        public string SenderPassword { get; set; }
        public string SupportMail { get; set; }
        public string MailHead { get; set; }
        public string LetterText { get; set; }
    }
}
