using System.Text.Json;
using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources;
using PaddleBilling.Models.API.v1.Resources.BillingAndSubscriptions;
using PaddleBilling.Models.API.v1.Resources.Customers;
using PaddleBilling.Models.API.v1.Resources.Enums;
using PaddleBilling.Models.API.v1.Resources.ProductCatalog;
using PaddleBilling.Models.Json.Converters;

namespace PaddleBilling.Models.Json.Aot;

#region Primitives
[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(List<string>))]
[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(DateTimeOffset))]
[JsonSerializable(typeof(DateTimeOffset?))]
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(int?))]
#endregion
#region Shared
[JsonSerializable(typeof(Entity))]
[JsonSerializable(typeof(ImportMeta))]
[JsonSerializable(typeof(UnitPrice))]
[JsonSerializable(typeof(UnitPriceOverride))]
[JsonSerializable(typeof(TrialPeriod))]
[JsonSerializable(typeof(BillingCycle))]
[JsonSerializable(typeof(BillingPeriod))]
[JsonSerializable(typeof(PaymentTerms))]
[JsonSerializable(typeof(BillingDetails))]
[JsonSerializable(typeof(List<UnitPriceOverride>))]
#endregion
#region Address
[JsonSerializable(typeof(Address))]
#endregion
#region Adjustment
[JsonSerializable(typeof(AdjustmentItemTotals))]
[JsonSerializable(typeof(AdjustmentItem))]
[JsonSerializable(typeof(List<AdjustmentItem>))]
[JsonSerializable(typeof(AdjustmentTotals))]
[JsonSerializable(typeof(Adjustment))]
#endregion
#region Business
[JsonSerializable(typeof(Contact))]
[JsonSerializable(typeof(List<Contact>))]
[JsonSerializable(typeof(Business))]
#endregion
#region Customer
[JsonSerializable(typeof(Customer))]
#endregion
#region Discount
[JsonSerializable(typeof(Discount))]
#endregion
#region Payout
[JsonSerializable(typeof(Payout))]
#endregion
#region Price
[JsonSerializable(typeof(Quantity))]
[JsonSerializable(typeof(Price))]
#endregion
#region Product
[JsonSerializable(typeof(TaxCategory))]
[JsonSerializable(typeof(TaxCategory?))]
#endregion
#region Report
[JsonSerializable(typeof(Filter))]
[JsonSerializable(typeof(List<Filter>))]
[JsonSerializable(typeof(Report))]
#endregion
#region Subscription
[JsonSerializable(typeof(ScheduledChange))]
[JsonSerializable(typeof(DiscountInfo))]
[JsonSerializable(typeof(TrialDates))]
[JsonSerializable(typeof(QuantityRange))]
[JsonSerializable(typeof(ProductDetails))]
[JsonSerializable(typeof(PriceDetails))]
[JsonSerializable(typeof(SubscriptionItem))]
[JsonSerializable(typeof(List<SubscriptionItem>))]
[JsonSerializable(typeof(Subscription))]
#endregion
#region Transaction
[JsonSerializable(typeof(Card))]
[JsonSerializable(typeof(PaymentMethodDetails))]
[JsonSerializable(typeof(TransactionPayment))]
[JsonSerializable(typeof(List<TransactionPayment>))]
[JsonSerializable(typeof(TransactionCheckout))]
[JsonSerializable(typeof(Original))]
[JsonSerializable(typeof(ChargebackFee))]
#region Totals
[JsonSerializable(typeof(Totals))]
[JsonSerializable(typeof(TotalsWithDiscount))]
[JsonSerializable(typeof(TransactionTotals))]
[JsonSerializable(typeof(AdjustedTotals))]
[JsonSerializable(typeof(AdjustedPayoutTotals))]
#endregion
[JsonSerializable(typeof(TaxRates))]
[JsonSerializable(typeof(Proration))]
[JsonSerializable(typeof(LineItems))]
[JsonSerializable(typeof(TransactionDetails))]
[JsonSerializable(typeof(TransactionItem))]
[JsonSerializable(typeof(List<TransactionItem>))]
[JsonSerializable(typeof(Transaction))]
#endregion
[JsonSourceGenerationOptions(
    WriteIndented = true, 
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    Converters = [
        typeof(ItemTypeConverter), 
        typeof(NullableItemTypeConverter),
        typeof(TaxCategoryConverter),
        typeof(NullableTaxCategoryConverter),
    ]
    )]
public partial class PaddleBillingJsonSerializerContext : JsonSerializerContext
{
}