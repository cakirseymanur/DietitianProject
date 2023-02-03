using Microsoft.EntityFrameworkCore.Migrations;

namespace DietitianProject.DataAccessLayer.Migrations
{
    public partial class added_column_Status_DietPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "DietPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "DietPlans");
        }
    }
}
