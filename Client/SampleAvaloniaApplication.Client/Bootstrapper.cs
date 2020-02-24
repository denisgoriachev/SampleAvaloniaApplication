using AutoMapper;
using Avalonia;
using Avalonia.Platform;
using SampleAvaloniaApplication.Client.Core;
using SampleAvaloniaApplication.Client.Core.Data;
using SampleAvaloniaApplication.Client.Core.Services;
using SampleAvaloniaApplication.Client.Core.Utils;
using SampleAvaloniaApplication.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using Splat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace SampleAvaloniaApplication.Client
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IMutableDependencyResolver services, IApplication app)
        {
            services.RegisterConstant<IApplication>(app);
        }

        public static void AddApplicationInfo(this IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton<IApplicationInfo>(() =>
            {
                return new ApplicationInfo(Assembly.GetExecutingAssembly());
            });
        }

        public static void AddAutomapper(this IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton(() =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });

                return config.CreateMapper();
            });
        }

        public static void AddSettingsProvider(this IMutableDependencyResolver services)
        {
            string settingsPath = "";

            var platformInfo = AvaloniaLocator.Current.GetService<IRuntimePlatform>().GetRuntimeInfo();

            AppSettings defaultAppSettings = null;

            if (platformInfo.OperatingSystem == OperatingSystemType.WinNT)
            {
                settingsPath = Environment.ExpandEnvironmentVariables("%APPDATA%\\SampleAvaloniaApplicationClient\\appsettings.json");
                defaultAppSettings = new AppSettings();
            }
            else if (platformInfo.OperatingSystem == OperatingSystemType.Linux)
            {
                settingsPath = Environment.ExpandEnvironmentVariables("/%HOME%/SampleAvaloniaApplicationClient/appsettings.json");
                defaultAppSettings = new AppSettings()
                {
                    DbFilename = "/%HOME%/SampleAvaloniaApplicationClient/data.db",
                    LogsFolder = "/%HOME%/SampleAvaloniaApplicationClient/Logs"
                };
            }

            var settingsProvider = new JsonSettingsProvider<AppSettings>(settingsPath, defaultAppSettings, new JsonSerializerOptions() { WriteIndented = true });

            services.RegisterLazySingleton<ISettingsProvider<AppSettings>>(() =>
                new JsonSettingsProvider<AppSettings>(settingsPath, defaultAppSettings, new JsonSerializerOptions() { WriteIndented = true }));
        }

        public static void AddLogging(this IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton(() =>
            {
                var settings = Locator.Current.GetService<ISettingsProvider<AppSettings>>();

                var logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.File(Path.Combine(Environment.ExpandEnvironmentVariables(settings.Settings.LogsFolder), "log-.txt"),
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();

                return new SerilogLoggerProvider(logger).CreateLogger(nameof(SampleAvaloniaApplicationClientApplication));
            });
        }

        public static void AddDatabase(this IMutableDependencyResolver services)
        {
            var settingsProvider = Locator.Current.GetService<ISettingsProvider<AppSettings>>();

            var optionsBuilder = new DbContextOptionsBuilder<SampleAvaloniaApplicationClientContext>();
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=" + Environment.ExpandEnvironmentVariables(settingsProvider.Settings.DbFilename), options => options.MigrationsAssembly("SampleAvaloniaApplication.Client.Core.Data"));

            services.Register(() => new SampleAvaloniaApplicationClientContext(optionsBuilder.Options));

            services.RegisterLazySingleton<IDbContextFactory<SampleAvaloniaApplicationClientContext>>(() => new SampleAvaloniaApplicationDbContextFactory());
        }

        public static void AddServices(this IMutableDependencyResolver services)
        {
            services.RegisterLazySingleton<ILoginService>(() =>
            {
                return new LoginService(Locator.Current.GetService<IDbContextFactory<SampleAvaloniaApplicationClientContext>>());
            });

            services.RegisterLazySingleton<IEmployeesService>(() =>
            {
                return new EmployeesService(Locator.Current.GetService<IDbContextFactory<SampleAvaloniaApplicationClientContext>>(), Locator.Current.GetService<IMapper>());
            });
        }

        public static void ConfigureDatabase(this IReadonlyDependencyResolver services)
        {
            var db = services.GetService<SampleAvaloniaApplicationClientContext>();
            db.Database.Migrate();
        }
    }
}
