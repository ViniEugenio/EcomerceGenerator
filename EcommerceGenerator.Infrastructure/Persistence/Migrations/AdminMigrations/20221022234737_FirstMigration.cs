using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceGenerator.Infrastructure.Persistence.Migrations.AdminMigrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(500)", nullable: false),
                    Host = table.Column<string>(type: "varchar(500)", nullable: false),
                    DataBase = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.Sql(@"

                INSERT INTO Client ( Id, Name, Host, [DataBase], CreatedDate, UpdatedDate, Active)
                VALUES ( NewId(), 'LocalClient', 'localhost:3000', 'LocalClientEcommerce', getdate(), getdate(), 1 )

            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
