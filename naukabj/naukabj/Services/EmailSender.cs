using MailKit.Net.Smtp;
using MimeKit;

public class EmailSender
{
    public void SendStatistics(string toEmail, string subject, string body, string attachmentPath)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("Flashcards App", "your-email@example.com"));
        email.To.Add(new MailboxAddress("", toEmail));
        email.Subject = subject;

        var builder = new BodyBuilder { TextBody = body };

        if (!string.IsNullOrEmpty(attachmentPath))
            builder.Attachments.Add(attachmentPath);

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("your-email@example.com", "your-password");
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
