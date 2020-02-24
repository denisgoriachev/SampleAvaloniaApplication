using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Services
{
    public interface IDbContextFactory<T> where T : DbContext
    {
        T Create();
    }
}
