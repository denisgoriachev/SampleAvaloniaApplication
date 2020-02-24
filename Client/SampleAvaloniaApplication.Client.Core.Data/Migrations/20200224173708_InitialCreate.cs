using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleAvaloniaApplication.Client.Core.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    HomeAddress = table.Column<string>(maxLength: 1024, nullable: true),
                    PrimaryPhone = table.Column<string>(maxLength: 128, nullable: true),
                    SecondaryPhone = table.Column<string>(maxLength: 128, nullable: true),
                    Email = table.Column<string>(maxLength: 512, nullable: true),
                    Comment = table.Column<string>(maxLength: 4096, nullable: true),
                    IsAcrhived = table.Column<bool>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    IsRegisteredOnThePortal = table.Column<bool>(nullable: false),
                    IsSuperUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Comment", "Email", "FirstName", "HomeAddress", "IsAcrhived", "IsRegisteredOnThePortal", "IsSuperUser", "LastName", "MiddleName", "Password", "PrimaryPhone", "SecondaryPhone", "Sex", "Username" },
                values: new object[] { new Guid("121dd305-fd55-4fc1-a44b-37b29a70161a"), new DateTime(2020, 2, 24, 20, 37, 8, 736, DateTimeKind.Local).AddTicks(2855), null, "administrator@test.com", "Admin", null, false, false, true, "Admin", "Admin", "administrator", null, null, 0, "administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
