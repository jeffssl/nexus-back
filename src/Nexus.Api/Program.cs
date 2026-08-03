using Nexus.Api.Endpoints;
using Nexus.Api.Infrastructure;
using Nexus.Application;
using Nexus.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Exception Handling & Problem Details
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "Nexus",
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "NexusApi",
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "nexus-super-secret-key-1234567890!"))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler(); // Uses the registered IExceptionHandler
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Map Endpoints
app.MapAuthEndpoints();
app.MapOrganizationsEndpoints();
app.MapPractitionersEndpoints();
app.MapLocationsEndpoints();
app.MapCatalogsEndpoints();
app.MapGeographicEndpoints();
app.MapFacilitiesEndpoints();
app.MapPatientsEndpoints();
app.MapSchedulesEndpoints();
app.MapBookingsEndpoints();
app.MapAnalyticsEndpoints();
app.MapBillingEndpoints();
app.MapWaitlistsEndpoints();
app.MapSystemEndpoints();
app.MapPricingEndpoints();

app.Run();
