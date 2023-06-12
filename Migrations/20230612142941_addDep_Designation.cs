using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AhmerMYWebDemo.Migrations
{
    /// <inheritdoc />
    public partial class addDep_Designation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dep_Designation",
                table: "Department",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "No");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dep_Designation",
                table: "Department");
        }
    }
}
