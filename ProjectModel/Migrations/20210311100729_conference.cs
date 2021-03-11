using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectModel.Migrations
{
    public partial class conference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConferenceId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConferenceId1",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParticipateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ConferenceId",
                table: "AspNetUsers",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ConferenceId1",
                table: "AspNetUsers",
                column: "ConferenceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Conference_ConferenceId",
                table: "AspNetUsers",
                column: "ConferenceId",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Conference_ConferenceId1",
                table: "AspNetUsers",
                column: "ConferenceId1",
                principalTable: "Conference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Conference_ConferenceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Conference_ConferenceId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Conference");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ConferenceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ConferenceId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConferenceId1",
                table: "AspNetUsers");
        }
    }
}
