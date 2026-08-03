using MediatR;
using Microsoft.Extensions.Logging;
using Nexus.Application.Appointments.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Nexus.Application.Notifications;

public class AppointmentCreatedEventHandler : INotificationHandler<AppointmentCreatedEvent>
{
    private readonly ILogger<AppointmentCreatedEventHandler> _logger;

    public AppointmentCreatedEventHandler(ILogger<AppointmentCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(AppointmentCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("================ NOTIFICATION SYSTEM ================");
        _logger.LogInformation($"Sending Email/WhatsApp to Patient {notification.PatientId}");
        _logger.LogInformation($"Message: Your appointment {notification.AppointmentId} is confirmed for {notification.AppointmentDate:O} with Practitioner {notification.PractitionerId}.");
        _logger.LogInformation("=====================================================");
        
        return Task.CompletedTask;
    }
}
