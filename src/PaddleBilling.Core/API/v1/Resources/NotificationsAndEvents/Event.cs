using System.Text.Json.Serialization;
using PaddleBilling.Core.API.v1.Resources.Enums;
using PaddleBilling.Core.Converters;

namespace PaddleBilling.Core.API.v1.Resources.NotificationsAndEvents;

[JsonConverter(typeof(EventConverter))]
public class Event<TData> where TData : Entity
{
    public string EventId { get; set; }
    public EventType EventType { get; set; }
    public DateTime OccurredAt { get; set; }
    public TData Data { get; set; }
    public string NotificationId { get; set; }
}