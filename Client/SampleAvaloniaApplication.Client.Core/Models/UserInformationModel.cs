using SampleAvaloniaApplication.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Models
{
    public class UserInformationModel
    {
        public ClientMode ClientMode { get; set; }

        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public bool IsSuperUser { get; set; }
    }
}
