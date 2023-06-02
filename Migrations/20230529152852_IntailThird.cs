using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmerMYWebDemo.Migrations
{
    /// <inheritdoc />
    public partial class IntailThird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblEmployee",
                columns: table => new
                {
                    E_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    E_Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    E_ConfirmPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployee", x => x.E_Id);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EAmount = table.Column<float>(type: "real", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_TblEmployee_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "TblEmployee",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmployeesId",
                table: "Salary",
                column: "EmployeesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "TblEmployee");
        }
    }
}
