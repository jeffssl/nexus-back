using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nexus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RedesignSpecialtiesAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.AlterColumn<string>(
                name: "icon_url",
                schema: "catalog",
                table: "specialties",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "catalog",
                table: "specialties",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "specialty_id",
                schema: "catalog",
                table: "specialties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                schema: "catalog",
                table: "specialties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name_en",
                schema: "catalog",
                table: "specialties",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name_es",
                schema: "catalog",
                table: "specialties",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "snomed_code",
                schema: "catalog",
                table: "specialties",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "specialty_categories",
                schema: "catalog",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name_es = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    name_en = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_specialty_categories", x => x.category_id);
                });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 1,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "Cardiology", "Cardiología", "394579002" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 2,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "Pediatrics", "Pediatría", "394537008" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 3,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "Dermatology", "Dermatología", "394582007" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 4,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 2, "Neurology", "Neurología", "394591006" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 5,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "Ophthalmology", "Oftalmología", "394594003" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 6,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 2, "Orthopedic Surgery", "Cirugía Ortopédica", "394609007" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 7,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "Endocrinology", "Endocrinología", "394586005" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 8,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "Gastroenterology", "Gastroenterología", "394587001" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 9,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "Geriatrics", "Geriatría", "394589003" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 10,
                columns: new[] { "category_id", "name_en", "name_es", "snomed_code" },
                values: new object[] { 1, "General Practice", "Medicina General", "394580004" });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "specialty_categories",
                columns: new[] { "category_id", "code", "created_at", "created_by", "deleted_at", "deleted_by", "is_active", "name_en", "name_es", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, "MEDICINA", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Medicine", "Medicina", null, null },
                    { 2, "CIRUGIA", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Surgery", "Cirugía", null, null },
                    { 3, "DIAGNOSTICO", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Diagnostics", "Diagnóstico", null, null },
                    { 4, "SALUD_MENTAL", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Mental Health", "Salud Mental", null, null },
                    { 5, "REHABILITACION", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Rehabilitation", "Rehabilitación", null, null },
                    { 6, "ODONTOLOGIA", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Dentistry", "Odontología", null, null },
                    { 7, "TERAPIAS", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Therapies", "Terapias", null, null },
                    { 8, "OTRAS", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, null, true, "Other", "Otras", null, null }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "specialties",
                columns: new[] { "specialty_id", "category_id", "description", "icon_url", "is_active", "name_en", "name_es", "snomed_code" },
                values: new object[,]
                {
                    { 11, 1, null, null, true, "Family Medicine", "Medicina Familiar", "394802001" },
                    { 12, 1, null, null, true, "Nephrology", "Nefrología", "394592004" },
                    { 13, 2, null, null, true, "Neurosurgery", "Neurocirugía", "394593009" },
                    { 14, 2, null, null, true, "Obstetrics and Gynecology", "Obstetricia y Ginecología", "394595002" },
                    { 15, 1, null, null, true, "Medical Oncology", "Oncología Médica", "394597005" },
                    { 16, 2, null, null, true, "Otolaryngology", "Otorrinolaringología", "394598000" },
                    { 17, 3, null, null, true, "Pathology", "Patología", "394600002" },
                    { 18, 2, null, null, true, "Pediatric Surgery", "Cirugía Pediátrica", "394601003" },
                    { 19, 2, null, null, true, "Plastic Surgery", "Cirugía Plástica", "394602005" },
                    { 20, 4, null, null, true, "Psychiatry", "Psiquiatría", "394603000" },
                    { 21, 3, null, null, true, "Radiology", "Radiología", "394604006" },
                    { 22, 3, null, null, true, "Radiation Oncology", "Radioterapia", "394605007" },
                    { 23, 5, null, null, true, "Physical Medicine and Rehabilitation", "Rehabilitación", "394606008" },
                    { 24, 1, null, null, true, "Rheumatology", "Reumatología", "394607004" },
                    { 25, 2, null, null, true, "General Surgery", "Cirugía General", "394608009" },
                    { 26, 2, null, null, true, "Urology", "Urología", "408443003" },
                    { 27, 2, null, null, true, "Vascular Surgery", "Cirugía Vascular", "408444009" },
                    { 28, 1, null, null, true, "Emergency Medicine", "Medicina de Emergencias", "722163007" },
                    { 29, 1, null, null, true, "Intensive Care Medicine", "Medicina Intensiva", "722164001" },
                    { 30, 1, null, null, true, "Infectious Diseases", "Infectología", "722165000" },
                    { 31, 1, null, null, true, "Pulmonology", "Neumología", "722166004" },
                    { 32, 1, null, null, true, "Hematology", "Hematología", "722167008" },
                    { 33, 1, null, null, true, "Clinical Immunology", "Inmunología Clínica", "722168003" },
                    { 34, 1, null, null, true, "Internal Medicine", "Medicina Interna", "722169006" },
                    { 35, 1, null, null, true, "Nuclear Medicine", "Medicina Nuclear", "722170007" },
                    { 36, 1, null, null, true, "Pain Medicine", "Medicina del Dolor", "722171006" },
                    { 37, 1, null, null, true, "Anesthesiology", "Anestesiología", "722172004" },
                    { 38, 1, null, null, true, "Allergy", "Alergología", "722173009" },
                    { 39, 1, null, null, true, "Medical Genetics", "Genética Médica", "722174003" },
                    { 40, 1, null, null, true, "Preventive Medicine", "Medicina Preventiva", "722175002" },
                    { 41, 1, null, null, true, "Occupational Medicine", "Medicina del Trabajo", "722176001" },
                    { 42, 1, null, null, true, "Sports Medicine", "Medicina Deportiva", "722177005" },
                    { 43, 1, null, null, true, "Tropical Medicine", "Medicina Tropical", "722178000" },
                    { 44, 1, null, null, true, "Sleep Medicine", "Medicina del Sueño", "722179008" },
                    { 45, 1, null, null, true, "Palliative Medicine", "Medicina Paliativa", "722180006" },
                    { 46, 1, null, null, true, "Hyperbaric Medicine", "Medicina Hiperbárica", "722181005" },
                    { 47, 1, null, null, true, "Aerospace Medicine", "Medicina Aeroespacial", "722182003" },
                    { 48, 1, null, null, true, "Toxicology", "Toxicología", "722183008" },
                    { 49, 3, null, null, true, "Cytopathology", "Citopatología", "722184002" },
                    { 50, 3, null, null, true, "Dermatopathology", "Dermatopatología", "722185001" },
                    { 51, 3, null, null, true, "Neuropathology", "Neuropatología", "722186000" },
                    { 52, 3, null, null, true, "Forensic Pathology", "Patología Forense", "722187009" },
                    { 53, 2, null, null, true, "Cardiovascular Surgery", "Cirugía Cardiovascular", "722188004" },
                    { 54, 2, null, null, true, "Thoracic Surgery", "Cirugía Torácica", "722189007" },
                    { 55, 2, null, null, true, "Oral and Maxillofacial Surgery", "Cirugía Maxilofacial", "722190003" },
                    { 56, 2, null, null, true, "Hand Surgery", "Cirugía de Mano", "722191004" },
                    { 57, 1, null, null, true, "Colorectal Surgery", "Coloproctología", "722192006" },
                    { 58, 2, null, null, true, "Transplant Surgery", "Trasplantes", "722193001" },
                    { 59, 1, null, null, true, "Angiology", "Angiología", "722194007" },
                    { 60, 3, null, null, true, "Cardiac Electrophysiology", "Electrofisiología Cardíaca", "722195008" },
                    { 61, 3, null, null, true, "Interventional Cardiology", "Hemodinamia", "722196009" },
                    { 62, 1, null, null, true, "Maternal Fetal Medicine", "Medicina Materno Fetal", "722197000" },
                    { 63, 1, null, null, true, "Neonatology", "Neonatología", "722198005" },
                    { 64, 1, null, null, true, "Reproductive Medicine", "Reproducción Humana", "722199002" },
                    { 65, 1, null, null, true, "Fertility Medicine", "Fertilidad", "722200004" },
                    { 66, 1, null, null, true, "Andrology", "Andrología", "722201000" },
                    { 67, 2, null, null, true, "Breast Surgery", "Mastología", "722202007" },
                    { 68, 3, null, null, true, "Hepatology", "Hepatología", "722203002" },
                    { 69, 1, null, null, true, "Clinical Nutrition", "Nutrición Clínica", "722204008" },
                    { 70, 1, null, null, true, "Diabetology", "Diabetología", "722205009" },
                    { 71, 1, null, null, true, "Integrative Medicine", "Medicina Integrativa", "722206005" },
                    { 72, 1, null, null, true, "Aesthetic Medicine", "Medicina Estética", "722207001" },
                    { 73, 8, null, null, true, "Acupuncture", "Acupuntura", "722208006" },
                    { 74, 8, null, null, true, "Chiropractic", "Quiropráctica", "722209003" },
                    { 75, 6, null, null, true, "Dentistry", "Odontología", "722210008" },
                    { 76, 6, null, null, true, "Orthodontics", "Ortodoncia", "722211007" },
                    { 77, 6, null, null, true, "Endodontics", "Endodoncia", "722212000" },
                    { 78, 6, null, null, true, "Periodontics", "Periodoncia", "722213005" },
                    { 79, 6, null, null, true, "Oral Implantology", "Implantología Oral", "722214004" },
                    { 80, 2, null, null, true, "Oral Surgery", "Cirugía Oral", "722215003" },
                    { 81, 6, null, null, true, "Pediatric Dentistry", "Odontopediatría", "722216002" },
                    { 82, 6, null, null, true, "Prosthodontics", "Prótesis Dental", "722217006" },
                    { 83, 5, null, null, true, "Physical Medicine", "Medicina Física", "722218001" },
                    { 84, 7, null, null, true, "Physiotherapy", "Fisioterapia", "722219009" },
                    { 85, 7, null, null, true, "Occupational Therapy", "Terapia Ocupacional", "722220003" },
                    { 86, 7, null, null, true, "Speech Therapy", "Fonoaudiología", "722221004" },
                    { 87, 4, null, null, true, "Clinical Psychology", "Psicología Clínica", "722222006" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_specialties_category_id",
                schema: "catalog",
                table: "specialties",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_specialties_snomed_code",
                schema: "catalog",
                table: "specialties",
                column: "snomed_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_specialty_categories_code",
                schema: "catalog",
                table: "specialty_categories",
                column: "code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_specialties_specialty_categories_category_id",
                schema: "catalog",
                table: "specialties",
                column: "category_id",
                principalSchema: "catalog",
                principalTable: "specialty_categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_specialties_specialty_categories_category_id",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropTable(
                name: "specialty_categories",
                schema: "catalog");

            migrationBuilder.DropIndex(
                name: "ix_specialties_category_id",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropIndex(
                name: "ix_specialties_snomed_code",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 87);

            migrationBuilder.DropColumn(
                name: "category_id",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropColumn(
                name: "name_en",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropColumn(
                name: "name_es",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.DropColumn(
                name: "snomed_code",
                schema: "catalog",
                table: "specialties");

            migrationBuilder.AlterColumn<string>(
                name: "icon_url",
                schema: "catalog",
                table: "specialties",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "catalog",
                table: "specialties",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "specialty_id",
                schema: "catalog",
                table: "specialties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AddColumn<string>(
                name: "code",
                schema: "catalog",
                table: "specialties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "catalog",
                table: "specialties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 1,
                columns: new[] { "code", "name" },
                values: new object[] { "394812008", "Medicina General" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 2,
                columns: new[] { "code", "name" },
                values: new object[] { "394537008", "Pediatría" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 3,
                columns: new[] { "code", "name" },
                values: new object[] { "394579002", "Cardiología" });

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
                columns: new[] { "code", "name" },
                values: new object[] { "394582007", "Dermatología" });

            migrationBuilder.UpdateData(
                schema: "catalog",
                table: "specialties",
                keyColumn: "specialty_id",
                keyValue: 6,
                columns: new[] { "code", "name" },
                values: new object[] { "394594003", "Oftalmología" });

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
    }
}
