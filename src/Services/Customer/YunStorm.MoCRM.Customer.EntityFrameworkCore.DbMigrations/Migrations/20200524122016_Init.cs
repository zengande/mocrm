using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YunStorm.MoCRM.Customer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appcontact_roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appcontact_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appcustomer_levels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appcustomer_levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "appcustomers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 512, nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    CustomerLevelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appcustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appcustomers_appcustomer_levels_CustomerLevelId",
                        column: x => x.CustomerLevelId,
                        principalTable: "appcustomer_levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "appcontacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Department = table.Column<string>(nullable: true),
                    Position = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<byte>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    ContactRoleId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appcontacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appcontacts_appcontact_roles_ContactRoleId",
                        column: x => x.ContactRoleId,
                        principalTable: "appcontact_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_appcontacts_appcustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "appcustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_appcontacts_ContactRoleId",
                table: "appcontacts",
                column: "ContactRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_appcontacts_CustomerId",
                table: "appcontacts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_appcustomers_CustomerLevelId",
                table: "appcustomers",
                column: "CustomerLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appcontacts");

            migrationBuilder.DropTable(
                name: "appcontact_roles");

            migrationBuilder.DropTable(
                name: "appcustomers");

            migrationBuilder.DropTable(
                name: "appcustomer_levels");
        }
    }
}
