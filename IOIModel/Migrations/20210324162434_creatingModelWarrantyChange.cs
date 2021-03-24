using Microsoft.EntityFrameworkCore.Migrations;

namespace IOIModel.Migrations
{
    public partial class creatingModelWarrantyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOI_Insurances_InsuranceId",
                table: "IOI");

            migrationBuilder.DropTable(
                name: "Insurances");

            migrationBuilder.RenameColumn(
                name: "InsuranceId",
                table: "IOI",
                newName: "WarrantyId");

            migrationBuilder.RenameIndex(
                name: "IX_IOI_InsuranceId",
                table: "IOI",
                newName: "IX_IOI_WarrantyId");

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    WarrantyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearsValid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.WarrantyId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IOI_Warranties_WarrantyId",
                table: "IOI",
                column: "WarrantyId",
                principalTable: "Warranties",
                principalColumn: "WarrantyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IOI_Warranties_WarrantyId",
                table: "IOI");

            migrationBuilder.DropTable(
                name: "Warranties");

            migrationBuilder.RenameColumn(
                name: "WarrantyId",
                table: "IOI",
                newName: "InsuranceId");

            migrationBuilder.RenameIndex(
                name: "IX_IOI_WarrantyId",
                table: "IOI",
                newName: "IX_IOI_InsuranceId");

            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsValid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.InsuranceId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IOI_Insurances_InsuranceId",
                table: "IOI",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "InsuranceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
