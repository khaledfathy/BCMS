using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace BCMS.Models
{
    public class EmailVerification
    {
        public static string SendEMail(string emailid, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress("borsacapital0@gmail.com", "Borsa Capital");
                var toAddress = new MailAddress(emailid);
                const string fromPassword = "borsacapital2013";
                var smtp = new SmtpClient
                {
                    Host = "Smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,

                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }

        public static string ContactUsMail(string senderName, string mailId, string msgSubject, string msgbody)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(mailId);
                mailMessage.To.Add("borsacapital0@gmail.com");
                mailMessage.Subject = msgSubject;

                StringBuilder sb = new StringBuilder();
                sb.Append("Name: " + senderName + "\r\n");
                sb.Append("Email: " + mailId + "\r\n");
                sb.Append("Message: " + msgbody + "\r\n");

                mailMessage.Body = sb.ToString();
                
                mailMessage.IsBodyHtml = false;
                System.Net.Mail.SmtpClient client = new SmtpClient("Smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("borsacapital0@gmail.com", "borsacapital2013");
                client.Send(mailMessage);
                return "تم إرسال الرسالة بنجاح";
            }
            catch (Exception ex)
            {
                return "هناك خطأ في إرسال الرسالة";
            }
        }
    }
}