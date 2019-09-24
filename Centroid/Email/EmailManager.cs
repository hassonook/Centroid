using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Centroid.Email
{
    public class EmailManager
    {
        public static void AppSettings(out string UserID, out string Password, out string SMTPPort, out string Host)
        {
            UserID = ConfigurationManager.AppSettings.Get("UserID");
            Password = ConfigurationManager.AppSettings.Get("Password");
            SMTPPort = ConfigurationManager.AppSettings.Get("SMTPPort");
            Host = ConfigurationManager.AppSettings.Get("Host");
        }
        public static void SendEmail(string From, string Subject, string Body, string To, string UserID, string Password, string SMTPPort, string Host)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(From);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(UserID, Password);
            smtp.EnableSsl = true;

            //smtp.UseDefaultCredentials = false;
            //Add this line to bypass the certificate validation
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            ///////////////////end bypass

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw;
            }

        }


        public static void SendEmailToMulti(string From, string Subject, string Body, List<string> To, string UserID, string Password, string SMTPPort, string Host, string ReplyTo)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            foreach (var item in To)
            {
                mail.To.Add(new MailAddress(item));
            }

            mail.From = new MailAddress(From);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.ReplyTo = new MailAddress(ReplyTo);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(UserID, Password);
            smtp.EnableSsl = true;

            //smtp.UseDefaultCredentials = false;
            //Add this line to bypass the certificate validation
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            ///////////////////end bypass

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                throw;
            }

        }
    }
}