using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAutomation.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyNameToJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1c47462-4189-4de0-ab21-d4217ee9d633"));

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Jobs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Jobs");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PreferredTone", "ResumePath" },
                values: new object[] { new Guid("f1c47462-4189-4de0-ab21-d4217ee9d633"), new DateTime(2026, 1, 3, 10, 27, 53, 953, DateTimeKind.Utc).AddTicks(3528), "sanskarbosmia@gmail.com", "Sanskar Bosmia", "professional", "Full Stack Developer specializing in Angular and .NET with expertise in building high-performance REST APIs, advanced analytical dashboards, and scalable fintech applications. Experienced in Clean Architecture, Entity Framework Core, SQL optimization, and Azure cloud deployment." });
        }
    }
}
