using wallet_stellar_api.Domain.Events;
using Microsoft.Extensions.Logging;

namespace wallet_stellar_api.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("wallet_stellar_api Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
