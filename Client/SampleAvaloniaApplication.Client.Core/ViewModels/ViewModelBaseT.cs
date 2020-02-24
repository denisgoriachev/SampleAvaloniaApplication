using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.ViewModels
{
    public class ViewModelBase<TModel> : ViewModelBase
    {
        [Reactive] public TModel Model { get; set; }

        public ViewModelBase(TModel model)
        {
            Model = model;
        }
    }
}
