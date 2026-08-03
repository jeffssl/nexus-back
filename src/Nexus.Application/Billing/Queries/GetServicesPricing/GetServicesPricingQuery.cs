using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nexus.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Billing.Queries.GetServicesPricing;

public record ServicePricingDto(
    int ServiceId,
    string Code,
    string Name,
    decimal Price,
    string CurrencyCode
);

public record GetServicesPricingQuery(int? LocationId) : IRequest<List<ServicePricingDto>>;

public class GetServicesPricingQueryValidator : AbstractValidator<GetServicesPricingQuery>
{
    public GetServicesPricingQueryValidator()
    {
    }
}

public class GetServicesPricingQueryHandler : IRequestHandler<GetServicesPricingQuery, List<ServicePricingDto>>
{
    private readonly INexusDbContext _context;

    public GetServicesPricingQueryHandler(INexusDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServicePricingDto>> Handle(GetServicesPricingQuery request, CancellationToken cancellationToken)
    {
        var pricesQuery = _context.ServicePrices.Where(sp => sp.IsActive);
        
        if (request.LocationId.HasValue)
        {
            pricesQuery = pricesQuery.Where(sp => sp.LocationId == request.LocationId.Value || sp.LocationId == null);
        }

        var result = await (from sp in pricesQuery
                            join s in _context.Services on sp.ServiceId equals s.ServiceId
                            where s.IsActive
                            select new ServicePricingDto(
                                s.ServiceId,
                                s.Code,
                                s.Name,
                                sp.Price,
                                sp.CurrencyCode
                            )).ToListAsync(cancellationToken);

        return result;
    }
}
