using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Infrastructure.Persistence.Interceptors;

namespace Nexus.Infrastructure.Persistence;

public class NexusDbContext : DbContext, INexusDbContext
{
    private readonly AuditableEntityInterceptor _auditableEntityInterceptor;

    public NexusDbContext(
        DbContextOptions<NexusDbContext> options, 
        AuditableEntityInterceptor auditableEntityInterceptor) 
        : base(options)
    {
        _auditableEntityInterceptor = auditableEntityInterceptor;
    }

    public DbSet<Nexus.Domain.Entities.System.User> Users { get; set; }
    public DbSet<Nexus.Domain.Entities.System.AuditLog> AuditLogs { get; set; }
    public DbSet<Nexus.Domain.Entities.System.Configuration> Configurations { get; set; }
    public DbSet<Nexus.Domain.Entities.Geographic.Country> Countries { get; set; }
    public DbSet<Nexus.Domain.Entities.Geographic.State> States { get; set; }
    public DbSet<Nexus.Domain.Entities.Geographic.City> Cities { get; set; }
    public DbSet<Nexus.Domain.Entities.System.ContactType> ContactTypes { get; set; }
    public DbSet<Nexus.Domain.Entities.Practitioner.SpecialtyCategory> SpecialtyCategories { get; set; }
    public DbSet<Nexus.Domain.Entities.Practitioner.Specialty> Specialties { get; set; }
    public DbSet<Nexus.Domain.Entities.Pricing.Service> Services { get; set; }
    public DbSet<Nexus.Domain.Entities.Appointment.AppointmentStatus> AppointmentStatuses { get; set; }
    public DbSet<Nexus.Domain.Entities.Appointment.CancellationReason> CancellationReasons { get; set; }
    public DbSet<Nexus.Domain.Entities.Billing.PaymentStatus> PaymentStatuses { get; set; }
    public DbSet<Nexus.Domain.Entities.Billing.PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Nexus.Domain.Entities.Pricing.Currency> Currencies { get; set; }
    public DbSet<Nexus.Domain.Entities.Billing.RefundStatus> RefundStatuses { get; set; }
    public DbSet<Nexus.Domain.Entities.Organization.OrganizationType> OrganizationTypes { get; set; }
    public DbSet<Nexus.Domain.Entities.Organization.Organization> Organizations { get; set; }
    public DbSet<Nexus.Domain.Entities.Organization.Location> Locations { get; set; }
    public DbSet<Nexus.Domain.Entities.Organization.LocationAddress> LocationAddresses { get; set; }
    public DbSet<Nexus.Domain.Entities.Organization.LocationContact> LocationContacts { get; set; }
    public DbSet<Nexus.Domain.Entities.Organization.LocationSpecialty> LocationSpecialties { get; set; }
    public DbSet<Nexus.Domain.Entities.Facility.Room> Rooms { get; set; }
    public DbSet<Nexus.Domain.Entities.Facility.Equipment> Equipments { get; set; }
    public DbSet<Nexus.Domain.Entities.Geographic.DocumentType> DocumentTypes { get; set; }
    public DbSet<Nexus.Domain.Entities.Practitioner.Practitioner> Practitioners { get; set; }
    public DbSet<Nexus.Domain.Entities.Practitioner.PractitionerContact> PractitionerContacts { get; set; }
    public DbSet<Nexus.Domain.Entities.Practitioner.PractitionerSpecialty> PractitionerSpecialties { get; set; }
    public DbSet<Nexus.Domain.Entities.Practitioner.PractitionerLocation> PractitionerLocations { get; set; }
    public DbSet<Nexus.Domain.Entities.Patient.Patient> Patients { get; set; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientRelation> PatientRelations { get; set; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientContact> PatientContacts { get; set; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientAddress> PatientAddresses { get; set; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientConsent> PatientConsents { get; set; }
    public DbSet<Nexus.Domain.Entities.Patient.PatientInsurance> PatientInsurances { get; set; }
    public DbSet<Nexus.Domain.Entities.Insurance.CoverageType> CoverageTypes { get; set; }
    public DbSet<Nexus.Domain.Entities.Insurance.Payer> Payers { get; set; }
    public DbSet<Nexus.Domain.Entities.Insurance.Plan> Plans { get; set; }
    public DbSet<Nexus.Domain.Entities.Insurance.PayerProviderNetwork> PayerProviderNetworks { get; set; }
    public DbSet<Nexus.Domain.Entities.Scheduling.Weekday> Weekdays { get; set; }
    public DbSet<Nexus.Domain.Entities.Scheduling.PractitionerSchedule> PractitionerSchedules { get; set; }
    public DbSet<Nexus.Domain.Entities.Scheduling.ScheduleException> ScheduleExceptions { get; set; }
    public DbSet<Nexus.Domain.Entities.Scheduling.Slot> Slots { get; set; }
    public DbSet<Nexus.Domain.Entities.Scheduling.Waitlist> Waitlists { get; set; }
    public DbSet<Nexus.Domain.Entities.Appointment.Appointment> Appointments { get; set; }
    public DbSet<Nexus.Domain.Entities.Appointment.AppointmentClinicalDetail> AppointmentClinicalDetails { get; set; }
    public DbSet<Nexus.Domain.Entities.Appointment.TelehealthSession> TelehealthSessions { get; set; }
    public DbSet<Nexus.Domain.Entities.Appointment.AppointmentHistory> AppointmentHistories { get; set; }
    public DbSet<Nexus.Domain.Entities.Pricing.PriceList> PriceLists { get; set; }
    public DbSet<Nexus.Domain.Entities.Pricing.ServicePrice> ServicePrices { get; set; }
    public DbSet<Nexus.Domain.Entities.Billing.Invoice> Invoices { get; set; }
    public DbSet<Nexus.Domain.Entities.Billing.InvoiceLineItem> InvoiceLineItems { get; set; }
    public DbSet<Nexus.Domain.Entities.Billing.Payment> Payments { get; set; }
    public DbSet<Nexus.Domain.Entities.Billing.Refund> Refunds { get; set; }
    public DbSet<Nexus.Domain.Entities.Archive.AppointmentArchive> AppointmentArchives { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Apply configurations from the current assembly (OrganizationConfiguration, etc.)
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntityInterceptor);
    }
}
