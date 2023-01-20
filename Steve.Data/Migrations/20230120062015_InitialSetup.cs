using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Steve.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblOpenAIRequestResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOpenAIRequestResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOpenAIRequestResponse_tblUsers_UserID",
                        column: x => x.UserId,
                        principalTable: "tblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOpenAIRequestResponse_UserId",
                table: "tblOpenAIRequestResponse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_UserName_EmailId",
                table: "tblUsers",
                columns: new[] { "UserName", "EmailId" },
                unique: true,
                filter: "[EmailId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOpenAIRequestResponse");

            migrationBuilder.DropTable(
                name: "tblUsers");
        }
    }
}
