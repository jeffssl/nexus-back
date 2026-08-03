using System;
using System.Collections.Generic;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Practitioner;

/// <summary>
/// Representa la clasificación o agrupación principal de las especialidades médicas.
/// Represents the main classification or grouping of medical specialties.
/// </summary>
public class SpecialtyCategory : AuditableEntity
{
    public int CategoryId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string NameEs { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}
