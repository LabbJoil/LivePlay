
using LivePlay.Front.Core.Options;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LivePlay.Front.MAUI.MauiProgramExtentions;

public static class ConfigurationRegistrar
{
    public static void AddAppConfigurations(this MauiAppBuilder builder)
    {
        using Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LivePlay.Front.MAUI.appsettings.json");
        if (stream != null)
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);
        }
    }

    public static void RegisterConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.Configure<HttpProviderOptions>(builder.Configuration.GetSection(nameof(HttpProviderOptions)));
        //services.Configure<QuestFilterOptions>(configuration.GetSection(nameof(QuestFilterOptions))); // конфигурация пока что не нужна
    }
}
