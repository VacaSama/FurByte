using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FurByte.Migrations
{
    /// <inheritdoc />
    public partial class StatsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PetStats",
                columns: new[] { "PetStatsId", "Energy", "Happiness", "Hunger", "Hygiene", "LastUpdated", "PetId", "PetMood" },
                values: new object[,]
                {
                    { 1, 75, 50, 50, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 2, 75, 75, 50, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetStats",
                keyColumn: "PetStatsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetStats",
                keyColumn: "PetStatsId",
                keyValue: 2);
        }
    }
}
