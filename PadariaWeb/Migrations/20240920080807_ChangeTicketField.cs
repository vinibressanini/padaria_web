using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PadariaWeb.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTicketField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTicket",
                table: "ProductTicket");

            migrationBuilder.DropIndex(
                name: "IX_ProductTicket_TicketId",
                table: "ProductTicket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTicket",
                table: "ProductTicket",
                columns: new[] { "TicketId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTicket_ProductId",
                table: "ProductTicket",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTicket",
                table: "ProductTicket");

            migrationBuilder.DropIndex(
                name: "IX_ProductTicket_ProductId",
                table: "ProductTicket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTicket",
                table: "ProductTicket",
                columns: new[] { "ProductId", "TicketId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTicket_TicketId",
                table: "ProductTicket",
                column: "TicketId");
        }
    }
}
