using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsTravels_Tickets_TicketID",
                table: "PatientsTravels");

            migrationBuilder.DropIndex(
                name: "IX_PatientsTravels_TicketID",
                table: "PatientsTravels");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "PatientsTravels");

            migrationBuilder.AddColumn<int>(
                name: "PatientsTravelId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PatientsTravelId",
                table: "Tickets",
                column: "PatientsTravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PatientsTravels_PatientsTravelId",
                table: "Tickets",
                column: "PatientsTravelId",
                principalTable: "PatientsTravels",
                principalColumn: "PatientsTravelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PatientsTravels_PatientsTravelId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_PatientsTravelId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "PatientsTravelId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "PatientsTravels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientsTravels_TicketID",
                table: "PatientsTravels",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsTravels_Tickets_TicketID",
                table: "PatientsTravels",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
