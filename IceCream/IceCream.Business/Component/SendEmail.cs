using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Business.Component
{
    public class SendEmail
    {
        public void SendEmailIceScream(string userName, string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("ICE SCREAM", "cedicescream@gmail.com"));
            emailMessage.To.Add(new MailboxAddress(userName, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };
            
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                
                ////Note: only needed if the SMTP server requires authentication
                client.Authenticate("cedicescream@gmail.com", "i1qazse$");

                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
