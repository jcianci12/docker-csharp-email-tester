using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main()
    {
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var configuration = configBuilder.Build();

        var smtpSettings = configuration.GetSection("SmtpSettings");
        var emailSettings = configuration.GetSection("EmailSettings");

        var fromAddress = new MailAddress(smtpSettings["Username"], "wehireit");
        var fromPassword = smtpSettings["Password"];

        var toAddress = new MailAddress(emailSettings["ToAddress"], "Jon Cianci");
        var subject = emailSettings["Subject"];
        var body = emailSettings["Body"];

        var smtp = new SmtpClient
        {
            Host = smtpSettings["Host"],
            Port = int.Parse(smtpSettings["Port"]),
            EnableSsl = bool.Parse(smtpSettings["EnableSsl"]),
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            Timeout = 5000
        };

        try
        {
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while sending email.");
            Console.WriteLine(ex.ToString());
        }
    }
}
