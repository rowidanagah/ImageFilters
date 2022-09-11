using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageFilters.DB.Migrations
{
    public partial class SeedStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "Statuses",
           columns: new[] { "Id", "Name" },
           values: new object[] { 1, "Draft" }
           );

            migrationBuilder.InsertData(
            table: "Statuses",
            columns: new[] { "Id", "Name" },
            values: new object[] { 2, "Published" }
            );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Statuses] ");
        }
    }
}
