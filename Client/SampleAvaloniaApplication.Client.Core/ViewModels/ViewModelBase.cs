using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.ViewModels
{
    public class ViewModelBase : ReactiveObject, IActivatableViewModel, IValidatableViewModel
    {
        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        public ValidationContext ValidationContext { get; } = new ValidationContext();

        protected ObservableAsPropertyHelper<bool> isBusy;
        public bool IsBusy { get { return isBusy.Value; } }
    }
}
