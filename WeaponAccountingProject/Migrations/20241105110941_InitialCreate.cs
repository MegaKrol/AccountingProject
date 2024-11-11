using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeaponAccountingProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompletenessItem",
                columns: table => new
                {
                    CompletenessItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complete__E27DCAEB0A4440DB", x => x.CompletenessItemId);
                });

            migrationBuilder.CreateTable(
                name: "CompletenessItemWeapon",
                columns: table => new
                {
                    CompletenessItemId = table.Column<int>(type: "int", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletenessItemWeapon", x => new { x.CompletenessItemId, x.WeaponId });
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__E7FEA497D37E3B7E", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Soldier",
                columns: table => new
                {
                    SoldierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Post = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Soldier__7596D901DF73424B", x => x.SoldierId);
                    table.ForeignKey(
                        name: "FK__Soldier__Locatio__693CA210",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    RecordNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SoldierId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Weapon__541D0AF125D9407D", x => x.WeaponId);
                    table.ForeignKey(
                        name: "FK__Weapon__Location__6B24EA82",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK__Weapon__SoldierI__6A30C649",
                        column: x => x.SoldierId,
                        principalTable: "Soldier",
                        principalColumn: "SoldierId");
                });

            migrationBuilder.CreateTable(
                name: "Completeness",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    CompletenessItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Complete__FA3AD65F738CC68B", x => new { x.WeaponId, x.CompletenessItemId });
                    table.ForeignKey(
                        name: "FK__Completen__Compl__4D94879B",
                        column: x => x.CompletenessItemId,
                        principalTable: "CompletenessItem",
                        principalColumn: "CompletenessItemId");
                    table.ForeignKey(
                        name: "FK__Completen__Weapo__4CA06362",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "WeaponId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Completeness_CompletenessItemId",
                table: "Completeness",
                column: "CompletenessItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldier_LocationId",
                table: "Soldier",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_LocationId",
                table: "Weapon",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_SoldierId",
                table: "Weapon",
                column: "SoldierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Completeness");

            migrationBuilder.DropTable(
                name: "CompletenessItemWeapon");

            migrationBuilder.DropTable(
                name: "CompletenessItem");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "Soldier");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
