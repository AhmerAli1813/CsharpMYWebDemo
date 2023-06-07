using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmerMYWebDemo.Migrations
{
    /// <inheritdoc />
    public partial class addDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Dep_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Dep_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Dep_Id);
                    table.ForeignKey(
                        name: "FK_Department_TblEmployee_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "TblEmployee",
                        principalColumn: "E_Id",
                        onDelete: ReferentialAction.Cascade);
                        
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_EmployeesId",
                table: "Department",
                column: "EmployeesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
