using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class ResourceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Resources",
                newName: "PriceSell");

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "UserOrganisations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Resources",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Resources",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "PriceBuy",
                table: "Resources",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Resources",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "UserOrganisations");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "PriceBuy",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "PriceSell",
                table: "Resources",
                newName: "Value");
        }
    }
}
