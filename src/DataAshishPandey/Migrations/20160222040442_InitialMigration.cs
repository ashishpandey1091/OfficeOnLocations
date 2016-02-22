using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace DataAshishPandey.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    OfficeofficeID = table.Column<int>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StateAbbreviation = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });
            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    officeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationID = table.Column<int>(nullable: true),
                    branchName = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: false),
                    contact = table.Column<int>(nullable: false),
                    departments = table.Column<string>(nullable: true),
                    emailID = table.Column<string>(nullable: true),
                    numberOfEmployees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.officeID);
                    table.ForeignKey(
                        name: "FK_Office_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Location_Office_OfficeofficeID",
                table: "Location",
                column: "OfficeofficeID",
                principalTable: "Office",
                principalColumn: "officeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Office_Location_LocationID", table: "Office");
            migrationBuilder.DropTable("Location");
            migrationBuilder.DropTable("Office");
        }
    }
}
