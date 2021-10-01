using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_LEG.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_ClientUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_RestaurantUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientUserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RestaurantUserId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestaurantUserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "RestaurantUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_RestaurantUserId");

            migrationBuilder.AddColumn<int>(
                name: "ClientUserId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientUserId",
                table: "Orders",
                column: "ClientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_ClientUserId",
                table: "Orders",
                column: "ClientUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_RestaurantUserId",
                table: "Orders",
                column: "RestaurantUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
