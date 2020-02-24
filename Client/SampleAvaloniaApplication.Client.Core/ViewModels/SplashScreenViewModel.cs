using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client.Core.ViewModels
{
    public class SplashScreenViewModel : ReactiveObject, IActivatableViewModel, IRoutableViewModel
    {
        [Reactive] public string StatusMessage { get; set; } = "Starting ПК МЕДИАС...";

        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        public string UrlPathSegment => nameof(SplashScreenViewModel);

        public IScreen HostScreen { get; }

        public SplashScreenViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;

            this.WhenActivated((CompositeDisposable disposables) =>
            {
                this.StatusMessage = "Starting application...";

                Observable.StartAsync(SetupApplication, RxApp.MainThreadScheduler)
                    .Subscribe(o => HostScreen.Router.NavigateAndReset.Execute(new LoginViewModel(HostScreen)))
                    .DisposeWith(disposables);
            });
        }

        private Task SetupApplication()
        {
            return Task.Run(() =>
            {
                StatusMessage = "Configuring services...";
                
            });
        }
    }
}
