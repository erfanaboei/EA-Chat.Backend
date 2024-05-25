using System.Net;
using System.Net.Mail;

namespace EA_Chat.Application.Senders.Mail;

public class SendMail: ISendMail
{
    public void Send(string to, string subject, string body)
    {
        var mail = new MailMessage();

        var smtpServer = new SmtpClient("smtp");

        mail.From = new MailAddress("EmailAddress", "EA-Chat");
        
        mail.To.Add(to);

        mail.Subject = subject;

        mail.Body = body;

        mail.IsBodyHtml = true;

        smtpServer.Credentials = new NetworkCredential("Email", "Password");

        smtpServer.EnableSsl = false;

        smtpServer.Send(mail);
    }
}