using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOIModel.Migrations
{
    public partial class creatingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurances",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearsValid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "IOI",
                columns: table => new
                {
                    IOIid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOI", x => x.IOIid);
                    table.ForeignKey(
                        name: "FK_IOI_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IOI_InsuranceId",
                table: "IOI",
                column: "InsuranceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IOI");

            migrationBuilder.DropTable(
                name: "Insurances");
        }
    }
}
