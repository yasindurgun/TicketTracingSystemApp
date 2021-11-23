using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketTracingSystemApp.Migrations
{
    public partial class _231120211944Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Managers_ManegerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ManegerId",
                table: "Tickets",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ManegerId",
                table: "Tickets",
                newName: "IX_Tickets_ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Managers_ManagerId",
                table: "Tickets",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Managers_ManagerId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Tickets",
                newName: "ManegerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_ManagerId",
                table: "Tickets",
                newName: "IX_Tickets_ManegerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Managers_ManegerId",
                table: "Tickets",
                column: "ManegerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
