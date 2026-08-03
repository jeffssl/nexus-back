using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nexus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AuditGeographicCatalogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_countries",
                schema: "geographic",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "country_code",
                schema: "geographic",
                table: "states");

            migrationBuilder.DropColumn(
                name: "description",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropColumn(
                name: "icon_url",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropColumn(
                name: "country_code",
                schema: "insurance",
                table: "payers");

            migrationBuilder.DropColumn(
                name: "country_code",
                schema: "organization",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "country_code",
                schema: "catalog",
                table: "document_types");

            migrationBuilder.AddColumn<int>(
                name: "country_id",
                schema: "geographic",
                table: "states",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "country_id",
                schema: "insurance",
                table: "payers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "country_id",
                schema: "organization",
                table: "organizations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "country_id",
                schema: "catalog",
                table: "document_types",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country_code",
                schema: "geographic",
                table: "countries",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "country_id",
                schema: "geographic",
                table: "countries",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_countries",
                schema: "geographic",
                table: "countries",
                column: "country_id");

            migrationBuilder.InsertData(
                schema: "geographic",
                table: "countries",
                columns: new[] { "country_id", "country_code", "is_active", "iso3code", "name", "phone_code" },
                values: new object[,]
                {
                    { 1, "EC", true, "ECU", "Ecuador", "+593" },
                    { 2, "CO", true, "COL", "Colombia", "+57" },
                    { 3, "PE", true, "PER", "Perú", "+51" },
                    { 4, "MX", true, "MEX", "México", "+52" },
                    { 5, "AR", true, "ARG", "Argentina", "+54" },
                    { 6, "CL", true, "CHL", "Chile", "+56" },
                    { 7, "ES", true, "ESP", "España", "+34" },
                    { 8, "US", true, "USA", "Estados Unidos", "+1" },
                    { 9, "BR", true, "BRA", "Brasil", "+55" },
                    { 10, "UY", true, "URY", "Uruguay", "+598" }
                });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 1,
                column: "country_id",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 2,
                column: "country_id",
                value: null);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 3,
                column: "country_id",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 4,
                column: "country_id",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 5,
                column: "country_id",
                value: 8);

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "document_types",
                columns: new[] { "type_id", "code", "country_id", "is_active", "name", "validation_regex" },
                values: new object[,]
                {
                    { 6, "DNI", 3, true, "Documento Nacional de Identidad", null },
                    { 7, "RUT", 6, true, "Rol Único Tributario", null },
                    { 8, "CUIT", 5, true, "Clave Única de Identificación Tributaria", null },
                    { 9, "CPF", 9, true, "Cadastro de Pessoas Físicas", null },
                    { 10, "CNPJ", 9, true, "Cadastro Nacional da Pessoa Jurídica", null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_countries_country_code",
                schema: "geographic",
                table: "countries",
                column: "country_code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_countries",
                schema: "geographic",
                table: "countries");

            migrationBuilder.DropIndex(
                name: "ix_countries_country_code",
                schema: "geographic",
                table: "countries");

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "geographic",
                table: "countries",
                keyColumn: "country_id",
                keyColumnType: "integer",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "country_id",
                schema: "geographic",
                table: "states");

            migrationBuilder.DropColumn(
                name: "country_id",
                schema: "insurance",
                table: "payers");

            migrationBuilder.DropColumn(
                name: "country_id",
                schema: "organization",
                table: "organizations");

            migrationBuilder.DropColumn(
                name: "country_id",
                schema: "catalog",
                table: "document_types");

            migrationBuilder.DropColumn(
                name: "country_id",
                schema: "geographic",
                table: "countries");

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                schema: "geographic",
                table: "states",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "catalog",
                table: "specialties",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "icon_url",
                schema: "catalog",
                table: "specialties",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                schema: "insurance",
                table: "payers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                schema: "organization",
                table: "organizations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country_code",
                schema: "catalog",
                table: "document_types",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "country_code",
                schema: "geographic",
                table: "countries",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2)",
                oldMaxLength: 2);

            migrationBuilder.AddPrimaryKey(
                name: "pk_countries",
                schema: "geographic",
                table: "countries",
                column: "country_code");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 1,
                column: "country_code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 2,
                column: "country_code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 3,
                column: "country_code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 4,
                column: "country_code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "document_types",
                keyColumn: "type_id",
                keyValue: 5,
                column: "country_code",
                value: null);

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 1,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 2,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 3,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 4,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 5,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 6,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 7,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 8,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 9,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 10,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 11,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 12,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 13,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 14,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 15,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 16,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 17,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 18,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 19,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 20,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 21,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 22,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 23,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 24,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 25,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 26,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 27,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 28,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 29,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 30,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 31,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 32,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 33,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 34,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 35,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 36,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 37,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 38,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 39,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 40,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 41,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 42,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 43,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 44,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 45,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 46,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 47,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 48,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 49,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 50,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 51,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 52,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 53,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 54,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 55,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 56,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 57,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 58,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 59,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 60,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 61,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 62,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 63,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 64,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 65,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 66,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 67,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 68,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 69,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 70,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 71,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 72,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 73,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 74,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 75,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 76,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 77,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 78,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 79,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 80,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 81,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 82,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 83,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 84,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 85,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 86,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 87,
                columns: new[] { "description", "icon_url" },
                values: new object[] { null, null });
        }
    }
}
