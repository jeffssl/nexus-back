using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Practitioner;

namespace Nexus.Infrastructure.Persistence.Configurations.Practitioner;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Practitioner.Specialty>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Practitioner.Specialty> builder)
    {
        builder.ToTable("specialties", "practitioner");

        builder.HasKey(e => e.SpecialtyId);

        builder.Property(e => e.SpecialtyId)
            .UseIdentityAlwaysColumn();

        builder.Property(e => e.SnomedCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.NameEs)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(e => e.NameEn)
            .IsRequired()
            .HasMaxLength(150);



        builder.HasIndex(e => e.SnomedCode)
            .IsUnique();

        builder.HasOne(e => e.Category)
            .WithMany(c => c.Specialties)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Specialty { SpecialtyId = 1, SnomedCode = "394579002", NameEs = "Cardiología", NameEn = "Cardiology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 2, SnomedCode = "394537008", NameEs = "Pediatría", NameEn = "Pediatrics", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 3, SnomedCode = "394582007", NameEs = "Dermatología", NameEn = "Dermatology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 4, SnomedCode = "394591006", NameEs = "Neurología", NameEn = "Neurology", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 5, SnomedCode = "394594003", NameEs = "Oftalmología", NameEn = "Ophthalmology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 6, SnomedCode = "394609007", NameEs = "Cirugía Ortopédica", NameEn = "Orthopedic Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 7, SnomedCode = "394586005", NameEs = "Endocrinología", NameEn = "Endocrinology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 8, SnomedCode = "394587001", NameEs = "Gastroenterología", NameEn = "Gastroenterology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 9, SnomedCode = "394589003", NameEs = "Geriatría", NameEn = "Geriatrics", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 10, SnomedCode = "394580004", NameEs = "Medicina General", NameEn = "General Practice", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 11, SnomedCode = "394802001", NameEs = "Medicina Familiar", NameEn = "Family Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 12, SnomedCode = "394592004", NameEs = "Nefrología", NameEn = "Nephrology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 13, SnomedCode = "394593009", NameEs = "Neurocirugía", NameEn = "Neurosurgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 14, SnomedCode = "394595002", NameEs = "Obstetricia y Ginecología", NameEn = "Obstetrics and Gynecology", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 15, SnomedCode = "394597005", NameEs = "Oncología Médica", NameEn = "Medical Oncology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 16, SnomedCode = "394598000", NameEs = "Otorrinolaringología", NameEn = "Otolaryngology", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 17, SnomedCode = "394600002", NameEs = "Patología", NameEn = "Pathology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 18, SnomedCode = "394601003", NameEs = "Cirugía Pediátrica", NameEn = "Pediatric Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 19, SnomedCode = "394602005", NameEs = "Cirugía Plástica", NameEn = "Plastic Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 20, SnomedCode = "394603000", NameEs = "Psiquiatría", NameEn = "Psychiatry", CategoryId = 4, IsActive = true },
            new Specialty { SpecialtyId = 21, SnomedCode = "394604006", NameEs = "Radiología", NameEn = "Radiology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 22, SnomedCode = "394605007", NameEs = "Radioterapia", NameEn = "Radiation Oncology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 23, SnomedCode = "394606008", NameEs = "Rehabilitación", NameEn = "Physical Medicine and Rehabilitation", CategoryId = 5, IsActive = true },
            new Specialty { SpecialtyId = 24, SnomedCode = "394607004", NameEs = "Reumatología", NameEn = "Rheumatology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 25, SnomedCode = "394608009", NameEs = "Cirugía General", NameEn = "General Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 26, SnomedCode = "408443003", NameEs = "Urología", NameEn = "Urology", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 27, SnomedCode = "408444009", NameEs = "Cirugía Vascular", NameEn = "Vascular Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 28, SnomedCode = "722163007", NameEs = "Medicina de Emergencias", NameEn = "Emergency Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 29, SnomedCode = "722164001", NameEs = "Medicina Intensiva", NameEn = "Intensive Care Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 30, SnomedCode = "722165000", NameEs = "Infectología", NameEn = "Infectious Diseases", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 31, SnomedCode = "722166004", NameEs = "Neumología", NameEn = "Pulmonology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 32, SnomedCode = "722167008", NameEs = "Hematología", NameEn = "Hematology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 33, SnomedCode = "722168003", NameEs = "Inmunología Clínica", NameEn = "Clinical Immunology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 34, SnomedCode = "722169006", NameEs = "Medicina Interna", NameEn = "Internal Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 35, SnomedCode = "722170007", NameEs = "Medicina Nuclear", NameEn = "Nuclear Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 36, SnomedCode = "722171006", NameEs = "Medicina del Dolor", NameEn = "Pain Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 37, SnomedCode = "722172004", NameEs = "Anestesiología", NameEn = "Anesthesiology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 38, SnomedCode = "722173009", NameEs = "Alergología", NameEn = "Allergy", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 39, SnomedCode = "722174003", NameEs = "Genética Médica", NameEn = "Medical Genetics", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 40, SnomedCode = "722175002", NameEs = "Medicina Preventiva", NameEn = "Preventive Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 41, SnomedCode = "722176001", NameEs = "Medicina del Trabajo", NameEn = "Occupational Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 42, SnomedCode = "722177005", NameEs = "Medicina Deportiva", NameEn = "Sports Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 43, SnomedCode = "722178000", NameEs = "Medicina Tropical", NameEn = "Tropical Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 44, SnomedCode = "722179008", NameEs = "Medicina del Sueño", NameEn = "Sleep Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 45, SnomedCode = "722180006", NameEs = "Medicina Paliativa", NameEn = "Palliative Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 46, SnomedCode = "722181005", NameEs = "Medicina Hiperbárica", NameEn = "Hyperbaric Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 47, SnomedCode = "722182003", NameEs = "Medicina Aeroespacial", NameEn = "Aerospace Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 48, SnomedCode = "722183008", NameEs = "Toxicología", NameEn = "Toxicology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 49, SnomedCode = "722184002", NameEs = "Citopatología", NameEn = "Cytopathology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 50, SnomedCode = "722185001", NameEs = "Dermatopatología", NameEn = "Dermatopathology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 51, SnomedCode = "722186000", NameEs = "Neuropatología", NameEn = "Neuropathology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 52, SnomedCode = "722187009", NameEs = "Patología Forense", NameEn = "Forensic Pathology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 53, SnomedCode = "722188004", NameEs = "Cirugía Cardiovascular", NameEn = "Cardiovascular Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 54, SnomedCode = "722189007", NameEs = "Cirugía Torácica", NameEn = "Thoracic Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 55, SnomedCode = "722190003", NameEs = "Cirugía Maxilofacial", NameEn = "Oral and Maxillofacial Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 56, SnomedCode = "722191004", NameEs = "Cirugía de Mano", NameEn = "Hand Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 57, SnomedCode = "722192006", NameEs = "Coloproctología", NameEn = "Colorectal Surgery", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 58, SnomedCode = "722193001", NameEs = "Trasplantes", NameEn = "Transplant Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 59, SnomedCode = "722194007", NameEs = "Angiología", NameEn = "Angiology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 60, SnomedCode = "722195008", NameEs = "Electrofisiología Cardíaca", NameEn = "Cardiac Electrophysiology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 61, SnomedCode = "722196009", NameEs = "Hemodinamia", NameEn = "Interventional Cardiology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 62, SnomedCode = "722197000", NameEs = "Medicina Materno Fetal", NameEn = "Maternal Fetal Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 63, SnomedCode = "722198005", NameEs = "Neonatología", NameEn = "Neonatology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 64, SnomedCode = "722199002", NameEs = "Reproducción Humana", NameEn = "Reproductive Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 65, SnomedCode = "722200004", NameEs = "Fertilidad", NameEn = "Fertility Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 66, SnomedCode = "722201000", NameEs = "Andrología", NameEn = "Andrology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 67, SnomedCode = "722202007", NameEs = "Mastología", NameEn = "Breast Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 68, SnomedCode = "722203002", NameEs = "Hepatología", NameEn = "Hepatology", CategoryId = 3, IsActive = true },
            new Specialty { SpecialtyId = 69, SnomedCode = "722204008", NameEs = "Nutrición Clínica", NameEn = "Clinical Nutrition", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 70, SnomedCode = "722205009", NameEs = "Diabetología", NameEn = "Diabetology", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 71, SnomedCode = "722206005", NameEs = "Medicina Integrativa", NameEn = "Integrative Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 72, SnomedCode = "722207001", NameEs = "Medicina Estética", NameEn = "Aesthetic Medicine", CategoryId = 1, IsActive = true },
            new Specialty { SpecialtyId = 73, SnomedCode = "722208006", NameEs = "Acupuntura", NameEn = "Acupuncture", CategoryId = 8, IsActive = true },
            new Specialty { SpecialtyId = 74, SnomedCode = "722209003", NameEs = "Quiropráctica", NameEn = "Chiropractic", CategoryId = 8, IsActive = true },
            new Specialty { SpecialtyId = 75, SnomedCode = "722210008", NameEs = "Odontología", NameEn = "Dentistry", CategoryId = 6, IsActive = true },
            new Specialty { SpecialtyId = 76, SnomedCode = "722211007", NameEs = "Ortodoncia", NameEn = "Orthodontics", CategoryId = 6, IsActive = true },
            new Specialty { SpecialtyId = 77, SnomedCode = "722212000", NameEs = "Endodoncia", NameEn = "Endodontics", CategoryId = 6, IsActive = true },
            new Specialty { SpecialtyId = 78, SnomedCode = "722213005", NameEs = "Periodoncia", NameEn = "Periodontics", CategoryId = 6, IsActive = true },
            new Specialty { SpecialtyId = 79, SnomedCode = "722214004", NameEs = "Implantología Oral", NameEn = "Oral Implantology", CategoryId = 6, IsActive = true },
            new Specialty { SpecialtyId = 80, SnomedCode = "722215003", NameEs = "Cirugía Oral", NameEn = "Oral Surgery", CategoryId = 2, IsActive = true },
            new Specialty { SpecialtyId = 81, SnomedCode = "722216002", NameEs = "Odontopediatría", NameEn = "Pediatric Dentistry", CategoryId = 6, IsActive = true },
            new Specialty { SpecialtyId = 82, SnomedCode = "722217006", NameEs = "Prótesis Dental", NameEn = "Prosthodontics", CategoryId = 6, IsActive = true },
            new Specialty { SpecialtyId = 83, SnomedCode = "722218001", NameEs = "Medicina Física", NameEn = "Physical Medicine", CategoryId = 5, IsActive = true },
            new Specialty { SpecialtyId = 84, SnomedCode = "722219009", NameEs = "Fisioterapia", NameEn = "Physiotherapy", CategoryId = 7, IsActive = true },
            new Specialty { SpecialtyId = 85, SnomedCode = "722220003", NameEs = "Terapia Ocupacional", NameEn = "Occupational Therapy", CategoryId = 7, IsActive = true },
            new Specialty { SpecialtyId = 86, SnomedCode = "722221004", NameEs = "Fonoaudiología", NameEn = "Speech Therapy", CategoryId = 7, IsActive = true },
            new Specialty { SpecialtyId = 87, SnomedCode = "722222006", NameEs = "Psicología Clínica", NameEn = "Clinical Psychology", CategoryId = 4, IsActive = true }
        );
    }
}
