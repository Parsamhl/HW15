using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW15.Migrations
{
    /// <inheritdoc />
    public partial class addedwrongpassworrdtries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WrongPassTry",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "ID",
                keyValue: 1,
                column: "WrongPassTry",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "ID",
                keyValue: 2,
                column: "WrongPassTry",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WrongPassTry",
                table: "Cards");
        }
    }
}
