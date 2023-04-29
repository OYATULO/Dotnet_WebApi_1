using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_webAPI_USERS.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDB",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDB", x => x.Guid);
                });

            migrationBuilder.InsertData(
                table: "UserDB",
                columns: new[] { "Guid", "Admin", "Birthday", "CreatedBy", "CreatedOn", "Gender", "Login", "ModifiedBy", "ModifiedOn", "Name", "Password", "RevokedBy", "RevokedOn" },
                values: new object[] { new Guid("3a3d2df7-a0e2-44fa-955a-0b878b4ba3ec"), true, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", new DateTime(2023, 4, 26, 21, 25, 29, 283, DateTimeKind.Local).AddTicks(548), 1, "user1", "admin", new DateTime(2023, 4, 26, 21, 25, 29, 283, DateTimeKind.Local).AddTicks(557), "user1", "user1", "admin", new DateTime(2023, 4, 26, 21, 25, 29, 283, DateTimeKind.Local).AddTicks(558) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDB");
        }
    }
}
