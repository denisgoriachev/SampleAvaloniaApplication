using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Common
{
    public interface ISettingsProvider<T>
    {
        T Settings { get; }

        void Save();
    }
}
