using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ulubione.Data.Migrations
{
    public partial class Migracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Przepis",
                columns: table => new
                {
                    PrzepisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Nazwa = table.Column<string>(maxLength: 100, nullable: false),
                    ListaSkladnikow = table.Column<string>(maxLength: 100, nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    UName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przepis", x => x.PrzepisId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Przepis");
        }
    }
}
