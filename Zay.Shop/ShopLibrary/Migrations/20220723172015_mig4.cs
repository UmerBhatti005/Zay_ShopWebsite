using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopLibrary.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartSystem_AspNetUsers_applicationUserId",
                table: "cartSystem");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "cartSystem",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_cartSystem_applicationUserId",
                table: "cartSystem",
                newName: "IX_cartSystem_Username");

            migrationBuilder.AddForeignKey(
                name: "FK_cartSystem_AspNetUsers_Username",
                table: "cartSystem",
                column: "Username",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cartSystem_AspNetUsers_Username",
                table: "cartSystem");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "cartSystem",
                newName: "applicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_cartSystem_Username",
                table: "cartSystem",
                newName: "IX_cartSystem_applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cartSystem_AspNetUsers_applicationUserId",
                table: "cartSystem",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
