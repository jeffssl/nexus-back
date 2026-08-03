using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Domain.Entities.System;

namespace Nexus.Infrastructure.Persistence.Configurations.System;

public class ContactTypeConfiguration : IEntityTypeConfiguration<Nexus.Domain.Entities.System.ContactType>
{
    public void Configure(EntityTypeBuilder<Nexus.Domain.Entities.System.ContactType> builder)
    {
        builder.ToTable("contact_types", "system");

        builder.HasKey(e => e.ContactTypeId);


        builder.HasData(
            new ContactType { ContactTypeId = 1, Code = "PHONE", Name = "Teléfono", IsActive = true },
            new ContactType { ContactTypeId = 2, Code = "EMAIL", Name = "Correo Electrónico", IsActive = true },
            new ContactType { ContactTypeId = 3, Code = "WHATSAPP", Name = "WhatsApp", IsActive = true },
            new ContactType { ContactTypeId = 4, Code = "EMERGENCY", Name = "Contacto de Emergencia", IsActive = true }
        );
    }
}
