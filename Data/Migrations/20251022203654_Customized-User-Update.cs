using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurByte.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomizedUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetStats_StatsPetStatsId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_Products_ProductId",
                table: "UserProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Product",
                newName: "IX_Product_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_StatsPetStatsId",
                table: "Pet",
                newName: "IX_Pet_StatsPetStatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ApplicationUserId",
                table: "Pet",
                newName: "IX_Pet_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "PetCoins",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_AspNetUsers_ApplicationUserId",
                table: "Pet",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_PetStats_StatsPetStatsId",
                table: "Pet",
                column: "StatsPetStatsId",
                principalTable: "PetStats",
                principalColumn: "PetStatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_ApplicationUserId",
                table: "Product",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_Product_ProductId",
                table: "UserProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_AspNetUsers_ApplicationUserId",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_PetStats_StatsPetStatsId",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_ApplicationUserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_Product_ProductId",
                table: "UserProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ApplicationUserId",
                table: "Products",
                newName: "IX_Products_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_StatsPetStatsId",
                table: "Pets",
                newName: "IX_Pets_StatsPetStatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_ApplicationUserId",
                table: "Pets",
                newName: "IX_Pets_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "PetCoins",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_AspNetUsers_ApplicationUserId",
                table: "Pets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetStats_StatsPetStatsId",
                table: "Pets",
                column: "StatsPetStatsId",
                principalTable: "PetStats",
                principalColumn: "PetStatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
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
