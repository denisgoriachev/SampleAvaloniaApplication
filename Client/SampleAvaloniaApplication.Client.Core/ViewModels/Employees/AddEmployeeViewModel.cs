using SampleAvaloniaApplication.Client.Core.Models;
using SampleAvaloniaApplication.Client.Core.Services;
using SampleAvaloniaApplication.Common;
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
    public class AddEmployeeViewModel : ViewModelBase<EmployeeModel>, IRoutableViewModel
    {
        private readonly IEmployeesService _employeesService;

        public string UrlPathSegment => nameof(AddEmployeeViewModel);

        public IScreen HostScreen { get; }


        /// <summary>
        /// Temporary big chunk of data
        /// </summary>
        private byte[] Temp = new byte[1024 * 1024 * 20];

        public ReactiveCommand<Unit, Unit> Add { get; }

        public ReactiveCommand<Unit, Unit> Cancel { get;}

        [Reactive] public string UsernameValidation { get; set; }

        [Reactive] public string PasswordValidation { get; set; }

        public AddEmployeeViewModel(IScreen hostScreen, EmployeeModel model, IEmployeesService employeesService) : base(model)
        {
            HostScreen = hostScreen;
            _employeesService = employeesService;

            Add = ReactiveCommand.CreateFromTask(AddImpl, this.IsValid());
            Cancel = HostScreen.Router.NavigateBack;

            this.ValidationRule(vm => vm.Model.Username, name => !string.IsNullOrEmpty(name), "Username is required");
            this.ValidationRule(vm => vm.Model.Username, name => _employeesService.UsernameIsFree(name), "Username is occupied by another user");

            this.ValidationRule(vm => vm.Model.Password, password => !string.IsNullOrEmpty(password), "Password is required");
            this.ValidationRule(vm => vm.Model.BirthDate, birthdate => birthdate.HasValue ? birthdate.Value.Date <= DateTime.Now.Date : true, "Birtday should be less or equal to the current date");

            Add.IsExecuting.ToProperty(this, x => x.IsBusy, out isBusy);

            this.WhenActivated((CompositeDisposable disposables) =>
            {

            });
        }

        public async Task AddImpl()
        {
            var result = await _employeesService.AddAsync(Model);

            if(result.Succeeded)
                HostScreen.Router.NavigateBack.Execute();
        }
    }
}
