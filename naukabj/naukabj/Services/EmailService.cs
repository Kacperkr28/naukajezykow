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
            string body = $"Odpowiedzia�e� {correctAnswers} na {totalQuestions} pyta� poprawnie!\n\nDzi�kujemy za urzywanie naszej aplikacji!";
            string senderEmail = "mailadodampozniejaledziala"; // Twoje konto e-mail
            string senderPassword = "has�ododampozniejaledziala"; // Has�o do konta e-mail (lub aplikacyjne)

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

                Console.WriteLine("Twoje wyniki zosta�y wys�ane!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"B��d z przes�aniem: {ex.Message}");
            }
        }
    }
}
