using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VisitorManagmentSystem.Migrations
{
    public partial class VIsitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staffnames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffnames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastNAme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Business = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dateout = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffNameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_Staffnames_StaffNameId",
                        column: x => x.StaffNameId,
                        principalTable: "Staffnames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_StaffNameId",
                table: "Visitors",
                column: "StaffNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Staffnames");
        }
    }
}
