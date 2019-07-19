using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerReservation.Data.Migrations
{
    public partial class ServerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DHCPServer",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DHCPServer2",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNSDomain",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNSServer",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNSServer2",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultGateway",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultGateway2",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPv4Address",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPv4Address2",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPv6Address",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IPv6Address2",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogonDomain",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogonServer",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MACAddress",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MACAddress2",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MachineDomain",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkCard",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkSpeed",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkType",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OSVersion",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicePack",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubnetMask",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubnetMask2",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemType",
                table: "Servers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WindowsDomain",
                table: "Servers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DHCPServer",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "DHCPServer2",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "DNSDomain",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "DNSServer",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "DNSServer2",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "DefaultGateway",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "DefaultGateway2",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "IPv4Address",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "IPv4Address2",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "IPv6Address",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "IPv6Address2",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "LogonDomain",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "LogonServer",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "MACAddress",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "MACAddress2",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "MachineDomain",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "NetworkCard",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "NetworkSpeed",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "NetworkType",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "OSVersion",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "ServicePack",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "SubnetMask",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "SubnetMask2",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "SystemType",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "WindowsDomain",
                table: "Servers");
        }
    }
}
