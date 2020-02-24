using SampleAvaloniaApplication.Common;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Models
{
    public class EmployeeModel : ReactiveObject
    {
        [Reactive] public Guid Id { get; set; } = Guid.NewGuid();

        [Reactive] public string Username { get; set; }

        [Reactive] public string Password { get; set; }

        [Reactive] public bool IsRegisteredOnThePortal { get; set; } = false;

        [Reactive] public bool IsSuperUser { get; set; } = false;

        [Reactive] public string FirstName { get; set; }

        [Reactive] public string LastName { get; set; }

        [Reactive] public string MiddleName { get; set; }

        [Reactive] public DateTime? BirthDate { get; set; } = DateTime.Now;

        [Reactive] public Sex Sex { get; set; }

        [Reactive] public string HomeAddress { get; set; }

        [Reactive] public string PrimaryPhone { get; set; }

        [Reactive] public string SecondaryPhone { get; set; }

        [Reactive] public string Email { get; set; }

        [Reactive] public string Comment { get; set; }

        [Reactive] public bool IsAcrhived { get; set; }
    }
}
