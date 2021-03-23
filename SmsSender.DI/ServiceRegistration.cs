using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmsSender.BLL.Interfaces;
using SmsSender.BLL.Services;
using SmsSender.DAL.Core;
using SmsSender.DAL.Repositories;
using SmsSender.Shared.Contracts.DTOs;
using SmsSender.Shared.Interfaces;

namespace SmsSender.DI
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

            services.AddScoped<ISmsSenderAuthenticationService, AuthenticationService>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services.AddScoped<ISendInvitesRequestValidationService<SendInvitesDto>, SendInvitesRequestValidationService>();
            services.AddScoped<ISmsService, SmsService>();

            services.ConfigureAutoMapper();

            return services;
        }

        private static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<SendInvitesMappingProfile>();
            });

            services.AddSingleton(mapperConfig.CreateMapper());

            return services;
        }
    }
}
