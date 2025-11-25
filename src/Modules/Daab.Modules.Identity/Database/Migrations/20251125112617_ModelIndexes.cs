using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Daab.Modules.Identity.Database.Migrations
{
    /// <inheritdoc />
    public partial class ModelIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "user_email_idx",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "country_name_idx",
                table: "Countries",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "user_email_idx",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "country_name_idx",
                table: "Countries");
        }
    }
}
