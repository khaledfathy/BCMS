using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BCMS.Models
{
    public class EmailVerification
    {
        public static string  SendEMail(string emailid, string subject, string body)
        {
            //try
            //{
                //    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtpout.secureserver.net", 25);
                //    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //    client.EnableSsl = true;
                //    client.Port = 25;
                //    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("ContactUs@borsacapital.com", "b123@123");
                //    client.UseDefaultCredentials = false;
                //    client.Credentials = credentials;
                //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                //    msg.From = new MailAddress("ContactUs@borsacapital.com");
                //    msg.To.Add(new MailAddress(emailid));
                //    msg.Subject = subject;
                //    msg.IsBodyHtml = true;
                //    msg.Body = body;
                //    client.Send(msg);
                //    return "Success";
                //}
                //catch (Exception ex)
                //{
                //    return "هناك خطأ في إرسال الرسالة";
                //}



                try
                {
                    var fromAddress = new MailAddress("borsacapital0@gmail.com", "Borsa Capital");
                    var toAddress = new MailAddress(emailid);
                    const string fromPassword = "borsacapital2013";
                    //const string subject = "Subject";
                    //const string body = "Body";

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
                mailMessage.From = new MailAddress("ContactUs@borsacapital.com");
                mailMessage.To.Add("ContactUs@borsacapital.com");
                mailMessage.Subject = msgSubject;
                mailMessage.Body = "<b> Sender Name: </b>" + senderName + "<br/>"
                    + "<b> Sender Email: </b>" + mailId + "<br/>"
                    + "<b>Message: </b>" + msgbody;
                mailMessage.IsBodyHtml = true;
                System.Net.Mail.SmtpClient client = new SmtpClient("smtpout.secureserver.net", 25);
                //client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("ContactUs@borsacapital.com", "b123@123");
                client.Send(mailMessage);
                return "تم إرسال الرسالة بنجاح";
            }
            catch (Exception ex)
            {
                return "هناك خطأ في إرسال الرسالة";
            }
        }


        //public static string GenerateRandomPassword(int length)
        //{
        //    string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-*&#+";
        //    char[] chars = new char[length];
        //    Random rd = new Random();
        //    for (int i = 0; i < length; i++)
        //    {
        //        chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
        //    }
        //    return new string(chars);
        //}
    }
}