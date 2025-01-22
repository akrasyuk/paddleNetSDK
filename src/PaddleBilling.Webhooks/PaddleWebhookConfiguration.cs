using PaddleBilling.Core.API.v1.Resources.Enums;
using PaddleBilling.Core.API.v1.Resources.NotificationsAndEvents;
using PaddleBilling.Core.Extensions;

namespace PaddleBilling.Webhooks;

public class PaddleWebhookConfiguration
{
    private readonly Dictionary<EventType, WebhookHandlerInfo> _handlers = new();

    public string Endpoint { get; private set; } = "/webhooks";

    public void SetEndpoint(string endpoint)
    {
        Endpoint = endpoint;
    }

    public void AddHandler<THandler>(EventType type)
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

        var expectedPayloadType = type.GetPayloadType();
        if (expectedPayloadType != payloadType)
        {
            throw new InvalidOperationException(
                $"Handler {typeof(THandler).Name} is registered for {type} but expects payload {payloadType.Name} instead of {expectedPayloadType.Name}."
            );
        }

        if (_handlers.ContainsKey(type))
            throw new InvalidOperationException($"Handler for event type '{type}' is already registered.");

        var eventType = typeof(Event<>).MakeGenericType(payloadType);
        var handleMethod = handlerInterface.GetMethod("HandleAsync");

        if (handleMethod == null)
            throw new InvalidOperationException(
                $"Handler {typeof(THandler).Name} must implement a method named 'HandleAsync'.");


        _handlers[type] = new WebhookHandlerInfo(typeof(THandler), payloadType, eventType, handleMethod);
    }

    public IEnumerable<WebhookHandlerInfo> GetHandlers()
    {
        return _handlers.Values;
    }

    public bool TryGetHandler(EventType eventType, out WebhookHandlerInfo handlerInfo)
    {
        if (_handlers.TryGetValue(eventType, out var value))
        {
            handlerInfo = value;
            return true;
        }

        handlerInfo = default;
        return false;
    }
}