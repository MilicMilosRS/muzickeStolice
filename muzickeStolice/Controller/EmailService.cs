using System.Net;
using System.Net.Mail;

namespace muzickeStolice.Controller
{
    public static class EmailService
    {
        public static void SendVerificationEmail(string email, string verificationCode)
        {
            var fromAddress = new MailAddress("StudentFTN007@gmail.com", "muzicke stolice");
            var toAddress = new MailAddress(email);
            const string fromPassword = "gffc urtn udph nzkp";
            const string subject = "Email Verification";
            string body = $"Verifikujte mail koristeci sledeci kod: {verificationCode}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,             
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch (SmtpException ex)
                {
                    throw;
                }
            }
        }
    }
}
