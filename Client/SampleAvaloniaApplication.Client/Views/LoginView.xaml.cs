using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using SampleAvaloniaApplication.Client.Core.ViewModels;
using SampleAvaloniaApplication.Common;
using ReactiveUI;
using System.Reactive.Disposables;

namespace SampleAvaloniaApplication.Client.Views
{
    public class LoginView : ReactiveUserControl<LoginViewModel>
    {
        public RadioButton ResearchRadioButton => this.FindControl<RadioButton>(nameof(ResearchRadioButton));

        public RadioButton ConsultationRadioButton => this.FindControl<RadioButton>(nameof(ConsultationRadioButton));

        public RadioButton OfflineRadioButton => this.FindControl<RadioButton>(nameof(OfflineRadioButton));

        public TextBox UsernameTextBox => this.FindControl<TextBox>(nameof(UsernameTextBox));

        public TextBox PasswordTextBox => this.FindControl<TextBox>(nameof(PasswordTextBox));

        public Button LoginButton => this.FindControl<Button>(nameof(LoginButton));

        public Button ExitButton => this.FindControl<Button>(nameof(ExitButton));

        public LoginView()
        {
            this.WhenActivated(disposables => {

            });

            AvaloniaXamlLoader.Load(this);
        }
    }
}
