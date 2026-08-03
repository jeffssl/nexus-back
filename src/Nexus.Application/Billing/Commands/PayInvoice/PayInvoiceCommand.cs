using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using Nexus.Domain.Entities.Billing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Billing.Commands.PayInvoice;

public record PayInvoiceCommand(Guid InvoiceId, int PaymentMethodId, string TransactionReference) : IRequest<bool>;

public class PayInvoiceCommandValidator : AbstractValidator<PayInvoiceCommand>
{
    public PayInvoiceCommandValidator()
    {
        RuleFor(v => v.InvoiceId).NotEmpty();
        RuleFor(v => v.PaymentMethodId).GreaterThan(0);
    }
}

public class PayInvoiceCommandHandler : IRequestHandler<PayInvoiceCommand, bool>
{
    private readonly INexusDbContext _context;

    public PayInvoiceCommandHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(PayInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _context.Invoices
            .FirstOrDefaultAsync(i => i.InvoiceId == request.InvoiceId, cancellationToken);
            
        if (invoice == null)
            throw new Exception($"Invoice {request.InvoiceId} not found.");
            
        if (invoice.StatusCode == "PAID")
            throw new Exception($"Invoice {request.InvoiceId} is already paid.");

        invoice.StatusCode = "PAID";
        
        var payment = new Payment
        {
            PaymentId = Guid.NewGuid(),
            TenantId = invoice.TenantId,
            PaymentNumber = $"PAY-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(1000, 9999)}",
            InvoiceId = invoice.InvoiceId,
            Amount = invoice.Total,
            CurrencyCode = invoice.CurrencyCode,
            PaymentMethodId = request.PaymentMethodId,
            StatusCode = "SUCCESS",
            TransactionReference = request.TransactionReference,
            ProcessedAt = DateTimeOffset.UtcNow,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
