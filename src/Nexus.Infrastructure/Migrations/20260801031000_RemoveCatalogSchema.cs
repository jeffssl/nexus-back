using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCatalogSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "specialty_categories",
                schema: "catalog",
                newName: "specialty_categories",
                newSchema: "practitioner");

            migrationBuilder.RenameTable(
                name: "specialties",
                schema: "catalog",
                newName: "specialties",
                newSchema: "practitioner");

            migrationBuilder.RenameTable(
                name: "services",
                schema: "catalog",
                newName: "services",
                newSchema: "pricing");

            migrationBuilder.RenameTable(
                name: "refund_statuses",
                schema: "catalog",
                newName: "refund_statuses",
                newSchema: "billing");

            migrationBuilder.RenameTable(
                name: "payment_statuses",
                schema: "catalog",
                newName: "payment_statuses",
                newSchema: "billing");

            migrationBuilder.RenameTable(
                name: "payment_methods",
                schema: "catalog",
                newName: "payment_methods",
                newSchema: "billing");

            migrationBuilder.RenameTable(
                name: "document_types",
                schema: "catalog",
                newName: "document_types",
                newSchema: "geographic");

            migrationBuilder.RenameTable(
                name: "currencies",
                schema: "catalog",
                newName: "currencies",
                newSchema: "pricing");

            migrationBuilder.RenameTable(
                name: "contact_types",
                schema: "catalog",
                newName: "contact_types",
                newSchema: "system");

            migrationBuilder.RenameTable(
                name: "cancellation_reasons",
                schema: "catalog",
                newName: "cancellation_reasons",
                newSchema: "appointment");

            migrationBuilder.RenameTable(
                name: "appointment_statuses",
                schema: "catalog",
                newName: "appointment_statuses",
                newSchema: "appointment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.RenameTable(
                name: "specialty_categories",
                schema: "practitioner",
                newName: "specialty_categories",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "specialties",
                schema: "practitioner",
                newName: "specialties",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "services",
                schema: "pricing",
                newName: "services",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "refund_statuses",
                schema: "billing",
                newName: "refund_statuses",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "payment_statuses",
                schema: "billing",
                newName: "payment_statuses",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "payment_methods",
                schema: "billing",
                newName: "payment_methods",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "document_types",
                schema: "geographic",
                newName: "document_types",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "currencies",
                schema: "pricing",
                newName: "currencies",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "contact_types",
                schema: "system",
                newName: "contact_types",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "cancellation_reasons",
                schema: "appointment",
                newName: "cancellation_reasons",
                newSchema: "catalog");

            migrationBuilder.RenameTable(
                name: "appointment_statuses",
                schema: "appointment",
                newName: "appointment_statuses",
                newSchema: "catalog");
        }
    }
}
