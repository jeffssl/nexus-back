using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nexus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StrictMultiTenancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "scheduling",
                table: "waitlists",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "appointment",
                table: "telehealth_sessions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "pricing",
                table: "service_prices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "scheduling",
                table: "schedule_exceptions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "facility",
                table: "rooms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "billing",
                table: "refunds",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "pricing",
                table: "price_lists",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "practitioner",
                table: "practitioner_specialties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "practitioner",
                table: "practitioner_locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "practitioner",
                table: "practitioner_contacts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "patient",
                table: "patient_relations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "patient",
                table: "patient_insurances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "patient",
                table: "patient_contacts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "patient",
                table: "patient_consents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "patient",
                table: "patient_addresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "organization",
                table: "location_specialties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "organization",
                table: "location_contacts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "organization",
                table: "location_addresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "billing",
                table: "invoice_line_items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "facility",
                table: "equipments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "appointment",
                table: "appointment_histories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "appointment",
                table: "appointment_clinical_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_waitlists_tenant_id",
                schema: "scheduling",
                table: "waitlists",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_telehealth_sessions_tenant_id",
                schema: "appointment",
                table: "telehealth_sessions",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_service_prices_tenant_id",
                schema: "pricing",
                table: "service_prices",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_schedule_exceptions_tenant_id",
                schema: "scheduling",
                table: "schedule_exceptions",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_tenant_id",
                schema: "facility",
                table: "rooms",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_refunds_tenant_id",
                schema: "billing",
                table: "refunds",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_price_lists_tenant_id",
                schema: "pricing",
                table: "price_lists",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_practitioner_specialties_tenant_id",
                schema: "practitioner",
                table: "practitioner_specialties",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_practitioner_locations_tenant_id",
                schema: "practitioner",
                table: "practitioner_locations",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_practitioner_contacts_tenant_id",
                schema: "practitioner",
                table: "practitioner_contacts",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_patient_relations_tenant_id",
                schema: "patient",
                table: "patient_relations",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_patient_insurances_tenant_id",
                schema: "patient",
                table: "patient_insurances",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_patient_contacts_tenant_id",
                schema: "patient",
                table: "patient_contacts",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_patient_consents_tenant_id",
                schema: "patient",
                table: "patient_consents",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_patient_addresses_tenant_id",
                schema: "patient",
                table: "patient_addresses",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_location_specialties_tenant_id",
                schema: "organization",
                table: "location_specialties",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_location_contacts_tenant_id",
                schema: "organization",
                table: "location_contacts",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_location_addresses_tenant_id",
                schema: "organization",
                table: "location_addresses",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_invoice_line_items_tenant_id",
                schema: "billing",
                table: "invoice_line_items",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_equipments_tenant_id",
                schema: "facility",
                table: "equipments",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_histories_tenant_id",
                schema: "appointment",
                table: "appointment_histories",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointment_clinical_details_tenant_id",
                schema: "appointment",
                table: "appointment_clinical_details",
                column: "tenant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_waitlists_tenant_id",
                schema: "scheduling",
                table: "waitlists");

            migrationBuilder.DropIndex(
                name: "ix_telehealth_sessions_tenant_id",
                schema: "appointment",
                table: "telehealth_sessions");

            migrationBuilder.DropIndex(
                name: "ix_service_prices_tenant_id",
                schema: "pricing",
                table: "service_prices");

            migrationBuilder.DropIndex(
                name: "ix_schedule_exceptions_tenant_id",
                schema: "scheduling",
                table: "schedule_exceptions");

            migrationBuilder.DropIndex(
                name: "ix_rooms_tenant_id",
                schema: "facility",
                table: "rooms");

            migrationBuilder.DropIndex(
                name: "ix_refunds_tenant_id",
                schema: "billing",
                table: "refunds");

            migrationBuilder.DropIndex(
                name: "ix_price_lists_tenant_id",
                schema: "pricing",
                table: "price_lists");

            migrationBuilder.DropIndex(
                name: "ix_practitioner_specialties_tenant_id",
                schema: "practitioner",
                table: "practitioner_specialties");

            migrationBuilder.DropIndex(
                name: "ix_practitioner_locations_tenant_id",
                schema: "practitioner",
                table: "practitioner_locations");

            migrationBuilder.DropIndex(
                name: "ix_practitioner_contacts_tenant_id",
                schema: "practitioner",
                table: "practitioner_contacts");

            migrationBuilder.DropIndex(
                name: "ix_patient_relations_tenant_id",
                schema: "patient",
                table: "patient_relations");

            migrationBuilder.DropIndex(
                name: "ix_patient_insurances_tenant_id",
                schema: "patient",
                table: "patient_insurances");

            migrationBuilder.DropIndex(
                name: "ix_patient_contacts_tenant_id",
                schema: "patient",
                table: "patient_contacts");

            migrationBuilder.DropIndex(
                name: "ix_patient_consents_tenant_id",
                schema: "patient",
                table: "patient_consents");

            migrationBuilder.DropIndex(
                name: "ix_patient_addresses_tenant_id",
                schema: "patient",
                table: "patient_addresses");

            migrationBuilder.DropIndex(
                name: "ix_location_specialties_tenant_id",
                schema: "organization",
                table: "location_specialties");

            migrationBuilder.DropIndex(
                name: "ix_location_contacts_tenant_id",
                schema: "organization",
                table: "location_contacts");

            migrationBuilder.DropIndex(
                name: "ix_location_addresses_tenant_id",
                schema: "organization",
                table: "location_addresses");

            migrationBuilder.DropIndex(
                name: "ix_invoice_line_items_tenant_id",
                schema: "billing",
                table: "invoice_line_items");

            migrationBuilder.DropIndex(
                name: "ix_equipments_tenant_id",
                schema: "facility",
                table: "equipments");

            migrationBuilder.DropIndex(
                name: "ix_appointment_histories_tenant_id",
                schema: "appointment",
                table: "appointment_histories");

            migrationBuilder.DropIndex(
                name: "ix_appointment_clinical_details_tenant_id",
                schema: "appointment",
                table: "appointment_clinical_details");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "scheduling",
                table: "waitlists");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "appointment",
                table: "telehealth_sessions");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "pricing",
                table: "service_prices");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "scheduling",
                table: "schedule_exceptions");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "facility",
                table: "rooms");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "billing",
                table: "refunds");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "pricing",
                table: "price_lists");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "practitioner",
                table: "practitioner_specialties");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "practitioner",
                table: "practitioner_locations");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "practitioner",
                table: "practitioner_contacts");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "patient",
                table: "patient_relations");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "patient",
                table: "patient_insurances");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "patient",
                table: "patient_contacts");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "patient",
                table: "patient_consents");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "patient",
                table: "patient_addresses");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "organization",
                table: "location_specialties");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "organization",
                table: "location_contacts");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "organization",
                table: "location_addresses");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "billing",
                table: "invoice_line_items");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "facility",
                table: "equipments");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "appointment",
                table: "appointment_histories");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "appointment",
                table: "appointment_clinical_details");
        }
    }
}
