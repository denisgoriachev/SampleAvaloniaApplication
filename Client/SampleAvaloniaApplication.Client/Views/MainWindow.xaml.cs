using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SampleAvaloniaApplication.Client.Core.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace SampleAvaloniaApplication.Client.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(disposable =>
            {
                Disposable.Create(() => { }).DisposeWith(disposable);
            });

            AvaloniaXamlLoader.Load(this);
#if DEBUG
            this.AttachDevTools();
#endif
        }
    }
}
