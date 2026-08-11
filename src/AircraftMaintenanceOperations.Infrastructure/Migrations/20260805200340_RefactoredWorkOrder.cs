using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftMaintenanceOperations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredWorkOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Users_AssignedTechnicianId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ActualCompletionPercent",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "EstimatedCompletionPercent",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "MaintenanceNumber",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "MaintenanceRequests");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderCounters_Year",
                table: "WorkOrderCounters",
                newName: "IX_WorkOrderCounter_Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderCounter_Year",
                table: "WorkOrderCounters",
                newName: "IX_WorkOrderCounters_Year");

            migrationBuilder.AddColumn<decimal>(
                name: "ActualCompletionPercent",
                table: "WorkOrders",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedCompletionPercent",
                table: "WorkOrders",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MaintenanceNumber",
                table: "WorkOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Users_AssignedTechnicianId",
                table: "WorkOrders",
                column: "AssignedTechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
