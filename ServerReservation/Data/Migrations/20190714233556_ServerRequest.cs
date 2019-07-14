using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerReservation.Data.Migrations
{
    public partial class ServerRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Hostname = table.Column<string>(nullable: true),
                    HD = table.Column<double>(nullable: true),
                    HDSize = table.Column<int>(nullable: true),
                    RAM = table.Column<double>(nullable: true),
                    RAMSize = table.Column<int>(nullable: true),
                    CPU = table.Column<string>(nullable: true),
                    ServerType = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsNewServer = table.Column<bool>(nullable: false),
                    ServerId = table.Column<int>(nullable: true),
                    RequestedByEmployeeId = table.Column<string>(nullable: true),
                    RequestedByEmployeeName = table.Column<string>(nullable: true),
                    RequestedByUserId = table.Column<string>(nullable: true),
                    RequestJustification = table.Column<string>(nullable: true),
                    ApprovalStatus = table.Column<int>(nullable: true),
                    ApprovedByEmployeeId = table.Column<string>(nullable: true),
                    ApprovedByEmployeeName = table.Column<string>(nullable: true),
                    ApprovedByUserId = table.Column<string>(nullable: true),
                    ApprovalComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_RequestedByUserId",
                        column: x => x.RequestedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ApprovedByUserId",
                table: "Requests",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestedByUserId",
                table: "Requests",
                column: "RequestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServerId",
                table: "Requests",
                column: "ServerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
