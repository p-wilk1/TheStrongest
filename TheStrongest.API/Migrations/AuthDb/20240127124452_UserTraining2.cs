using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheStrongest.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class UserTraining2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Training");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Training",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
