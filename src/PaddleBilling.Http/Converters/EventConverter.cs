using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources;
using PaddleBilling.Models.API.v1.Resources.BillingAndSubscriptions;
using PaddleBilling.Models.API.v1.Resources.Customers;
using PaddleBilling.Models.API.v1.Resources.Enums;
using PaddleBilling.Models.API.v1.Resources.NotificationsAndEvents;
using PaddleBilling.Models.API.v1.Resources.ProductCatalog;

namespace PaddleBilling.Http.Converters;

public class EventConverter : JsonConverter<Event<Entity>>
{
    public override Event<Entity> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonDoc = JsonDocument.ParseValue(ref reader);
        var root = jsonDoc.RootElement;

        var eventType = root.GetProperty("event_type").Deserialize<EventType>(options);

        var eventId = root.GetProperty("event_id").GetString();
        var occurredAt = root.GetProperty("occurred_at").GetDateTime();
        var notificationId = root.GetProperty("notification_id").GetString();
        var data = root.GetProperty("data");

        var rawData = data.GetRawText();

        Entity eventData = eventType switch
        {
            EventType.AddressCreated or EventType.AddressUpdated or EventType.AddressImported => JsonSerializer
                .Deserialize<Address>(rawData, options),
            EventType.AdjustmentCreated or EventType.AdjustmentUpdated => JsonSerializer.Deserialize<Adjustment>(
                rawData, options),
            EventType.BusinessCreated or EventType.BusinessImported or EventType.BusinessUpdated => JsonSerializer
                .Deserialize<Business>(rawData, options),
            EventType.CustomerCreated or EventType.CustomerImported or EventType.CustomerUpdated => JsonSerializer
                .Deserialize<Customer>(rawData, options),
            EventType.DiscountCreated or EventType.DiscountImported or EventType.DiscountUpdated => JsonSerializer
                .Deserialize<Discount>(rawData, options),
            EventType.PayoutCreated or EventType.PayoutPaid => JsonSerializer.Deserialize<Payout>(rawData, options),
            EventType.PriceCreated or EventType.PriceImported or EventType.PriceUpdated => JsonSerializer
                .Deserialize<Price>(rawData, options),
            EventType.ProductCreated or EventType.ProductImported or EventType.ProductUpdated => JsonSerializer
                .Deserialize<Product>(rawData, options),
            EventType.ReportCreated or EventType.ReportUpdated => JsonSerializer.Deserialize<Report>(rawData, options),
            EventType.SubscriptionCreated or EventType.SubscriptionUpdated or EventType.SubscriptionActivated
                or EventType.SubscriptionCanceled or EventType.SubscriptionImported
                or EventType.SubscriptionPaused or EventType.SubscriptionResumed
                or EventType.SubscriptionPastDue
                or EventType.SubscriptionTrialing => JsonSerializer.Deserialize<Subscription>(rawData, options),
            EventType.TransactionCreated or EventType.TransactionUpdated or EventType.TransactionCompleted
                or EventType.TransactionCanceled or EventType.TransactionPaid
                or EventType.TransactionPaymentFailed or EventType.TransactionPastDue
                or EventType.TransactionReady
                or EventType.TransactionBilled => JsonSerializer.Deserialize<Transaction>(rawData, options),
            _ => throw new NotSupportedException($"Event type '{eventType}' is not supported.")
        };

        return new Event<Entity>(eventId, eventType, occurredAt, notificationId, eventData);
    }

    public override void Write(Utf8JsonWriter writer, Event<Entity> value, JsonSerializerOptions options)
    {
        //writer.WriteStartObject();
        //writer.WriteString("event_id", value.EventId);
        //writer.WriteString("event_type", EnumJsonPropertyNameMapper.GetValueFromJsonPropertyName<>(value.EventType));
        //writer.WriteString("occurred_at", value.OccurredAt);

        //writer.WritePropertyName("data");
        //JsonSerializer.Serialize(writer, value.Data, value.Data.GetType(), options);

        //writer.WriteEndObject();

        throw new NotImplementedException();
    }
}