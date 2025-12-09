using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurByte.Migrations
{
    /// <inheritdoc />
    public partial class SeedPetStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetStats_StatsPetStatsId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_StatsPetStatsId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "StatsPetStatsId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "PetStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PetStats_PetId",
                table: "PetStats",
                column: "PetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetStats_Pets_PetId",
                table: "PetStats",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetStats_Pets_PetId",
                table: "PetStats");

            migrationBuilder.DropIndex(
                name: "IX_PetStats_PetId",
                table: "PetStats");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "PetStats");

            migrationBuilder.AddColumn<int>(
                name: "StatsPetStatsId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 1,
                column: "StatsPetStatsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 2,
                column: "StatsPetStatsId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_StatsPetStatsId",
                table: "Pets",
                column: "StatsPetStatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetStats_StatsPetStatsId",
                table: "Pets",
                column: "StatsPetStatsId",
                principalTable: "PetStats",
                principalColumn: "PetStatsId");
        }
    }
}
