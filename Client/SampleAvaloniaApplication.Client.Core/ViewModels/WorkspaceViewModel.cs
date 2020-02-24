using SampleAvaloniaApplication.Common;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Splat;
using System.Reactive.Disposables;
using ReactiveUI.Fody.Helpers;
using SampleAvaloniaApplication.Client.Core.Services;
using SampleAvaloniaApplication.Client.Core.ViewModels.Employees;
using SampleAvaloniaApplication.Client.Core.ViewModels;
using SampleAvaloniaApplication.Client.Core.Models;

namespace SampleAvaloniaApplication.Client.Core.ViewModels
{
    public class WorkspaceViewModel : ViewModelBase, IScreen, IRoutableViewModel
    {
        public string UrlPathSegment => nameof(WorkspaceViewModel);

        public IScreen HostScreen { get; }

        public RoutingState Router { get; } = new RoutingState();

        public UserInformationModel UserInformation { get; }

        [Reactive] public ReactiveCommand<Unit, Unit> Logout { get; set; }

        public WorkspaceViewModel(IScreen screen, UserInformationModel userInformation)
        {
            HostScreen = screen;
            UserInformation = userInformation;

            Logout = ReactiveCommand.Create(() => { HostScreen.Router.NavigateAndReset.Execute(new LoginViewModel(HostScreen)); });
            Router.Navigate.Execute(new EmployeesViewModel(this));

            this.WhenActivated((CompositeDisposable disposables) =>
            {

            });
        }
    }
}
