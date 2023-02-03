using Microsoft.EntityFrameworkCore.Migrations;

namespace DietitianProject.DataAccessLayer.Migrations
{
    public partial class added_column_ImageUrl_DietPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "DietPlans",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "DietPlans");
        }
    }
}
