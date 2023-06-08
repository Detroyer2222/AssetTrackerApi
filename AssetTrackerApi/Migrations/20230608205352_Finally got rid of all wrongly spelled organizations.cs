using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class Finallygotridofallwronglyspelledorganizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganization_Organization_OrganizationId",
                table: "UserOrganization");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganization_Users_UserId",
                table: "UserOrganization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrganization",
                table: "UserOrganization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.RenameTable(
                name: "UserOrganization",
                newName: "UserOrganizations");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganization_OrganizationId",
                table: "UserOrganizations",
                newName: "IX_UserOrganizations_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrganizations",
                table: "UserOrganizations",
                columns: new[] { "UserId", "OrganizationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizations_Organizations_OrganizationId",
                table: "UserOrganizations",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganizations_Users_UserId",
                table: "UserOrganizations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizations_Organizations_OrganizationId",
                table: "UserOrganizations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrganizations_Users_UserId",
                table: "UserOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrganizations",
                table: "UserOrganizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.RenameTable(
                name: "UserOrganizations",
                newName: "UserOrganization");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrganizations_OrganizationId",
                table: "UserOrganization",
                newName: "IX_UserOrganization_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrganization",
                table: "UserOrganization",
                columns: new[] { "UserId", "OrganizationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganization_Organization_OrganizationId",
                table: "UserOrganization",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrganization_Users_UserId",
                table: "UserOrganization",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
