using SampleAvaloniaApplication.Client.Core.Models;
using SampleAvaloniaApplication.Client.Core.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client.Core.ViewModels.Employees
{
    public class EditEmployeeViewModel : ViewModelBase<EmployeeModel>, IRoutableViewModel
    {
        public string UrlPathSegment => nameof(EditEmployeeViewModel);

        public IScreen HostScreen { get; }

        private readonly IEmployeesService _employeesService;

        /// <summary>
        /// Temporary big chunk of data
        /// </summary>
        private byte[] Temp = new byte[1024 * 1024 * 20];

        [Reactive] public ReactiveCommand<Unit, Unit> Save { get; set; }

        [Reactive] public ReactiveCommand<Unit, Unit> Cancel { get; set; }

        private readonly string _originalUserName;

        public EditEmployeeViewModel(IScreen hostScreen, EmployeeModel model, IEmployeesService service) : base(model)
        {
            HostScreen = hostScreen;
            _employeesService = service;

            _originalUserName = model.Username;

            this.ValidationRule(vm => vm.Model.Username, name => !string.IsNullOrEmpty(name), "Username is required");
            this.ValidationRule(vm => vm.Model.Username, name => name == _originalUserName || Model.IsRegisteredOnThePortal || _employeesService.UsernameIsFree(name), "Username is occupied by another user");

            this.ValidationRule(vm => vm.Model.Password, password => !string.IsNullOrEmpty(password), "Password is required");
            this.ValidationRule(vm => vm.Model.BirthDate, birthdate => birthdate.HasValue ? birthdate.Value.Date <= DateTime.Now.Date : true, "Birtday should be less or equal to the current date");

            Save = ReactiveCommand.CreateFromTask(SaveImplementation, this.IsValid());
            Cancel = HostScreen.Router.NavigateBack;

            Save.IsExecuting.ToProperty(this, x => x.IsBusy, out isBusy);

            this.WhenActivated((CompositeDisposable disposables) =>
            {

            });
        }

        public async Task SaveImplementation()
        {
            var result = await _employeesService.UpdateAsync(Model);
        }
    }
}
