using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailServices
    {
        public static void sendmail(string email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("sridharhindhujha@gmail.com", "hindhu17");

                MailMessage msgobj = new MailMessage();
                msgobj.To.Add(email);
                msgobj.From = new MailAddress("sridharhindhujha@gmail.com");
                msgobj.Subject = "password reset link";
                msgobj.Body = $"BookStore/{token}";
                client.Send(msgobj);
            }
        }

    }
}
