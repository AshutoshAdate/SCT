using SCT.Application.Helper.SMTP;
using SCT.Application.Interfaces;
using SCT.Domain.Entities.EmailService;
using SCT.Infrastructure.Data;

namespace SCT.Infrastructure.BackgroundServices
{
    public class EmailWorkerService : BackgroundService
    {
        private readonly IMailHelper _emailQueue;
        private readonly IServiceProvider _serviceProvider;

        public EmailWorkerService(IMailHelper mailHelper, IServiceProvider serviceProvider)
        {
            _emailQueue = mailHelper;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_emailQueue.TryDequeue(out var email))
                {
                    using var scope = _serviceProvider.CreateScope();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    bool success = await emailService.SendEmailAsync(email);
                    email.Status = success ? EmailStatus.Sent : EmailStatus.Failed;

                    dbContext.EmailRequests.Update(email);
                    await dbContext.SaveChangesAsync();
                }

                await Task.Delay(1000); // Optional delay
            }
        }
    }
}
