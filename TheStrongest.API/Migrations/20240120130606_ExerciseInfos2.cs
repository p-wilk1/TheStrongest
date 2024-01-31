using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheStrongest.API.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseInfos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "ExerciseInfos");

            migrationBuilder.DropColumn(
                name: "SecondaryMuscles",
                table: "ExerciseInfos");

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseInfoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructions_ExerciseInfos_ExerciseInfoId",
                        column: x => x.ExerciseInfoId,
                        principalTable: "ExerciseInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SecondaryMuscles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryMuscles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseInfoSecondaryMuscles",
                columns: table => new
                {
                    ExercisesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecondaryMusclesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseInfoSecondaryMuscles", x => new { x.ExercisesId, x.SecondaryMusclesId });
                    table.ForeignKey(
                        name: "FK_ExerciseInfoSecondaryMuscles_ExerciseInfos_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "ExerciseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseInfoSecondaryMuscles_SecondaryMuscles_SecondaryMusclesId",
                        column: x => x.SecondaryMusclesId,
                        principalTable: "SecondaryMuscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseInfoSecondaryMuscles_SecondaryMusclesId",
                table: "ExerciseInfoSecondaryMuscles",
                column: "SecondaryMusclesId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_ExerciseInfoId",
                table: "Instructions",
                column: "ExerciseInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseInfoSecondaryMuscles");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "SecondaryMuscles");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "ExerciseInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryMuscles",
                table: "ExerciseInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
