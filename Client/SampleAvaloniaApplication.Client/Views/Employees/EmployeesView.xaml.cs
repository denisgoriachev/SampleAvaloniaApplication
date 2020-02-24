using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SampleAvaloniaApplication.Client.Core.ViewModels.Employees;
using ReactiveUI;
using System.Reactive.Disposables;

namespace SampleAvaloniaApplication.Client.Views.Employees
{
    public class EmployeesView : ReactiveUserControl<EmployeesViewModel>
    {
        public DataGrid EmployeesDataGrid => this.FindControl<DataGrid>(nameof(EmployeesDataGrid));

        public Button AddEmployeeButton => this.FindControl<Button>(nameof(AddEmployeeButton));

        public EmployeesView()
        {
            this.WhenActivated(disposable =>
            {
                this.BindCommand(ViewModel, vm => vm.AddEmployee, v => v.AddEmployeeButton)
                    .DisposeWith(disposable);

                this.OneWayBind(ViewModel, vm => vm.Items, v => v.EmployeesDataGrid.Items)
                    .DisposeWith(disposable);

                this.Bind(ViewModel, vm => vm.SelectedEmployee, v => v.EmployeesDataGrid.SelectedItem)
                    .DisposeWith(disposable);
            });

            AvaloniaXamlLoader.Load(this);
        }
    }
}
