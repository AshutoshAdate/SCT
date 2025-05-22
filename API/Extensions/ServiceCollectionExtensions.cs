using SCT.Application.Helper;
using SCT.Application.Helper.EmailTemplate;
using SCT.Application.Helper.SMTP;
using SCT.Application.Interfaces;
using SCT.Application.Services;
using SCT.Domain.Interfaces;
using SCT.Infrastructure.Repositories;

namespace SCT.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddTransient<IMailHelper, MailHelper>();

            services.AddScoped<IEmailTemplateService, EmailTemplateService>();
            services.AddScoped<IEmailRepository, EmailRepository>();

            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();

            //return services;
        }
    }
}
