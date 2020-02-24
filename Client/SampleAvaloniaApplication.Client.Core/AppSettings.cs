using SampleAvaloniaApplication.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core
{
    public class AppSettings
    {
        public Guid ApplicationId { get; set; } = Guid.NewGuid();

        public string LogsFolder { get; set; } = "%APPDATA%\\SampleAvaloniaApplicationClient\\Logs";

        public string DbFilename { get; set; } = "%APPDATA%\\SampleAvaloniaApplicationClient\\data.db";

        public ClientMode ClientMode { get; set; }
    }
}
