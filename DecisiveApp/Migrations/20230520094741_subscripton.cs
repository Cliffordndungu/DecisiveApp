using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecisiveApp.Migrations
{
    /// <inheritdoc />
    public partial class subscripton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasTrial",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Nextbillingdate",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Startdate",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "billingcycle",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "lastpaymentdate",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasTrial",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Nextbillingdate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Startdate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "billingcycle",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "lastpaymentdate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "status",
                table: "OrderItems");
        }
    }
}
