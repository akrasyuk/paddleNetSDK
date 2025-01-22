using PaddleBilling.Core.API.v1.Resources;
using PaddleBilling.Core.API.v1.Resources.NotificationsAndEvents;

namespace PaddleBilling.Webhooks.Interfaces;

public interface IPaddleWebhookHandler<TPayload> where TPayload : Entity
{
    Task HandleAsync(Event<TPayload> payload);
}