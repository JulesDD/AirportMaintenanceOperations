using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftMaintenanceOperations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MaintenanceRequestConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_Aircrafts_AircraftId",
                table: "MaintenanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_MaintenanceRequests_MaintenanceRequestId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_ReportedByUserId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "ReportedByUserId",
                table: "MaintenanceRequests");

            migrationBuilder.RenameColumn(
                name: "DateReported",
                table: "MaintenanceRequests",
                newName: "RequestedDate");

            migrationBuilder.AlterColumn<string>(
                name: "MaintenanceRequestStatus",
                table: "MaintenanceRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MaintenancePriority",
                table: "MaintenanceRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RequestNumber",
                table: "MaintenanceRequests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestedBy",
                table: "MaintenanceRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MaintenanceRequests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextMaintenanceDate",
                table: "Aircrafts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenancePriority",
                table: "MaintenanceRequests",
                column: "MaintenancePriority");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_MaintenanceRequestStatus",
                table: "MaintenanceRequests",
                column: "MaintenanceRequestStatus");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_RequestedBy",
                table: "MaintenanceRequests",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_RequestNumber",
                table: "MaintenanceRequests",
                column: "RequestNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_Aircrafts_AircraftId",
                table: "MaintenanceRequests",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_MaintenanceRequests_MaintenanceRequestId",
                table: "WorkOrders",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_Aircrafts_AircraftId",
                table: "MaintenanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_MaintenanceRequests_MaintenanceRequestId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_MaintenancePriority",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_MaintenanceRequestStatus",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_RequestedBy",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_RequestNumber",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "RequestNumber",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "RequestedBy",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MaintenanceRequests");

            migrationBuilder.RenameColumn(
                name: "RequestedDate",
                table: "MaintenanceRequests",
                newName: "DateReported");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceRequestStatus",
                table: "MaintenanceRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenancePriority",
                table: "MaintenanceRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MaintenanceRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportedByUserId",
                table: "MaintenanceRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextMaintenanceDate",
                table: "Aircrafts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_ReportedByUserId",
                table: "MaintenanceRequests",
                column: "ReportedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_Aircrafts_AircraftId",
                table: "MaintenanceRequests",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_MaintenanceRequests_MaintenanceRequestId",
                table: "WorkOrders",
                column: "MaintenanceRequestId",
                principalTable: "MaintenanceRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
