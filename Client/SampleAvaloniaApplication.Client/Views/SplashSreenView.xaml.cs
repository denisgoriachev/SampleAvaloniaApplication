using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SampleAvaloniaApplication.Client.Core.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace SampleAvaloniaApplication.Client.Views
{
    public class SplashSreenView : ReactiveUserControl<SplashScreenViewModel>
    {
        public SplashSreenView()
        {
            this.WhenActivated(disposable =>
            {
                Disposable.Create(() => { }).DisposeWith(disposable);
            });

            AvaloniaXamlLoader.Load(this);
        }
    }
}
