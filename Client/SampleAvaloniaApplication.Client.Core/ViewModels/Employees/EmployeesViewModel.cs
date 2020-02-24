using DynamicData;
using DynamicData.Binding;
using SampleAvaloniaApplication.Client.Core.Models;
using SampleAvaloniaApplication.Client.Core.Services;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.ViewModels.Employees
{
    public class EmployeesViewModel : ReactiveObject, IActivatableViewModel, IRoutableViewModel
    {
        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        public string UrlPathSegment { get; } = nameof(EmployeesViewModel);

        public IScreen HostScreen { get; }

        /// <summary>
        /// Temporary big chunk of data
        /// </summary>
        private byte[] Temp = new byte[1024 * 1024 * 20];

        private ReadOnlyObservableCollection<EmployeeModel> _items;
        public ReadOnlyObservableCollection<EmployeeModel> Items => _items;

        [Reactive] public EmployeeModel SelectedEmployee { get; set; }

        private readonly IEmployeesService _employeesService;

        public ReactiveCommand<Unit, Unit> AddEmployee { get; }

        public ReactiveCommand<Unit, Unit> EditEmployee { get; }

        public EmployeesViewModel(IScreen hostScreen) :
            this(hostScreen, Locator.Current.GetService<IEmployeesService>())
        {

        }

        public EmployeesViewModel(IScreen hostScreen, IEmployeesService employeesService)
        {
            HostScreen = hostScreen;
            _employeesService = employeesService;

            AddEmployee = ReactiveCommand.Create(() => { HostScreen.Router.Navigate.Execute(new AddEmployeeViewModel(HostScreen, new EmployeeModel(), _employeesService)); });

            EditEmployee = ReactiveCommand.Create(() => { HostScreen.Router.Navigate.Execute(new EditEmployeeViewModel(HostScreen, SelectedEmployee, _employeesService)); });

            this.WhenActivated((CompositeDisposable disposables) =>
            {
                _employeesService
                    .Connect()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Bind(out _items)
                    .Subscribe()
                    .DisposeWith(disposables);
            });
        }
    }
}
