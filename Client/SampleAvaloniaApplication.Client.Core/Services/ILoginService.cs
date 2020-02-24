using SampleAvaloniaApplication.Client.Core.Data;
using SampleAvaloniaApplication.Client.Core.Models;
using SampleAvaloniaApplication.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client.Core.Services
{
    public interface ILoginService
    {
        Task<ServiceResult<UserInformationModel>> LoginAsync(ClientMode mode, string username, string password);
    }
}
