using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.Geographic;

namespace Nexus.Infrastructure.Persistence.Configurations.Geographic;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.Geographic.DocumentType>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.Geographic.DocumentType> builder)
    {
        builder.ToTable("document_types", "geographic");

        builder.HasKey(e => e.TypeId);

        // Seed Data
        builder.HasData(
            new DocumentType { TypeId = 1, Code = "CEDULA", Name = "Cédula de Identidad", CountryId = 1, IsActive = true },
            new DocumentType { TypeId = 2, Code = "PASAPORTE", Name = "Pasaporte", IsActive = true },
            new DocumentType { TypeId = 3, Code = "RUC", Name = "Registro Único de Contribuyentes", CountryId = 1, IsActive = true },
            new DocumentType { TypeId = 4, Code = "NIT", Name = "Número de Identificación Tributaria", CountryId = 2, IsActive = true },
            new DocumentType { TypeId = 5, Code = "SSN", Name = "Social Security Number", CountryId = 8, IsActive = true },
            new DocumentType { TypeId = 6, Code = "DNI", Name = "Documento Nacional de Identidad", CountryId = 3, IsActive = true },
            new DocumentType { TypeId = 7, Code = "RUT", Name = "Rol Único Tributario", CountryId = 6, IsActive = true },
            new DocumentType { TypeId = 8, Code = "CUIT", Name = "Clave Única de Identificación Tributaria", CountryId = 5, IsActive = true },
            new DocumentType { TypeId = 9, Code = "CPF", Name = "Cadastro de Pessoas Físicas", CountryId = 9, IsActive = true },
            new DocumentType { TypeId = 10, Code = "CNPJ", Name = "Cadastro Nacional da Pessoa Jurídica", CountryId = 9, IsActive = true }
        );
    
        // Relaciones Foreign Keys generadas desde DBML
        builder.HasOne<Nexus.Domain.Entities.Geographic.Country>().WithMany().HasForeignKey(e => e.CountryId);
    }
}
