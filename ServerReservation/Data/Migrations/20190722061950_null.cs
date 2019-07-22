using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerReservation.Data.Migrations
{
    public partial class @null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Servers",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Servers",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
