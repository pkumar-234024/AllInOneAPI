using AllInOne.Core.Interfaces;
using AllInOne.Core.Services;
using AllInOne.Infrastructure;
using AllInOne.Infrastructure.Email;

namespace AllInOne.Web.Configurations;

public static class ServiceConfigs
{
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services, Microsoft.Extensions.Logging.ILogger logger, WebApplicationBuilder builder)
  {
    services.AddInfrastructureServices(builder.Configuration, logger)
            .AddMediatrConfigs();


    if (builder.Environment.IsDevelopment())
    {
      // Use a local test email server
      // See: https://ardalis.com/configuring-a-local-test-email-server/
      services.AddScoped<IEmailSender, MimeKitEmailSender>();
      services.AddScoped<IAiToolService, AiToolService>();

      // Otherwise use this:
      //builder.Services.AddScoped<IEmailSender, FakeEmailSender>();

    }
    else
    {
      services.AddScoped<IEmailSender, MimeKitEmailSender>();
      services.AddScoped<IAiToolService, AiToolService>();
    }

    logger.LogInformation("{Project} services registered", "Mediatr and Email Sender");

    return services;
  }


}
