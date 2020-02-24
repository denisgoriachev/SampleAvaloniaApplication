using SampleAvaloniaApplication.Client.Core.Data;
using SampleAvaloniaApplication.Client.Core.Models;
using SampleAvaloniaApplication.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDbContextFactory<SampleAvaloniaApplicationClientContext> _contextFactory;

        public LoginService(IDbContextFactory<SampleAvaloniaApplicationClientContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<ServiceResult<UserInformationModel>> LoginAsync(ClientMode mode, string username, string password)
        {
            return Task.Run(() =>
            {
                if (mode == ClientMode.Offline)
                {
                    using (var context = _contextFactory.Create())
                    {
                        var userInfo = context.Employees.FirstOrDefault(e => e.Username == username);

                        if (userInfo == null || userInfo?.Password != password)
                        {
                            return ServiceResult<UserInformationModel>.Fail("Incorrect username/password");
                        }

                        return ServiceResult.Ok(new UserInformationModel()
                        {
                            ClientMode = mode,
                            FullName = $"{userInfo.LastName} {userInfo.FirstName} {userInfo.MiddleName}",
                            IsSuperUser = userInfo.IsSuperUser,
                            UserId = userInfo.Id
                        });
                    }
                }

                return ServiceResult<UserInformationModel>.Fail("Unsupported client mode login method");
            }); 
        }
    }
}
