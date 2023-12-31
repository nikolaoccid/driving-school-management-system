﻿using DSMS.Application.Common.Email;
using DSMS.Application.MappingProfiles;
using DSMS.Application.Services;
using DSMS.Application.Services.DevImpl;
using DSMS.Application.Services.Impl;
using DSMS.DataAccess.Repositories;
using DSMS.DataAccess.Repositories.Impl;
using DSMS.Shared.Services;
using DSMS.Shared.Services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DSMS.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddServices(env);

        services.RegisterAutoMapper();

        return services;
    }

    private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IClaimService, ClaimService>();
        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        services.AddScoped<IReactionRepository, ReactionRepository>();

        if (env.IsDevelopment())
            services.AddScoped<IEmailService, DevEmailService>();
        else
            services.AddScoped<IEmailService, EmailService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }

    public static void AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("SmtpSettings").Get<SmtpSettings>());
    }
}
