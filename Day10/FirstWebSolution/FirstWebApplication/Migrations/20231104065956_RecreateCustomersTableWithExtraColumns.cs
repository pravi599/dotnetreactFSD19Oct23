using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebApplication.Migrations
{
    public partial class RecreateCustomersTableWithExtraColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "Customers",
        columns: table => new
        {
            Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
            Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Age = table.Column<int>(type: "int", nullable: false),
            Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Customers", x => x.Email).Annotation("SqlServer:KeyType", "NVarChar(100)");
        });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "Customers");

        }
    }
}
