using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using UserNotification.Services.Interfaces;

namespace UserNotification.Entrypoints
{
    public class UserNotificationEntrypoint
    {
        private readonly ILogger<UserNotificationEntrypoint> _logger;

        private readonly ISendEmailUserService _sendEmailUserService;

        public UserNotificationEntrypoint(
            ILogger<UserNotificationEntrypoint> logger,
            ISendEmailUserService sendEmailUserService)
        {
            _logger = logger;
            _sendEmailUserService = sendEmailUserService;
        }

        [Function("E_User_Notification_Email")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/user/notification-email")]
            HttpRequest req)
        {
            try
            {
                string email = req.Query["email"];

                _logger.LogInformation(@$"Start email send: {email}");

                await _sendEmailUserService.SendEmailAsync(email);

                return new OkObjectResult("Email Enviado");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
