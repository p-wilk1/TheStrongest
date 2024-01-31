﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheStrongest.API.Migrations
{
    /// <inheritdoc />
    public partial class Userid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Trainings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trainings");
        }
    }
}
