using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OVB.Project.Eschody.Monolithic.WebView.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    TypeAccount = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_IDENTIFIER", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Status = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Deadline = table.Column<DateTime>(type: "DATE", nullable: false),
                    CreatedByIdentifier = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSIGNMENT_IDENTIFIER", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_ASSIGNMENTS_ACCOUNT",
                        column: x => x.CreatedByIdentifier,
                        principalTable: "Accounts",
                        principalColumn: "Identifier");
                });

            migrationBuilder.CreateIndex(
                name: "UK_ACCOUNT_EMAIL",
                table: "Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_ACCOUNT_IDENTIFIER",
                table: "Accounts",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_ACCOUNT_USERNAME",
                table: "Accounts",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CreatedByIdentifier",
                table: "Assignments",
                column: "CreatedByIdentifier");

            migrationBuilder.CreateIndex(
                name: "UK_ASSIGNMENT_IDENTIFIER",
                table: "Assignments",
                column: "Identifier",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
