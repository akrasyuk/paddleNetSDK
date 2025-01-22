using PaddleBilling.Core.API.v1.Resources;
using PaddleBilling.Core.API.v1.Resources.BillingAndSubscriptions;
using PaddleBilling.Core.API.v1.Resources.Customers;
using PaddleBilling.Core.API.v1.Resources.Enums;
using PaddleBilling.Core.API.v1.Resources.ProductCatalog;

namespace PaddleBilling.Core.Extensions;

public static class EventTypeExtensions
{
    public static Type GetPayloadType(this EventType eventType)
    {
        return eventType switch
        {
            EventType.AddressCreated => typeof(Address),
            EventType.AddressImported => typeof(Address),
            EventType.AddressUpdated => typeof(Address),
            EventType.AdjustmentCreated => typeof(Adjustment),
            EventType.AdjustmentUpdated => typeof(Adjustment),
            EventType.BusinessCreated => typeof(Business),
            EventType.BusinessImported => typeof(Business),
            EventType.BusinessUpdated => typeof(Business),
            EventType.CustomerCreated => typeof(Customer),
            EventType.CustomerImported => typeof(Customer),
            EventType.CustomerUpdated => typeof(Customer),
            EventType.DiscountCreated => typeof(Discount),
            EventType.DiscountImported => typeof(Discount),
            EventType.DiscountUpdated => typeof(Discount),
            EventType.PayoutCreated => typeof(Payout),
            EventType.PayoutPaid => typeof(Payout),
            EventType.PriceCreated => typeof(Price),
            EventType.PriceImported => typeof(Price),
            EventType.PriceUpdated => typeof(Price),
            EventType.ProductCreated => typeof(Product),
            EventType.ProductImported => typeof(Product),
            EventType.ProductUpdated => typeof(Product),
            EventType.ReportCreated => typeof(Report),
            EventType.ReportUpdated => typeof(Report),
            EventType.SubscriptionActivated => typeof(Subscription),
            EventType.SubscriptionCanceled => typeof(Subscription),
            EventType.SubscriptionCreated => typeof(Subscription),
            EventType.SubscriptionImported => typeof(Subscription),
            EventType.SubscriptionPastDue => typeof(Subscription),
            EventType.SubscriptionPaused => typeof(Subscription),
            EventType.SubscriptionResumed => typeof(Subscription),
            EventType.SubscriptionTrialing => typeof(Subscription),
            EventType.SubscriptionUpdated => typeof(Subscription),
            EventType.TransactionBilled => typeof(Transaction),
            EventType.TransactionCanceled => typeof(Transaction),
            EventType.TransactionCompleted => typeof(Transaction),
            EventType.TransactionCreated => typeof(Transaction),
            EventType.TransactionPaid => typeof(Transaction),
            EventType.TransactionPastDue => typeof(Transaction),
            EventType.TransactionPaymentFailed => typeof(Transaction),
            _ => throw new InvalidOperationException($"No payload type defined for event type '{eventType}'.")
        };
    }
}