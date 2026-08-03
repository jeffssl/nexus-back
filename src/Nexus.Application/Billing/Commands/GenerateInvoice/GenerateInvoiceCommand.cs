using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Billing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Billing.Commands.GenerateInvoice;

public record GenerateInvoiceCommand(Guid AppointmentId) : IRequest<Guid>;

public class GenerateInvoiceCommandValidator : AbstractValidator<GenerateInvoiceCommand>
{
    public GenerateInvoiceCommandValidator()
    {
        RuleFor(v => v.AppointmentId).NotEmpty();
    }
}

public class GenerateInvoiceCommandHandler : IRequestHandler<GenerateInvoiceCommand, Guid>
{
    private readonly INexusDbContext _context;

    public GenerateInvoiceCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(GenerateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == request.AppointmentId, cancellationToken);
            
        if (appointment == null)
            throw new Exception($"Appointment {request.AppointmentId} not found.");
            
        var invoice = await _context.Invoices
            .FirstOrDefaultAsync(i => i.AppointmentId == request.AppointmentId, cancellationToken);
            
        if (invoice != null)
            return invoice.InvoiceId; // already generated

        // For simplicity we pick the first active price for the service
        var price = await _context.ServicePrices
            .FirstOrDefaultAsync(sp => sp.ServiceId == appointment.ServiceId && sp.IsActive, cancellationToken);
            
        decimal unitPrice = price?.Price ?? 100.00m;
        string currency = price?.CurrencyCode ?? "USD";

        var newInvoice = new Invoice
        {
            InvoiceId = Guid.NewGuid(),
            TenantId = appointment.TenantId,
            InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(1000, 9999)}",
            AppointmentId = appointment.AppointmentId,
            PatientId = appointment.PatientId,
            IssueDate = DateTime.UtcNow.ToString("O"),
            DueDate = DateTime.UtcNow.AddDays(15).ToString("O"),
            Subtotal = unitPrice,
            Tax = 0,
            Discount = 0,
            Total = unitPrice,
            CurrencyCode = currency,
            StatusCode = "PENDING",
            Notes = "Generated automatically from completed appointment"
        };

        var lineItem = new InvoiceLineItem
        {
            InvoiceId = newInvoice.InvoiceId,
            ServiceId = appointment.ServiceId,
            Description = "Medical Service Consultation",
            Quantity = 1,
            UnitPrice = unitPrice,
            Subtotal = unitPrice,
            Tax = 0,
            Total = unitPrice
        };

        _context.Invoices.Add(newInvoice);
        _context.InvoiceLineItems.Add(lineItem);
        
        await _context.SaveChangesAsync(cancellationToken);

        return newInvoice.InvoiceId;
    }
}
