using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nexus.Application.Auth.Commands.GenerateToken;

public record GenerateTokenCommand(
    Guid TenantId,
    Guid UserId,
    string Email,
    string Role) : IRequest<string>;

public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
{
    public GenerateTokenCommandValidator()
    {
        RuleFor(v => v.TenantId).NotEmpty();
        RuleFor(v => v.UserId).NotEmpty();
        RuleFor(v => v.Email).NotEmpty().EmailAddress();
        RuleFor(v => v.Role).NotEmpty();
    }
}

public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
{
    private readonly IConfiguration _configuration;

    public GenerateTokenCommandHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "nexus-super-secret-key-1234567890!"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, request.Email),
            new Claim("tenantId", request.TenantId.ToString()),
            new Claim(ClaimTypes.Role, request.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"] ?? "Nexus",
            audience: _configuration["Jwt:Audience"] ?? "NexusApi",
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}
