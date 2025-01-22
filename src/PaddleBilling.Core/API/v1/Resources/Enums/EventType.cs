using System.Text.Json.Serialization;
using PaddleBilling.Core.Converters;

namespace PaddleBilling.Core.API.v1.Resources.Enums;

[JsonConverter(typeof(BidirectionalJsonStringEnumConverter<EventType>))]
public enum EventType
{
    [JsonPropertyName("address.created")]
    AddressCreated,

    [JsonPropertyName("address.imported")]
    AddressImported,

    [JsonPropertyName("address.updated")]
    AddressUpdated,

    [JsonPropertyName("adjustment.created")]
    AdjustmentCreated,

    [JsonPropertyName("adjustment.updated")]
    AdjustmentUpdated,

    [JsonPropertyName("business.created")]
    BusinessCreated,

    [JsonPropertyName("business.imported")]
    BusinessImported,

    [JsonPropertyName("business.updated")]
    BusinessUpdated,

    [JsonPropertyName("customer.created")]
    CustomerCreated,

    [JsonPropertyName("customer.imported")]
    CustomerImported,

    [JsonPropertyName("customer.updated")]
    CustomerUpdated,

    [JsonPropertyName("discount.created")]
    DiscountCreated,

    [JsonPropertyName("discount.imported")]
    DiscountImported,

    [JsonPropertyName("discount.updated")]
    DiscountUpdated,

    [JsonPropertyName("payment_method.saved")]
    PaymentMethodSaved,

    [JsonPropertyName("payment_method.deleted")]
    PaymentMethodDeleted,

    [JsonPropertyName("payout.created")]
    PayoutCreated,

    [JsonPropertyName("payout.paid")]
    PayoutPaid,

    [JsonPropertyName("price.created")]
    PriceCreated,

    [JsonPropertyName("price.imported")]
    PriceImported,

    [JsonPropertyName("price.updated")]
    PriceUpdated,

    [JsonPropertyName("product.created")]
    ProductCreated,

    [JsonPropertyName("product.imported")]
    ProductImported,

    [JsonPropertyName("product.updated")]
    ProductUpdated,

    [JsonPropertyName("report.created")]
    ReportCreated,

    [JsonPropertyName("report.updated")]
    ReportUpdated,

    [JsonPropertyName("subscription.activated")]
    SubscriptionActivated,

    [JsonPropertyName("subscription.canceled")]
    SubscriptionCanceled,

    [JsonPropertyName("subscription.created")]
    SubscriptionCreated,

    [JsonPropertyName("subscription.past_due")]
    SubscriptionPastDue,

    [JsonPropertyName("subscription.imported")]
    SubscriptionImported,

    [JsonPropertyName("subscription.paused")]
    SubscriptionPaused,

    [JsonPropertyName("subscription.resumed")]
    SubscriptionResumed,

    [JsonPropertyName("subscription.trialing")]
    SubscriptionTrialing,

    [JsonPropertyName("subscription.updated")]
    SubscriptionUpdated,

    [JsonPropertyName("transaction.billed")]
    TransactionBilled,

    [JsonPropertyName("transaction.canceled")]
    TransactionCanceled,

    [JsonPropertyName("transaction.completed")]
    TransactionCompleted,

    [JsonPropertyName("transaction.created")]
    TransactionCreated,

    [JsonPropertyName("transaction.paid")]
    TransactionPaid,

    [JsonPropertyName("transaction.past_due")]
    TransactionPastDue,

    [JsonPropertyName("transaction.payment_failed")]
    TransactionPaymentFailed,

    [JsonPropertyName("transaction.ready")]
    TransactionReady,

    [JsonPropertyName("transaction.updated")]
    TransactionUpdated
}