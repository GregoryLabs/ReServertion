using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerReservation.Data.Migrations
{
    public partial class ServerQualifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cores",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Justification",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Servers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Cores",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "Justification",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Servers");
        }
    }
}
