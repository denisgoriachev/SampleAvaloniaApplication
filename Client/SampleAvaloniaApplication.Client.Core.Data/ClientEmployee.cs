using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Data
{
    public class ClientEmployee : ClientUserInfo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        public bool IsRegisteredOnThePortal { get; set; } = false;

        public bool IsSuperUser { get; set; } = false;
    }
}
