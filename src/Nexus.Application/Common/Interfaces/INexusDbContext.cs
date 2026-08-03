using Microsoft.EntityFrameworkCore;

namespace Nexus.Application.Common.Interfaces;

public interface INexusDbContext
{
    public DbSet<Nexus.Domain.Entities.System.User> Users { get; }
    public DbSet<Nexus.Domain.Entities.System.AuditLog> AuditLogs { get; }
    public DbSet<Nexus.Domain.Entities.System.Configuration> Configurations { get; }
    public DbSet<Nexus.Domain.Entities.Geographic.Country> Countries { get; }
    public DbSet<Nexus.Domain.Entities.Geographic.State> States { get; }
    public DbSet<Nexus.Domain.Entities.Geographic.City> Cities { get; }
    public DbSet<Nexus.Domain.Entities.System.ContactType> ContactTypes { get; }
    public DbSet<Nexus.Domain.Entities.Practitioner.SpecialtyCategory> SpecialtyCategories { get; }
    public DbSet<Nexus.Domain.Entities.Practitioner.Specialty> Specialties { get; }
    public DbSet<Nexus.Domain.Entities.Pricing.Service> Services { get; }
    public DbSet<Nexus.Domain.Entities.Appointment.AppointmentStatus> AppointmentStatuses { get; }
    public DbSet<Nexus.Domain.Entities.Appointment.CancellationReason> CancellationReasons { get; }
    public DbSet<Nexus.Domain.Entities.Billing.PaymentStatus> PaymentStatuses { get; }
    public DbSet<Nexus.Domain.Entities.Billing.PaymentMethod> PaymentMethods { get; }
    public DbSet<Nexus.Domain.Entities.Pricing.Currency> Currencies { get; }
    public DbSet<Nexus.Domain.Entities.Billing.RefundStatus> RefundStatuses { get; }
    public DbSet<Nexus.Domain.Entities.Organization.OrganizationType> OrganizationTypes { get; }
    public DbSet<Nexus.Domain.Entities.Organization.Organization> Organizations { get; }
    public DbSet<Nexus.Domain.Entities.Organization.Location> Locations { get; }
    public DbSet<Nexus.Domain.Entities.Organization.LocationAddress> LocationAddresses { get; }
    public DbSet<Nexus.Domain.Entities.Organization.LocationContact> LocationContacts { get; }
    public DbSet<Nexus.Domain.Entities.Organization.LocationSpecialty> LocationSpecialties { get; }
    public DbSet<Nexus.Domain.Entities.Facility.Room> Rooms { get; }
    public DbSet<Nexus.Domain.Entities.Facility.Equipment> Equipments { get; }
    public DbSet<Nexus.Domain.Entities.Geographic.DocumentType> DocumentTypes { get; }
    public DbSet<Nexus.Domain.Entities.Practitioner.Practitioner> Practitioners { get; }
    public DbSet<Nexus.Domain.Entities.Practitioner.PractitionerContact> PractitionerContacts { get; }
    public DbSet<Nexus.Domain.Entities.Practitioner.PractitionerSpecialty> PractitionerSpecialties { get; }
    public DbSet<Nexus.Domain.Entities.Practitioner.PractitionerLocation> PractitionerLocations { get; }
    public DbSet<Nexus.Domain.Entities.Patient.Patient> Patients { get; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientRelation> PatientRelations { get; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientContact> PatientContacts { get; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientAddress> PatientAddresses { get; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientConsent> PatientConsents { get; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientInsurance> PatientInsurances { get; }
    public DbSet<Nexus.Domain.Entities.Insurance.CoverageType> CoverageTypes { get; }
    public DbSet<Nexus.Domain.Entities.Insurance.Payer> Payers { get; }
    public DbSet<Nexus.Domain.Entities.Insurance.Plan> Plans { get; }
    public DbSet<Nexus.Domain.Entities.Insurance.PayerProviderNetwork> PayerProviderNetworks { get; }
    public DbSet<Nexus.Domain.Entities.Scheduling.Weekday> Weekdays { get; }
    public DbSet<Nexus.Domain.Entities.Scheduling.PractitionerSchedule> PractitionerSchedules { get; }
    public DbSet<Nexus.Domain.Entities.Scheduling.ScheduleException> ScheduleExceptions { get; }
    public DbSet<Nexus.Domain.Entities.Scheduling.Slot> Slots { get; }
    public DbSet<Nexus.Domain.Entities.Scheduling.Waitlist> Waitlists { get; }
    public DbSet<Nexus.Domain.Entities.Appointment.Appointment> Appointments { get; }
    public DbSet<Nexus.Domain.Entities.Appointment.AppointmentClinicalDetail> AppointmentClinicalDetails { get; }
    public DbSet<Nexus.Domain.Entities.Appointment.TelehealthSession> TelehealthSessions { get; }
    public DbSet<Nexus.Domain.Entities.Appointment.AppointmentHistory> AppointmentHistories { get; }
    public DbSet<Nexus.Domain.Entities.Pricing.PriceList> PriceLists { get; }
    public DbSet<Nexus.Domain.Entities.Pricing.ServicePrice> ServicePrices { get; }
    public DbSet<Nexus.Domain.Entities.Billing.Invoice> Invoices { get; }
    public DbSet<Nexus.Domain.Entities.Billing.InvoiceLineItem> InvoiceLineItems { get; }
    public DbSet<Nexus.Domain.Entities.Billing.Payment> Payments { get; }
    public DbSet<Nexus.Domain.Entities.Billing.Refund> Refunds { get; }
    public DbSet<Nexus.Domain.Entities.Archive.AppointmentArchive> AppointmentArchives { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
