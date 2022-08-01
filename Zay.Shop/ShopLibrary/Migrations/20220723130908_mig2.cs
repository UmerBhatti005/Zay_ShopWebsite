using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_colorsId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colors",
                table: "colors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "cartSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    productSizeId = table.Column<int>(type: "int", nullable: true),
                    colorsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartSystem_colors_colorsId",
                        column: x => x.colorsId,
                        principalTable: "colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cartSystem_ProductSizes_productSizeId",
                        column: x => x.productSizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartSystem_colorsId",
                table: "cartSystem",
                column: "colorsId");

            migrationBuilder.CreateIndex(
                name: "IX_cartSystem_productSizeId",
                table: "cartSystem",
                column: "productSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_colors_colorsId",
                table: "Products",
                column: "colorsId",
                principalTable: "colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_colors_colorsId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "cartSystem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colors",
                table: "colors");

            migrationBuilder.RenameTable(
                name: "colors",
                newName: "Colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_colorsId",
                table: "Products",
                column: "colorsId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
