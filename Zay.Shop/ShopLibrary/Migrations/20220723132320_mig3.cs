using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "cartSystem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cartSystem_applicationUserId",
                table: "cartSystem",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartSystem_AspNetUsers_applicationUserId",
                table: "cartSystem",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartSystem_AspNetUsers_applicationUserId",
                table: "cartSystem");

            migrationBuilder.DropIndex(
                name: "IX_cartSystem_applicationUserId",
                table: "cartSystem");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "cartSystem");
        }
    }
}
