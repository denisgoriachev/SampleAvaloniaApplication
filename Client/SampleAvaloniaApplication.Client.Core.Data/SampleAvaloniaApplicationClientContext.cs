using Microsoft.EntityFrameworkCore;
using SampleAvaloniaApplication.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core.Data
{
    public class SampleAvaloniaApplicationClientContext : DbContext
    {
        public DbSet<ClientEmployee> Employees { get; set; }

        public SampleAvaloniaApplicationClientContext(DbContextOptions<SampleAvaloniaApplicationClientContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientEmployee>()
                .HasData(
                    new ClientEmployee()
                    {
                        Id = Guid.Parse("121DD305-FD55-4FC1-A44B-37B29A70161A"),
                        Email = "administrator@test.com",
                        Username = "administrator",
                        Password = "administrator",
                        IsAcrhived = false,
                        IsRegisteredOnThePortal = false,
                        IsSuperUser = true,
                        Sex = Sex.Male,
                        FirstName = "Admin",
                        MiddleName = "Admin",
                        LastName = "Admin",
                        BirthDate = DateTime.Now
                    });

        }
    }
}
