using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nexus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AuditAndRefactorCatalogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "document_types",
                schema: "practitioner",
                newName: "document_types",
                newSchema: "catalog");

            migrationBuilder.AddColumn<int>(
                name: "document_type_id",
                schema: "organization",
                table: "organizations",
                type: "integer",
                nullable: true);

            migrationBuilder.Sql("DELETE FROM catalog.document_types;");
            migrationBuilder.Sql("DELETE FROM catalog.specialties;");

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "document_types",
                columns: new[] { "type_id", "code", "country_code", "is_active", "name", "validation_regex" },
                values: new object[,]
                {
                    { 1, "CEDULA", null, true, "Cédula de Identidad", null },
                    { 2, "PASAPORTE", null, true, "Pasaporte", null },
                    { 3, "RUC", null, true, "Registro Único de Contribuyentes", null },
                    { 4, "NIT", null, true, "Número de Identificación Tributaria", null },
                    { 5, "SSN", null, true, "Social Security Number", null }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "specialties",
                columns: new[] { "specialty_id", "code", "description", "icon_url", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "MED-GEN", null, null, true, "Medicina General" },
                    { 2, "PEDIATRIA", null, null, true, "Pediatría" },
                    { 3, "CARDIOLOGIA", null, null, true, "Cardiología" },
                    { 4, "GINECOLOGIA", null, null, true, "Ginecología" },
                    { 5, "DERMATOLOGIA", null, null, true, "Dermatología" },
                    { 6, "OFTALMOLOGIA", null, null, true, "Oftalmología" },
                    { 7, "TRAUMATOLOGIA", null, null, true, "Traumatología" },
                    { 8, "ODONTOLOGIA", null, null, true, "Odontología" },
                    { 9, "PSICOLOGIA", null, null, true, "Psicología" },
                    { 10, "NUTRICION", null, null, true, "Nutrición" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "document_type_id",
                schema: "organization",
                table: "organizations");

            migrationBuilder.RenameTable(
                name: "document_types",
                schema: "catalog",
                newName: "document_types",
                newSchema: "practitioner");
        }
    }
}
