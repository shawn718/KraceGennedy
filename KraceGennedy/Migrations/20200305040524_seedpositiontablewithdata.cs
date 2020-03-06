using Microsoft.EntityFrameworkCore.Migrations;

namespace KraceGennedy.Migrations
{
    public partial class seedpositiontablewithdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "PositionDesc", "PositionName" },
                values: new object[,]
                {
                    { 1, null, "ITManager" },
                    { 2, null, "HRManager" },
                    { 3, null, "SecurityManager" },
                    { 4, null, "GeneralManager" },
                    { 5, null, "ITSoftwareDeveloper" },
                    { 6, null, "HREmployee" },
                    { 7, null, "CheifFinancialOfficer" },
                    { 8, null, "CheifExecutiveOfficer" },
                    { 9, null, "CheifOpperationsOfficer" },
                    { 10, null, "RegularEmployee" },
                    { 11, null, "ITSystemAdministrator" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 11);
        }
    }
}
