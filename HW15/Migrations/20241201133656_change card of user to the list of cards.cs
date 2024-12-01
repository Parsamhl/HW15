using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW15.Migrations
{
    /// <inheritdoc />
    public partial class changecardofusertothelistofcards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cards_UserID",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserID",
                table: "Cards",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cards_UserID",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CardId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CardId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserID",
                table: "Cards",
                column: "UserID",
                unique: true);
        }
    }
}
