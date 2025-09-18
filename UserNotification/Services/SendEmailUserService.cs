using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using UserNotification.Services.Interfaces;

namespace UserNotification.Services;

public class SendEmailUserService : ISendEmailUserService
{
    public IConfiguration Configuration;
    public SendEmailUserService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public async Task SendEmailAsync(string email)
    {
        try
        {
            var pass = Configuration.GetValue<string>("EmailPassword");

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("fcggamelibrary@gmail.com", "rakg ewkn rqkn hptx"),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            // Criação do e-mail
            var mailMessage = new MailMessage
            {
                From = new MailAddress("fcggamelibrary@gmail.com", "Fiap Game Library"),
                Subject = "🎉 Bem-vindo ao Fiap Game Library!",
                Body = "<h1>Bem-vindo!</h1><p>Obrigado por se cadastrar no <b>FGC - Game Library</b>.</p>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            // Envio do e-mail
            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao enviar e-mail via SMTP", ex);
        }
    }
}
