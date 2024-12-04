using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW15.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Cards_DestinationCardNumberID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Cards_SourceCardNumberId",
                table: "Transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Cards_DestinationCardNumberID",
                table: "Transaction",
                column: "DestinationCardNumberID",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Cards_SourceCardNumberId",
                table: "Transaction",
                column: "SourceCardNumberId",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Cards_DestinationCardNumberID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Cards_SourceCardNumberId",
                table: "Transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Cards_DestinationCardNumberID",
                table: "Transaction",
                column: "DestinationCardNumberID",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Cards_SourceCardNumberId",
                table: "Transaction",
                column: "SourceCardNumberId",
                principalTable: "Cards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
