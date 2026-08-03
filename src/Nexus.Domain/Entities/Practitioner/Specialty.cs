using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Practitioner;

public class Specialty
{
    public int SpecialtyId { get; set; }
    public string SnomedCode { get; set; } = string.Empty;
    public string NameEs { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation properties
    public SpecialtyCategory? Category { get; set; }
}
