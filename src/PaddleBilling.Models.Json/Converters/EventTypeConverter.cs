using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources.Enums;

namespace PaddleBilling.Models.Json.Converters;

public class EventTypeConverter : JsonConverter<EventType>
{
    private static readonly Dictionary<EventType, string> EventTypeToStringMap = new()
    {
        { EventType.AddressCreated, "address.created" },
        { EventType.AddressImported, "address.imported" },
        { EventType.AddressUpdated, "address.updated" },
        { EventType.AdjustmentCreated, "adjustment.created" },
        { EventType.AdjustmentUpdated, "adjustment.updated" },
        { EventType.BusinessCreated, "business.created" },
        { EventType.BusinessImported, "business.imported" },
        { EventType.BusinessUpdated, "business.updated" },
        { EventType.CustomerCreated, "customer.created" },
        { EventType.CustomerImported, "customer.imported" },
        { EventType.CustomerUpdated, "customer.updated" },
        { EventType.DiscountCreated, "discount.created" },
        { EventType.DiscountImported, "discount.imported" },
        { EventType.DiscountUpdated, "discount.updated" },
        { EventType.PaymentMethodSaved, "payment_method.saved" },
        { EventType.PaymentMethodDeleted, "payment_method.deleted" },
        { EventType.PayoutCreated, "payout.created" },
        { EventType.PayoutPaid, "payout.paid" },
        { EventType.PriceCreated, "price.created" },
        { EventType.PriceImported, "price.imported" },
        { EventType.PriceUpdated, "price.updated" },
        { EventType.ProductCreated, "product.created" },
        { EventType.ProductImported, "product.imported" },
        { EventType.ProductUpdated, "product.updated" },
        { EventType.ReportCreated, "report.created" },
        { EventType.ReportUpdated, "report.updated" },
        { EventType.SubscriptionActivated, "subscription.activated" },
        { EventType.SubscriptionCanceled, "subscription.canceled" },
        { EventType.SubscriptionCreated, "subscription.created" },
        { EventType.SubscriptionPastDue, "subscription.past_due" },
        { EventType.SubscriptionImported, "subscription.imported" },
        { EventType.SubscriptionPaused, "subscription.paused" },
        { EventType.SubscriptionResumed, "subscription.resumed" },
        { EventType.SubscriptionTrialing, "subscription.trialing" },
        { EventType.SubscriptionUpdated, "subscription.updated" },
        { EventType.TransactionBilled, "transaction.billed" },
        { EventType.TransactionCanceled, "transaction.canceled" },
        { EventType.TransactionCompleted, "transaction.completed" },
        { EventType.TransactionCreated, "transaction.created" },
        { EventType.TransactionPaid, "transaction.paid" },
        { EventType.TransactionPastDue, "transaction.past_due" },
        { EventType.TransactionPaymentFailed, "transaction.payment_failed" },
        { EventType.TransactionReady, "transaction.ready" },
        { EventType.TransactionUpdated, "transaction.updated" }
    };

    private static readonly Dictionary<string, EventType> StringToEventTypeMap = EventTypeToStringMap
        .ToDictionary(kv => kv.Value, kv => kv.Key);

    private static string GetString(EventType eventType)
    {
        if (EventTypeToStringMap.TryGetValue(eventType, out var value))
        {
            return value;
        }

        throw new ArgumentException($"Invalid EventType: {eventType}");
    }

    private static EventType GetEventType(string eventString)
    {
        if (StringToEventTypeMap.TryGetValue(eventString, out var value))
        {
            return value;
        }

        throw new ArgumentException($"Invalid EventType string: {eventString}");
    }

    public override EventType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        return GetEventType(stringValue);
    }

    public override void Write(Utf8JsonWriter writer, EventType value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(GetString(value));
    }
}