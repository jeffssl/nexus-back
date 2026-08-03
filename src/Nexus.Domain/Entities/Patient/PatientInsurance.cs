using System;
using Nexus.Domain.Common;

namespace Nexus.Domain.Entities.Patient;

/// <summary>
/// Represents the insurance coverage information for a patient.
/// Representa la información de cobertura de seguro para un paciente.
/// </summary>
public class PatientInsurance : AuditableEntity
{
    /// <summary>
    /// Unique identifier for the patient insurance record.
    /// Identificador único para el registro de seguro del paciente.
    /// </summary>
    public int PatientInsuranceId { get; set; }

    /// <summary>
    /// The patient to whom this insurance belongs.
    /// El paciente al que pertenece este seguro.
    /// </summary>
    public Guid PatientId { get; set; }

    /// <summary>
    /// The tenant this record belongs to (for multi-tenancy RLS).
    /// El inquilino al que pertenece este registro (para seguridad RLS).
    /// </summary>
    public Guid TenantId { get; set; }

    /// <summary>
    /// The payer/insurance company ID.
    /// El ID de la compañía aseguradora o pagador.
    /// </summary>
    public int PayerId { get; set; }

    /// <summary>
    /// The specific plan ID under the payer.
    /// El ID del plan específico bajo la aseguradora.
    /// </summary>
    public int? PlanId { get; set; }

    /// <summary>
    /// The patient's member or subscriber number.
    /// El número de miembro o suscriptor del paciente.
    /// </summary>
    public string? MemberNumber { get; set; }

    /// <summary>
    /// The policy or group number.
    /// El número de póliza o grupo.
    /// </summary>
    public string? PolicyNumber { get; set; }

    /// <summary>
    /// Start date of validity (ISO 8601).
    /// Fecha de inicio de validez (ISO 8601).
    /// </summary>
    public string ValidFrom { get; set; }

    /// <summary>
    /// End date of validity (ISO 8601).
    /// Fecha de fin de validez (ISO 8601).
    /// </summary>
    public string? ValidTo { get; set; }

    /// <summary>
    /// Indicates if this is the primary insurance.
    /// Indica si este es el seguro principal.
    /// </summary>
    public bool IsPrimary { get; set; }

    /// <summary>
    /// Indicates if the insurance record is active.
    /// Indica si el registro de seguro está activo.
    /// </summary>
    public bool IsActive { get; set; }
}
