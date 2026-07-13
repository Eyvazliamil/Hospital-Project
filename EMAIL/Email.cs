using HospitalProject.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.EMAIL
{
    public class Email
    { 
        public static void EmailMessages(string msg)
        { 
            Console.Clear();
            Console.WriteLine("========== E-Mail ==========");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void SendCvToEmail(string by)
        {
            string emailsender = "youremail@gmail.com";
            string appPassword = Environment.GetEnvironmentVariable("GMAIL_APP_PASSWORD");

            if (string.IsNullOrEmpty(appPassword))
            {
                Console.WriteLine("Value hasnt set yet");
                return;
            }

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailsender);
            mail.To.Clear();
            mail.To.Add(emailsender); // if you want to send to someone then fix like that mail.To.Add("WhoseEmail@gmail.com"); 
            mail.Subject = "Apple Hospital";
            mail.IsBodyHtml = true;
            mail.Body = @$"
<h2 style='color:blue;'>CV Form</h2>
<p><b>CV was sent by {by}.</b></p>";

            using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(emailsender, appPassword);

            try
            { 
                smtp.Send(mail); 
            }
            catch (SmtpException msg)
            {
                Console.WriteLine(msg.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }
    }
}
