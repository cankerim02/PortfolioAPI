using Business.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;


namespace Business.Concrete
{
    public class EmailServicesManager : IEmailServices
    {
        private readonly IConfiguration _config;
        private readonly IServiceLogServices _serviceLogServices;

        public EmailServicesManager(IConfiguration config, IServiceLogServices serviceLogServices)
        {
            _config = config;
            _serviceLogServices = serviceLogServices;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var apiKey = _config["Smtp:SendGridApiKey"];
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_config["Smtp:From"], "Admin");
                var to = new EmailAddress(toEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

                //Fire-and forget mantığı ile mail gönderimi burda başlatıyorum ama await ile bloklamıyorum
                _ = client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                await _serviceLogServices.LogAsync(new ServiceLog
                {
                    Message = $"Mail gönderilemedi {ex.Message}",
                    StackTrace = ex.StackTrace,
                    CreatedAt = DateTime.UtcNow,
                });
            }

        }
    }
}

