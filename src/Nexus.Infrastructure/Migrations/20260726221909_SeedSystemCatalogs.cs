using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nexus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSystemCatalogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "catalog",
                table: "appointment_statuses",
                columns: new[] { "status_code", "allowed_transitions", "description", "is_final", "name" },
                values: new object[,]
                {
                    { "CANCELLED", null, null, true, "Cancelada" },
                    { "COMPLETED", null, null, true, "Completada" },
                    { "CONFIRMED", "IN_PROGRESS,CANCELLED,NO_SHOW", null, false, "Confirmada" },
                    { "IN_PROGRESS", "COMPLETED", null, false, "En Progreso" },
                    { "NO_SHOW", null, null, true, "No se presentó" },
                    { "SCHEDULED", "CONFIRMED,IN_PROGRESS,CANCELLED,NO_SHOW", null, false, "Agendada" }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "cancellation_reasons",
                columns: new[] { "reason_id", "applies_to_status", "code", "is_active", "name", "requires_refund" },
                values: new object[,]
                {
                    { 1, null, "PATIENT_REQUEST", true, "Solicitado por el paciente", true },
                    { 2, null, "CLINIC_REQUEST", true, "Fuerza mayor / Clínica", true },
                    { 3, null, "NO_SHOW", true, "Inasistencia", false },
                    { 4, null, "RESCHEDULED", true, "Reagendamiento", false }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "contact_types",
                columns: new[] { "contact_type_id", "code", "is_active", "name", "validation_regex" },
                values: new object[,]
                {
                    { 1, "PHONE", true, "Teléfono", null },
                    { 2, "EMAIL", true, "Correo Electrónico", null },
                    { 3, "WHATSAPP", true, "WhatsApp", null },
                    { 4, "EMERGENCY", true, "Contacto de Emergencia", null }
                });

            migrationBuilder.InsertData(
                schema: "insurance",
                table: "coverage_types",
                columns: new[] { "type_id", "code", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "MEDICAL", true, "Médica" },
                    { 2, "DENTAL", true, "Dental" },
                    { 3, "VISION", true, "Visual" },
                    { 4, "PHARMACY", true, "Farmacéutica" }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "currencies",
                columns: new[] { "currency_code", "decimal_places", "name", "symbol" },
                values: new object[,]
                {
                    { "CLP", (short)0, "Chilean Peso", "$" },
                    { "COP", (short)0, "Colombian Peso", "$" },
                    { "EUR", (short)2, "Euro", "€" },
                    { "MXN", (short)2, "Mexican Peso", "$" },
                    { "PEN", (short)2, "Peruvian Sol", "S/" },
                    { "USD", (short)2, "US Dollar", "$" }
                });

            migrationBuilder.InsertData(
                schema: "organization",
                table: "organization_types",
                columns: new[] { "type_id", "code", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "CLINIC", true, "Clínica" },
                    { 2, "HOSPITAL", true, "Hospital" },
                    { 3, "LAB", true, "Laboratorio Clínico" },
                    { 4, "IMAGING_CENTER", true, "Centro de Imágenes" },
                    { 5, "DENTAL", true, "Clínica Dental" }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "payment_methods",
                columns: new[] { "method_id", "code", "is_active", "name", "requires_gateway" },
                values: new object[,]
                {
                    { 1, "CASH", true, "Efectivo", false },
                    { 2, "CREDIT_CARD", true, "Tarjeta de Crédito", true },
                    { 3, "DEBIT_CARD", true, "Tarjeta de Débito", true },
                    { 4, "BANK_TRANSFER", true, "Transferencia Bancaria", false },
                    { 5, "INSURANCE", true, "Seguro Médico", false }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "payment_statuses",
                columns: new[] { "status_code", "is_final", "name" },
                values: new object[,]
                {
                    { "COMPLETED", true, "Completado" },
                    { "FAILED", true, "Fallido" },
                    { "PENDING", false, "Pendiente" },
                    { "REFUNDED", true, "Reembolsado" }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "refund_statuses",
                columns: new[] { "status_code", "description", "is_final", "name" },
                values: new object[,]
                {
                    { "APPROVED", null, true, "Aprobado" },
                    { "COMPLETED", null, true, "Completado" },
                    { "PENDING", null, false, "Pendiente" },
                    { "REJECTED", null, true, "Rechazado" }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "services",
                columns: new[] { "service_id", "code", "default_duration_minutes", "description", "is_active", "name", "requires_pre_auth" },
                values: new object[,]
                {
                    { 1, "GENERAL_CONSULTATION", (short)30, null, true, "Consulta Médica General", false },
                    { 2, "SPECIALIST_CONSULTATION", (short)45, null, true, "Consulta de Especialidad", false },
                    { 3, "FOLLOW_UP", (short)15, null, true, "Consulta de Seguimiento", false }
                });

            migrationBuilder.InsertData(
                schema: "scheduling",
                table: "weekdays",
                columns: new[] { "weekday_id", "code", "name" },
                values: new object[,]
                {
                    { (short)1, "MON", "Lunes" },
                    { (short)2, "TUE", "Martes" },
                    { (short)3, "WED", "Miércoles" },
                    { (short)4, "THU", "Jueves" },
                    { (short)5, "FRI", "Viernes" },
                    { (short)6, "SAT", "Sábado" },
                    { (short)7, "SUN", "Domingo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "appointment_statuses",
                keyColumn: "status_code",
                keyValue: "CANCELLED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "appointment_statuses",
                keyColumn: "status_code",
                keyValue: "COMPLETED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "appointment_statuses",
                keyColumn: "status_code",
                keyValue: "CONFIRMED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "appointment_statuses",
                keyColumn: "status_code",
                keyValue: "IN_PROGRESS");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "appointment_statuses",
                keyColumn: "status_code",
                keyValue: "NO_SHOW");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "appointment_statuses",
                keyColumn: "status_code",
                keyValue: "SCHEDULED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "cancellation_reasons",
                keyColumn: "reason_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "cancellation_reasons",
                keyColumn: "reason_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "cancellation_reasons",
                keyColumn: "reason_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "cancellation_reasons",
                keyColumn: "reason_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "contact_types",
                keyColumn: "contact_type_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "contact_types",
                keyColumn: "contact_type_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "contact_types",
                keyColumn: "contact_type_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "contact_types",
                keyColumn: "contact_type_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "insurance",
                table: "coverage_types",
                keyColumn: "type_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "insurance",
                table: "coverage_types",
                keyColumn: "type_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "insurance",
                table: "coverage_types",
                keyColumn: "type_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "insurance",
                table: "coverage_types",
                keyColumn: "type_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "currencies",
                keyColumn: "currency_code",
                keyValue: "CLP");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "currencies",
                keyColumn: "currency_code",
                keyValue: "COP");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "currencies",
                keyColumn: "currency_code",
                keyValue: "EUR");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "currencies",
                keyColumn: "currency_code",
                keyValue: "MXN");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "currencies",
                keyColumn: "currency_code",
                keyValue: "PEN");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "currencies",
                keyColumn: "currency_code",
                keyValue: "USD");

            migrationBuilder.DeleteData(
                schema: "organization",
                table: "organization_types",
                keyColumn: "type_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "organization",
                table: "organization_types",
                keyColumn: "type_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "organization",
                table: "organization_types",
                keyColumn: "type_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "organization",
                table: "organization_types",
                keyColumn: "type_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "organization",
                table: "organization_types",
                keyColumn: "type_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_methods",
                keyColumn: "method_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_methods",
                keyColumn: "method_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_methods",
                keyColumn: "method_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_methods",
                keyColumn: "method_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_methods",
                keyColumn: "method_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_statuses",
                keyColumn: "status_code",
                keyValue: "COMPLETED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_statuses",
                keyColumn: "status_code",
                keyValue: "FAILED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_statuses",
                keyColumn: "status_code",
                keyValue: "PENDING");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "payment_statuses",
                keyColumn: "status_code",
                keyValue: "REFUNDED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "refund_statuses",
                keyColumn: "status_code",
                keyValue: "APPROVED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "refund_statuses",
                keyColumn: "status_code",
                keyValue: "COMPLETED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "refund_statuses",
                keyColumn: "status_code",
                keyValue: "PENDING");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "refund_statuses",
                keyColumn: "status_code",
                keyValue: "REJECTED");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "services",
                keyColumn: "service_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "services",
                keyColumn: "service_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "services",
                keyColumn: "service_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "scheduling",
                table: "weekdays",
                keyColumn: "weekday_id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "scheduling",
                table: "weekdays",
                keyColumn: "weekday_id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "scheduling",
                table: "weekdays",
                keyColumn: "weekday_id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                schema: "scheduling",
                table: "weekdays",
                keyColumn: "weekday_id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                schema: "scheduling",
                table: "weekdays",
                keyColumn: "weekday_id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                schema: "scheduling",
                table: "weekdays",
                keyColumn: "weekday_id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                schema: "scheduling",
                table: "weekdays",
                keyColumn: "weekday_id",
                keyValue: (short)7);
        }
    }
}
