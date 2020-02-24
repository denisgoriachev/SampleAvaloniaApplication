using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SampleAvaloniaApplication.Client.Core.ViewModels;
using ReactiveUI;
using System;
using System.Reactive.Disposables;

namespace SampleAvaloniaApplication.Client.Views
{
    public class WorkspaceView : ReactiveUserControl<WorkspaceViewModel>
    {
        public WorkspaceView()
        {
            this.WhenActivated(disposables => {

            });

            AvaloniaXamlLoader.Load(this);
        }
    }
}
