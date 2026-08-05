using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftMaintenanceOperations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentCounters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Users_TechnicianId",
                table: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "TechnicianId",
                table: "WorkOrders",
                newName: "AssignedTechnicianId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "WorkOrders",
                newName: "WorkOrderStatus");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_TechnicianId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_AssignedTechnicianId");

            migrationBuilder.AddColumn<Guid>(
                name: "AircraftId",
                table: "WorkOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceNumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkOrderNumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkOrderPriority",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaintenanceRequestCounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CurrentNumber = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRequestCounters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderCounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CurrentNumber = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderCounters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequestCounters_Year",
                table: "MaintenanceRequestCounters",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderCounters_Year",
                table: "WorkOrderCounters",
                column: "Year",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Users_AssignedTechnicianId",
                table: "WorkOrders",
                column: "AssignedTechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Users_AssignedTechnicianId",
                table: "WorkOrders");

            migrationBuilder.DropTable(
                name: "MaintenanceRequestCounters");

            migrationBuilder.DropTable(
                name: "WorkOrderCounters");

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "MaintenanceNumber",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "WorkOrderNumber",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "WorkOrderPriority",
                table: "WorkOrders");

            migrationBuilder.RenameColumn(
                name: "WorkOrderStatus",
                table: "WorkOrders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "AssignedTechnicianId",
                table: "WorkOrders",
                newName: "TechnicianId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_AssignedTechnicianId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Users_TechnicianId",
                table: "WorkOrders",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
