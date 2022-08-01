using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ratings_Products_productsId",
                table: "ratings");

            migrationBuilder.DropIndex(
                name: "IX_ratings_productsId",
                table: "ratings");

            migrationBuilder.DropColumn(
                name: "productsId",
                table: "ratings");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ratings_productId",
                table: "ratings",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_Products_productId",
                table: "ratings",
                column: "productId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ratings_Products_productId",
                table: "ratings");

            migrationBuilder.DropIndex(
                name: "IX_ratings_productId",
                table: "ratings");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "ratings");

            migrationBuilder.AddColumn<int>(
                name: "productsId",
                table: "ratings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ratings_productsId",
                table: "ratings",
                column: "productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ratings_Products_productsId",
                table: "ratings",
                column: "productsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
