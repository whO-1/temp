using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagement.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePositions",
                columns: table => new
                {
                    StartedFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePositions", x => new { x.EmployeeId, x.PositionId, x.StartedFrom });
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthday", "FullName" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-3333-4444-555555555555"), new DateTime(1990, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ion Ionescu" },
                    { new Guid("a1111111-2222-3333-4444-555555555555"), new DateTime(1990, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana Ixulescu" },
                    { new Guid("a1111111-3333-3333-4444-555555555555"), new DateTime(1990, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iox Axios" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Department", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-3333-4444-555555555555"), "R&D", "Maintain software systems", "Programmer" },
                    { new Guid("b1111111-2222-3333-4444-555555555555"), "HR", "Find right candidates for positions", "Talent Acquisition Manager" },
                    { new Guid("b1111111-3333-3333-4444-555555555555"), "Marketing", "Create new content for social media", "Content Strategist" }
                });

            migrationBuilder.InsertData(
                table: "EmployeePositions",
                columns: new[] { "EmployeeId", "PositionId", "StartedFrom", "EndedAt", "Salary" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-3333-4444-555555555555"), new Guid("b1111111-1111-3333-4444-555555555555"), new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000f },
                    { new Guid("a1111111-2222-3333-4444-555555555555"), new Guid("b1111111-2222-3333-4444-555555555555"), new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000f },
                    { new Guid("a1111111-3333-3333-4444-555555555555"), new Guid("b1111111-3333-3333-4444-555555555555"), new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2000f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePositions_PositionId",
                table: "EmployeePositions",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePositions");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
