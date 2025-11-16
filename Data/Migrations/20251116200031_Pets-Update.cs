using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FurByte.Data.Migrations
{
    /// <inheritdoc />
    public partial class PetsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_AspNetUsers_ApplicationUserId",
                table: "UserProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_Products_ProductId",
                table: "UserProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProduct",
                table: "UserProduct");

            migrationBuilder.RenameTable(
                name: "UserProduct",
                newName: "UserProducts");

            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_UserProduct_ProductId",
                table: "UserProducts",
                newName: "IX_UserProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProduct_ApplicationUserId",
                table: "UserProducts",
                newName: "IX_UserProducts_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PetFee",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts",
                column: "UserProductId");

            migrationBuilder.CreateTable(
                name: "RehomeRequests",
                columns: table => new
                {
                    RehomeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NewOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReasonForRehome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RehomeRequests", x => x.RehomeRequestId);
                    table.ForeignKey(
                        name: "FK_RehomeRequests_AspNetUsers_NewOwnerId",
                        column: x => x.NewOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RehomeRequests_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "ApplicationUserId", "Gender", "ImageUrl", "PetFee", "PetName", "PetType", "StatsPetStatsId" },
                values: new object[,]
                {
                    { 1, null, 0, null, 0, "Rudy", "Cat", null },
                    { 2, null, 1, null, 0, "Flower", "Cat", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RehomeRequests_NewOwnerId",
                table: "RehomeRequests",
                column: "NewOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RehomeRequests_OwnerId",
                table: "RehomeRequests",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_AspNetUsers_ApplicationUserId",
                table: "UserProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_AspNetUsers_ApplicationUserId",
                table: "UserProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts");

            migrationBuilder.DropTable(
                name: "RehomeRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts");

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "PetId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetFee",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "UserProducts",
                newName: "UserProduct");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Cost");

            migrationBuilder.RenameIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProduct",
                newName: "IX_UserProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProducts_ApplicationUserId",
                table: "UserProduct",
                newName: "IX_UserProduct_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProduct",
                table: "UserProduct",
                column: "UserProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_AspNetUsers_ApplicationUserId",
                table: "UserProduct",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_Products_ProductId",
                table: "UserProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
