using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Car_showroom.MailRepo
{
    class MailG
    {

        private const string SENDER = "sender@gmail.com";
        private const string PASSWORD = "password";

        public MailMessage Message { get; set; }
        public string MesssageSubject { get; set; } = string.Empty;
        public MailAddress From { get; private set; }
        public MailAddress To { get; set; }

        public string TransformMesssage(string mes) => $"<h2>{mes}</h2>";

        private static SmtpClient SetSntpGmail(MailMessage m)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(SENDER, PASSWORD);
            smtp.EnableSsl = true;
            return smtp;
        }


        public MailG(string receiver, string subject, string message)
        {
            From = new(SENDER);
            To = new(receiver);
            Message = new MailMessage(From, To);
            Message.Subject = subject;
            Message.Body = TransformMesssage(message);
            Message.IsBodyHtml = true;
            SetSntpGmail(Message);
        }

        public void Send(MailMessage mesToSend)
        {
            SmtpClient smtp = new();
            smtp = SetSntpGmail(mesToSend);
            smtp.Send(Message);
        }



    }
}
