using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using SampleAvaloniaApplication.Common;
using System.Reactive;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reactive.Disposables;
using Splat;
using ReactiveUI.Fody.Helpers;
using System.Threading;
using SampleAvaloniaApplication.Client.Core.Data;
using SampleAvaloniaApplication.Client.Core.Utils;
using SampleAvaloniaApplication.Client.Core.Services;
using System.Reactive.Linq;
using System.Linq;

namespace SampleAvaloniaApplication.Client.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase, IRoutableViewModel
    {
        private IApplicationInfo _applicationInfo;
        private ILoginService _loginService;
        private ISettingsProvider<AppSettings> _settingsProvider;

        public IScreen HostScreen { get; }

        public string UrlPathSegment { get; } = "Login";

        [Reactive] public string Username { get; set; }

        [Reactive] public string Password { get; set; }

        [Reactive] public ClientMode ClientMode { get; set; }

        [Reactive] public string ErrorMessage { get; set; }

        public string Version => string.Format("Version {0}", _applicationInfo.Version);

        public string DevelopedBy => string.Format("Developed by {0}. {1}.",
            _applicationInfo.Organization,
            _applicationInfo.Created.Year);

        public ReactiveCommand<Unit, Unit> Login { get; }

        public ReactiveCommand<Unit, Unit> Exit { get; }

        public LoginViewModel(IScreen screen) : 
            this(screen, 
                Locator.Current.GetService<ILoginService>(),
                Locator.Current.GetService<IApplicationInfo>(),
                Locator.Current.GetService<ISettingsProvider<AppSettings>>())
        {

        }

        public LoginViewModel(IScreen screen, ILoginService loginService, IApplicationInfo applicationInfo, ISettingsProvider<AppSettings> settingsProvider)
        {
            HostScreen = screen;
            _loginService = loginService;
            _applicationInfo = applicationInfo;
            _settingsProvider = settingsProvider;

            ClientMode = _settingsProvider.Settings.ClientMode;

#if DEBUG
            Username = "administrator";
            Password = "administrator";
#endif

            var canLogin = this.WhenAnyValue(vm => vm.Username, vm => vm.Password,
                (userName, password) =>
                    !string.IsNullOrEmpty(userName) &&
                    !string.IsNullOrEmpty(password));

            Login = ReactiveCommand.CreateFromTask(LoginAsync, canLogin);
            Exit = ReactiveCommand.Create(ExitApplication);

            Login.IsExecuting.ToProperty(this, x => x.IsBusy, out isBusy);

            this.WhenActivated((CompositeDisposable disposables) =>
            {
                // Added here just for testing
                GC.Collect();
            });
        }

        public async Task LoginAsync()
        {
            _settingsProvider.Settings.ClientMode = ClientMode;
            _settingsProvider.Save();

            var result = await _loginService.LoginAsync(ClientMode, Username, Password);

            if(!result.Succeeded)
            {
                ErrorMessage = result.Errors.First().Message;
                return;
            }

            await HostScreen.Router.NavigateAndReset.Execute(new WorkspaceViewModel(HostScreen, result.Data));
        }

        private void ExitApplication()
        {
            Locator.Current.GetService<IApplication>().Shutdown();
        }
    }
}
