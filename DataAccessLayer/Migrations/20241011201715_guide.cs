using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class guide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsTravels_Guides_GuideGuidID",
                table: "PatientsTravels");

            migrationBuilder.RenameColumn(
                name: "GuideGuidID",
                table: "PatientsTravels",
                newName: "GuideId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientsTravels_GuideGuidID",
                table: "PatientsTravels",
                newName: "IX_PatientsTravels_GuideId");

            migrationBuilder.RenameColumn(
                name: "GuidID",
                table: "Guides",
                newName: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsTravels_Guides_GuideId",
                table: "PatientsTravels",
                column: "GuideId",
                principalTable: "Guides",
                principalColumn: "GuideId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsTravels_Guides_GuideId",
                table: "PatientsTravels");

            migrationBuilder.RenameColumn(
                name: "GuideId",
                table: "PatientsTravels",
                newName: "GuideGuidID");

            migrationBuilder.RenameIndex(
                name: "IX_PatientsTravels_GuideId",
                table: "PatientsTravels",
                newName: "IX_PatientsTravels_GuideGuidID");

            migrationBuilder.RenameColumn(
                name: "GuideId",
                table: "Guides",
                newName: "GuidID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsTravels_Guides_GuideGuidID",
                table: "PatientsTravels",
                column: "GuideGuidID",
                principalTable: "Guides",
                principalColumn: "GuidID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
