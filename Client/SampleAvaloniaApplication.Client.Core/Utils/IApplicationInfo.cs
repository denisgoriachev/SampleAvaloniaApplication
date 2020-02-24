using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Utils
{
    public interface IApplicationInfo
    {
        string Name { get; }

        string Organization { get; }

        string Copyright { get; }

        string Version { get; }

        string FileVersion { get; }

        DateTime Created { get; }
    }
}
