using System;
using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;
using SampleAvaloniaApplication.Client.Views;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using Serilog.Filters;
using Splat;
using Avalonia.Controls;

namespace SampleAvaloniaApplication.Client
{
    class Program
    {
        public static int Main(string[] args)
        {
            return BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());

            var result = AppBuilder.Configure<SampleAvaloniaApplicationClientApplication>()
                  .UsePlatformDetect()
                  .LogToDebug()
                  .UseReactiveUI();

            return result;
        }
    }
}
