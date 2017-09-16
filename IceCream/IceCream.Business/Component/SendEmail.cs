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
    {        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("ICE SCREAM", "cedicescream@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("reginaldo.botelho@dartdigital.com.br", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Resete pass") { Text = message };

            using (var client = new SmtpClient())
            {
                client.LocalDomain = "gmail.com";
                await client.ConnectAsync("smtp.gmail.com", 25, SecureSocketOptions.None).ConfigureAwait(false);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }    
}
