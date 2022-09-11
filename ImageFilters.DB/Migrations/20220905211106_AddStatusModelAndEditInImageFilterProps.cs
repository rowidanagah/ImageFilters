using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageFilters.DB.Migrations
{
    public partial class AddStatusModelAndEditInImageFilterProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ImageFilters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageFilters_StatusId",
                table: "ImageFilters",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageFilters_Statuses_StatusId",
                table: "ImageFilters",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageFilters_Statuses_StatusId",
                table: "ImageFilters");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_ImageFilters_StatusId",
                table: "ImageFilters");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ImageFilters");
        }
    }
}
