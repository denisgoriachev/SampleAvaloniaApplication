using SampleAvaloniaApplication.Client.Core.Services;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client
{
    public static class ApplicationConfigurator
    {
        public static void ConfigureServices(
            IMutableDependencyResolver services, IApplication app)
        {
            services.AddApplication(app);
            services.AddApplicationInfo();
            services.AddSettingsProvider();
            services.AddLogging();
            services.AddDatabase();
            services.AddAutomapper();
            services.AddServices();
        }

        public static void Configure(IReadonlyDependencyResolver services)
        {
            services.ConfigureDatabase();
        }
    }
}
