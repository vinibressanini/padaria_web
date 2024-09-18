using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PadariaWeb.Migrations
{
    /// <inheritdoc />
    public partial class NewPaymentField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "PaymenyMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "PaymenyMethod");
        }
    }
}
