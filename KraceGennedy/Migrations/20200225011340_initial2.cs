using Microsoft.EntityFrameworkCore.Migrations;

namespace KraceGennedy.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", nullable: true),
                    Branch = table.Column<string>(type: "varchar(25)", nullable: true),
                    City = table.Column<string>(type: "varchar(20)", nullable: true),
                    Country = table.Column<string>(type: "varchar(25)", nullable: true),
                    DOB = table.Column<string>(type: "varchar(35)", nullable: false),
                    Email = table.Column<string>(type: "varchar(15)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(15)", nullable: false),
                    Role = table.Column<string>(type: "varchar(1)", nullable: true),
                    Telephone = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });
        }
    }
}
