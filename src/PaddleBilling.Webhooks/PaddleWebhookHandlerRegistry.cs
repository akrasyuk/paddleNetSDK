using PaddleBilling.Core.API.v1.Resources;
using PaddleBilling.Core.API.v1.Resources.Enums;
using PaddleBilling.Core.Extensions;

namespace PaddleBilling.Webhooks;

public class PaddleWebhookHandlerRegistry
{
    private readonly Dictionary<EventType, Type> _handlers = new();

    public string Endpoint { get; private set; } = "/webhooks";

    public void SetEndpoint(string endpoint)
    {
        Endpoint = endpoint;
    }

    public void AddHandler<THandler>(EventType eventType)
    {
        var handlerInterface = typeof(THandler).GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPaddleWebhookHandler<>));

        if (handlerInterface == null)
        {
            throw new InvalidOperationException(
                $"Handler {typeof(THandler).Name} must implement IPaddleWebhookHandler<T>."
            );
        }

        var payloadType = handlerInterface.GetGenericArguments()[0];

        var expectedPayloadType = eventType.GetPayloadType();
        if (expectedPayloadType != payloadType)
        {
            throw new InvalidOperationException(
                $"Handler {typeof(THandler).Name} is registered for {eventType} but expects payload {payloadType.Name} instead of {expectedPayloadType.Name}."
            );
        }

        if (_handlers.ContainsKey(eventType))
            throw new InvalidOperationException($"Handler for event type '{eventType}' is already registered.");

        _handlers[eventType] = typeof(THandler);
    }

    public IEnumerable<Type> GetHandlers()
    {
        foreach (var handler in _handlers.Values)
        {
            yield return handler;
        }
    }

    public bool TryGetHandler(EventType eventType, out Type handlerType)
    {
        if (_handlers.TryGetValue(eventType, out var handlerInfo))
        {
            handlerType = handlerInfo;
            return true;
        }

        handlerType = null;
        return false;
    }

    public Type GetPayloadType(EventType eventType)
    {
        return _handlers[eventType];
    }
}