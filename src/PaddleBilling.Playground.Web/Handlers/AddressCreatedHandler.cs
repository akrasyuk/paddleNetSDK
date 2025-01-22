using PaddleBilling.Core.API.v1.Resources.Customers;
using PaddleBilling.Core.API.v1.Resources.NotificationsAndEvents;
using PaddleBilling.Webhooks;

namespace PaddleBilling.Playground.Web.Handlers;

public class AddressCreatedHandler : IPaddleWebhookHandler<Address>
{
    public Task HandleAsync(Event<Address> payload)
    {
        throw new NotImplementedException();
    }
}