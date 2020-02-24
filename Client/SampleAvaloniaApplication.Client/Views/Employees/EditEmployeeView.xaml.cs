using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SampleAvaloniaApplication.Client.Controls;
using SampleAvaloniaApplication.Client.Core.ViewModels.Employees;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using System.Reactive.Disposables;

namespace SampleAvaloniaApplication.Client.Views.Employees
{
    public class EditEmployeeView : ReactiveUserControl<EditEmployeeViewModel>
    {
        public MultilineTextBlock UsernameValidation => this.FindControl<MultilineTextBlock>(nameof(UsernameValidation));

        public TextBlock PasswordValidation => this.FindControl<TextBlock>(nameof(PasswordValidation));

        public TextBlock BirthDateValidation => this.FindControl<TextBlock>(nameof(BirthDateValidation));

        public DatePicker BirthDateDatePicker => this.FindControl<DatePicker>(nameof(BirthDateDatePicker));

        public EditEmployeeView()
        {
            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, vm => vm.Model.BirthDate, v => v.BirthDateDatePicker.SelectedDate)
                    .DisposeWith(disposable);

                this.BindValidationEx(ViewModel, vm => vm.Model.Username, v => v.UsernameValidation.Lines)
                    .DisposeWith(disposable);

                this.BindValidation(ViewModel, vm => vm.Model.Password, v => v.PasswordValidation.Text)
                    .DisposeWith(disposable);

                this.BindValidation(ViewModel, vm => vm.Model.BirthDate, v => v.BirthDateValidation.Text)
                    .DisposeWith(disposable);
            });

            AvaloniaXamlLoader.Load(this);
        }
    }
}
