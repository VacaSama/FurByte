using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FurByte.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingCascadeRehomeRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_NewOwnerId",
                table: "RehomeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_OwnerId",
                table: "RehomeRequests");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ApplicationUserId", "Category", "Description", "ImageUrl", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, null, "Pet Food", "Basic pet food, cheap and filling. For all pet types", "~/images/products/petfood_basic.png", 50, "Generic Pet Food" },
                    { 2, null, "Treats", "These awesome treats bring all the pets to the yard...seriously where did they come from.", "~/images/products/treats_golden.png", 75, "Golden Boy'o Biscuits" },
                    { 3, null, "Toys", "Creepy but squeaky!", "~/images/products/squeakytoy_used.png", 45, "Used Squeaky Toy" },
                    { 4, null, "Hygiene", "Keeps your pet shiny and clean.", "~/images/products/pet_shampoo.png", 75, "Pet Shampoo" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_NewOwnerId",
                table: "RehomeRequests",
                column: "NewOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_OwnerId",
                table: "RehomeRequests",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_NewOwnerId",
                table: "RehomeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_OwnerId",
                table: "RehomeRequests");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_NewOwnerId",
                table: "RehomeRequests",
                column: "NewOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RehomeRequests_AspNetUsers_OwnerId",
                table: "RehomeRequests",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
