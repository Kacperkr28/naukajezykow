using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LanguageLearningQuiz.Services
{
    public static class EmailService
    {
        public static async Task SendResultsViaEmail(string email, int correctAnswers, int totalQuestions)
        {
            string subject = "Wyniki:";
            string body = $"Odpowiedzia³eœ {correctAnswers} na {totalQuestions} pytañ poprawnie!\n\nDziêkujemy za urzywanie naszej aplikacji!";
            string senderEmail = "mailadodampozniejaledziala"; // Twoje konto e-mail
            string senderPassword = "has³ododampozniejaledziala"; // Has³o do konta e-mail (lub aplikacyjne)

            try
            {
                var smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587, // Port, np. dla Gmail 587 (z TLS)
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);

                Console.WriteLine("Twoje wyniki zosta³y wys³ane!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B³¹d z przes³aniem: {ex.Message}");
            }
        }
    }
}
