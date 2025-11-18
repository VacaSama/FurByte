using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurByte.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataaseUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdopted",
                table: "Pets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 1,
                columns: new[] { "IsAdopted", "PetFee" },
                values: new object[] { false, 150 });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 2,
                columns: new[] { "IsAdopted", "PetFee" },
                values: new object[] { false, 150 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdopted",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 1,
                column: "PetFee",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 2,
                column: "PetFee",
                value: 0);
        }
    }
}
