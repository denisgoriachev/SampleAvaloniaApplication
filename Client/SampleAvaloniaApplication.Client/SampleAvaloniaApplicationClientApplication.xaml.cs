using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SampleAvaloniaApplication.Client.Converters;
using SampleAvaloniaApplication.Client.Core.Services;
using SampleAvaloniaApplication.Client.Core.ViewModels;
using SampleAvaloniaApplication.Client.Views;
using SampleAvaloniaApplication.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReactiveUI;
using Splat;
using System;
using System.IO;
using System.Text.Json;

namespace SampleAvaloniaApplication.Client
{
    public class SampleAvaloniaApplicationClientApplication : Application, IApplication
    {
        public override void Initialize()
        {
            ApplicationConfigurator.ConfigureServices(Locator.CurrentMutable, this);

            var logger = Locator.Current.GetService<Microsoft.Extensions.Logging.ILogger>();
            logger.LogInformation("Starting aplication...");
            ApplicationConfigurator.Configure(Locator.Current);
            logger.LogInformation("Services configured!");

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var viewModel = new MainWindowViewModel();

                desktop.MainWindow = new MainWindow()
                {
                    DataContext = viewModel
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        public void Shutdown()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }
    }
}
