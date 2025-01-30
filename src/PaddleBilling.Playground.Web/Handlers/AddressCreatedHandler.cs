using PaddleBilling.Models.API.v1.Resources.Customers;
using PaddleBilling.Models.API.v1.Resources.NotificationsAndEvents;
using PaddleBilling.Webhooks.Interfaces;

namespace PaddleBilling.Playground.Web.Handlers;

public class AddressCreatedHandler : IPaddleWebhookHandler<Address>
{
    public Task HandleAsync(Event<Address> payload)
    {
        throw new NotImplementedException();
    }
}