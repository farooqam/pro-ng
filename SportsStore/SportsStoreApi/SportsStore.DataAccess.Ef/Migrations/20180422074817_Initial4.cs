using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SportsStoreApi.DataAccess.Ef.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorization_Categories_CategoryName",
                table: "ProductCategorization");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorization_Products_ProductId",
                table: "ProductCategorization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategorization",
                table: "ProductCategorization");

            migrationBuilder.RenameTable(
                name: "ProductCategorization",
                newName: "ProductCategorizations");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategorization_ProductId",
                table: "ProductCategorizations",
                newName: "IX_ProductCategorizations_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategorizations",
                table: "ProductCategorizations",
                columns: new[] { "CategoryName", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorizations_Categories_CategoryName",
                table: "ProductCategorizations",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorizations_Products_ProductId",
                table: "ProductCategorizations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorizations_Categories_CategoryName",
                table: "ProductCategorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorizations_Products_ProductId",
                table: "ProductCategorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategorizations",
                table: "ProductCategorizations");

            migrationBuilder.RenameTable(
                name: "ProductCategorizations",
                newName: "ProductCategorization");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategorizations_ProductId",
                table: "ProductCategorization",
                newName: "IX_ProductCategorization_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategorization",
                table: "ProductCategorization",
                columns: new[] { "CategoryName", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorization_Categories_CategoryName",
                table: "ProductCategorization",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorization_Products_ProductId",
                table: "ProductCategorization",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
