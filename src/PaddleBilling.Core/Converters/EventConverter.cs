using System.Text.Json.Serialization;
using System.Text.Json;
using PaddleBilling.Core.API.v1.Resources;
using PaddleBilling.Core.API.v1.Resources.BillingAndSubscriptions;
using PaddleBilling.Core.API.v1.Resources.Customers;
using PaddleBilling.Core.API.v1.Resources.Enums;
using PaddleBilling.Core.API.v1.Resources.NotificationsAndEvents;
using PaddleBilling.Core.API.v1.Resources.ProductCatalog;

namespace PaddleBilling.Core.Converters;

public class EventConverter : JsonConverter<Event<Entity>>
{
    public override Event<Entity> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        var eventType = Enum.Parse<EventType>(root.GetProperty("EventType").GetString());
        var eventId = root.GetProperty("EventId").GetString();
        var occurredAt = root.GetProperty("OccurredAt").GetDateTime();
        var notificationId = root.GetProperty("NotificationId").GetString();
        var data = root.GetProperty("Data");

        var rawData = data.GetRawText();

        Entity eventData = eventType switch
        {
            EventType.AddressCreated => JsonSerializer.Deserialize<Address>(rawData, options),
            EventType.AddressImported => JsonSerializer.Deserialize<Address>(rawData, options),
            EventType.AddressUpdated => JsonSerializer.Deserialize<Address>(rawData, options),
            EventType.AdjustmentCreated => JsonSerializer.Deserialize<Adjustment>(rawData, options),
            EventType.AdjustmentUpdated => JsonSerializer.Deserialize<Adjustment>(rawData, options),
            EventType.BusinessCreated => JsonSerializer.Deserialize<Business>(rawData, options),
            EventType.BusinessImported => JsonSerializer.Deserialize<Business>(rawData, options),
            EventType.BusinessUpdated => JsonSerializer.Deserialize<Business>(rawData, options),
            EventType.CustomerCreated => JsonSerializer.Deserialize<Customer>(rawData, options),
            EventType.CustomerImported => JsonSerializer.Deserialize<Customer>(rawData, options),
            EventType.CustomerUpdated => JsonSerializer.Deserialize<Customer>(rawData, options),
            EventType.DiscountCreated => JsonSerializer.Deserialize<Discount>(rawData, options),
            EventType.DiscountImported => JsonSerializer.Deserialize<Discount>(rawData, options),
            EventType.DiscountUpdated => JsonSerializer.Deserialize<Discount>(rawData, options),
            EventType.PayoutCreated => JsonSerializer.Deserialize<Payout>(rawData, options),
            EventType.PayoutPaid => JsonSerializer.Deserialize<Payout>(rawData, options),
            EventType.PriceCreated => JsonSerializer.Deserialize<Price>(rawData, options),
            EventType.PriceImported => JsonSerializer.Deserialize<Price>(rawData, options),
            EventType.PriceUpdated => JsonSerializer.Deserialize<Price>(rawData, options),
            EventType.ProductCreated => JsonSerializer.Deserialize<Product>(rawData, options),
            EventType.ProductImported => JsonSerializer.Deserialize<Product>(rawData, options),
            EventType.ProductUpdated => JsonSerializer.Deserialize<Product>(rawData, options),
            EventType.ReportCreated => JsonSerializer.Deserialize<Report>(rawData, options),
            EventType.ReportUpdated => JsonSerializer.Deserialize<Report>(rawData, options),
            EventType.SubscriptionActivated => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionCanceled => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionCreated => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionImported => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionPastDue => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionPaused => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionResumed => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionTrialing => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.SubscriptionUpdated => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.TransactionBilled => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionCanceled => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionCompleted => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionCreated => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionPaid => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionPastDue => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionPaymentFailed => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionReady => JsonSerializer.Deserialize<Transaction>(rawData, options),
            EventType.TransactionUpdated => JsonSerializer.Deserialize<Transaction>(rawData, options),
            _ => throw new NotSupportedException($"Event type '{eventType}' is not supported.")
        };

        return new Event<Entity>
        {
            EventId = eventId,
            EventType = eventType,
            OccurredAt = occurredAt,
            Data = eventData,
            NotificationId = notificationId
        };
    }

    public override void Write(Utf8JsonWriter writer, Event<Entity> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("EventId", value.EventId);
        writer.WriteString("EventType", value.EventType.ToString());
        writer.WriteString("OccurredAt", value.OccurredAt);

        writer.WritePropertyName("Data");
        JsonSerializer.Serialize(writer, value.Data, value.Data.GetType(), options);

        writer.WriteEndObject();
    }
}