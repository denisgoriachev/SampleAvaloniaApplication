using DynamicData;
using SampleAvaloniaApplication.Client.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client.Core.Services
{
    public interface IEmployeesService : IDataService<EmployeeModel, Guid>
    {
        bool UsernameIsFree(string username);
    }
}
