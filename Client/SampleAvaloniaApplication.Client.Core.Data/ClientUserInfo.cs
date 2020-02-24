using SampleAvaloniaApplication.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Data
{
    public class ClientUserInfo
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.Now;

        public Sex Sex { get; set; }

        [MaxLength(1024)]
        public string HomeAddress { get; set; }

        [MaxLength(128)]
        public string PrimaryPhone { get; set; }

        [MaxLength(128)]
        public string SecondaryPhone { get; set; }

        [MaxLength(512)]
        public string Email { get; set; }

        [MaxLength(4096)]
        public string Comment { get; set; }

        public bool IsAcrhived { get; set; }
    }
}
