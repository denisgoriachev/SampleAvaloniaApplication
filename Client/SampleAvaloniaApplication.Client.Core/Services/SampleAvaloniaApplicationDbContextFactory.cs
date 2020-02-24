using SampleAvaloniaApplication.Client.Core.Data;
using Microsoft.EntityFrameworkCore;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Services
{
    public class SampleAvaloniaApplicationDbContextFactory : IDbContextFactory<SampleAvaloniaApplicationClientContext>
    {
        public SampleAvaloniaApplicationClientContext Create()
        {
            return Locator.Current.GetService<SampleAvaloniaApplicationClientContext>();
        }
    }
}
