using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeaponAccountingProject.Migrations
{
    /// <inheritdoc />
    public partial class AddOfficer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficerSoldierId",
                table: "Soldier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficerSoldierId",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    SoldierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Soldier__7596D901DF73424C", x => x.SoldierId);
                    table.ForeignKey(
                        name: "FK_Officer_Soldier_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldier",
                        principalColumn: "SoldierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_OfficerSoldierId",
                table: "Soldier",
                column: "OfficerSoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_OfficerSoldierId",
                table: "Location",
                column: "OfficerSoldierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Officer_OfficerSoldierId",
                table: "Location",
                column: "OfficerSoldierId",
                principalTable: "Officer",
                principalColumn: "SoldierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldier_Officer_OfficerSoldierId",
                table: "Soldier",
                column: "OfficerSoldierId",
                principalTable: "Officer",
                principalColumn: "SoldierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Officer_OfficerSoldierId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldier_Officer_OfficerSoldierId",
                table: "Soldier");

            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropIndex(
                name: "IX_Soldier_OfficerSoldierId",
                table: "Soldier");

            migrationBuilder.DropIndex(
                name: "IX_Location_OfficerSoldierId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "OfficerSoldierId",
                table: "Soldier");

            migrationBuilder.DropColumn(
                name: "OfficerSoldierId",
                table: "Location");
        }
    }
}
