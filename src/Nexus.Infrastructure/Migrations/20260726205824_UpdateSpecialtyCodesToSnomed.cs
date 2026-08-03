using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSpecialtyCodesToSnomed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 1,
                column: "code",
                value: "394812008");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 2,
                column: "code",
                value: "394537008");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 3,
                column: "code",
                value: "394579002");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 4,
                columns: new[] { "code", "name" },
                values: new object[] { "394585009", "Obstetricia y Ginecología" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 5,
                column: "code",
                value: "394582007");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 6,
                column: "code",
                value: "394594003");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 7,
                columns: new[] { "code", "name" },
                values: new object[] { "394611003", "Cirugía Plástica" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 8,
                columns: new[] { "code", "name" },
                values: new object[] { "394609007", "Cirugía General" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 9,
                columns: new[] { "code", "name" },
                values: new object[] { "394587001", "Psiquiatría" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 10,
                columns: new[] { "code", "name" },
                values: new object[] { "408467006", "Ortodoncia (Odontología)" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 1,
                column: "code",
                value: "MED-GEN");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 2,
                column: "code",
                value: "PEDIATRIA");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 3,
                column: "code",
                value: "CARDIOLOGIA");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 4,
                columns: new[] { "code", "name" },
                values: new object[] { "GINECOLOGIA", "Ginecología" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 5,
                column: "code",
                value: "DERMATOLOGIA");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 6,
                column: "code",
                value: "OFTALMOLOGIA");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 7,
                columns: new[] { "code", "name" },
                values: new object[] { "TRAUMATOLOGIA", "Traumatología" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 8,
                columns: new[] { "code", "name" },
                values: new object[] { "ODONTOLOGIA", "Odontología" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 9,
                columns: new[] { "code", "name" },
                values: new object[] { "PSICOLOGIA", "Psicología" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 10,
                columns: new[] { "code", "name" },
                values: new object[] { "NUTRICION", "Nutrición" });
        }
    }
}
