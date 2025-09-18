namespace UserNotification.Services.Interfaces;

public interface ISendEmailUserService
{
    Task SendEmailAsync(string email);
}
