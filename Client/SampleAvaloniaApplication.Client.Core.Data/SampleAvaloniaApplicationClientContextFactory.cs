using SampleAvaloniaApplication.Client.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core
{
    public class SampleAvaloniaApplicationClientContextFactory : IDesignTimeDbContextFactory<SampleAvaloniaApplicationClientContext>
    {
        public SampleAvaloniaApplicationClientContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleAvaloniaApplicationClientContext>();
            optionsBuilder.UseSqlite("Data Source=data.db", options => options.MigrationsAssembly("SampleAvaloniaApplication.Client.Core.Data"));

            return new SampleAvaloniaApplicationClientContext(optionsBuilder.Options);
        }
    }
}
