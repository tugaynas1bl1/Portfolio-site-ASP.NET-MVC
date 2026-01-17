using MimeKit;
using MailKit.Net.Smtp;
using Portfolio_site_hw.Models;

namespace Portfolio_site_hw.Services;

public class EmailService
{
    private const string FromEmail = "grey.samsung.j7@gmail.com";
    private const string FromPassword = "dqgnznvejgnubipy";

    public void SendHireMeEmails(HiringPerson person)
    {
        using var client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate(FromEmail, FromPassword);

        var adminMessage = new MimeMessage();
        adminMessage.From.Add(new MailboxAddress("Hire Me Form", FromEmail));
        adminMessage.To.Add(MailboxAddress.Parse(FromEmail));
        adminMessage.Subject = "New Hire Me Message";

        adminMessage.ReplyTo.Add(
            MailboxAddress.Parse(person.Email)
        );

        adminMessage.Body = new TextPart("html")
        {
            Text = $"""
                <h2>New Hire Me Message</h2>
                <b>Name:</b> {person.Name}<br/>
                <b>Email:</b> {person.Email}<br/><br/>
                <b>Message:</b>
                <p style="white-space:break-spaces">{person.Message}</p>
                """
        };

        client.Send(adminMessage);

        var userMessage = new MimeMessage();
        userMessage.From.Add(new MailboxAddress("Tugay Nasibli", FromEmail));
        userMessage.To.Add(MailboxAddress.Parse(person.Email));
        userMessage.Subject = "Thank you for your message";

        userMessage.Body = new TextPart("html")
        {
            Text = $"""
                <h1 style="color:blue">Dear {person.Name},</h1>
                <p>Thank you for contacting me.</p>
                <p>I have received your message and will reply as soon as possible.</p>

                <hr/>
                <b>Your message:</b>
                <blockquote style="white-space:break-spaces">{person.Message}</blockquote>

                <hr/>

                <p>Best regards,<br/>
                Tugay Nasibli</p>
                """
        };

        client.Send(userMessage);

        client.Disconnect(true);
    }
}
