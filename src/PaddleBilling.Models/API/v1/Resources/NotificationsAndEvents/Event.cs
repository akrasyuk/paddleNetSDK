using PaddleBilling.Models.API.v1.Resources.Enums;

namespace PaddleBilling.Models.API.v1.Resources.NotificationsAndEvents;

public class Event<TData> where TData : Entity
{
    public string EventId { get; set; }
    public EventType EventType { get; set; }
    public DateTime OccurredAt { get; set; }
    public TData Data { get; set; }
    public string NotificationId { get; set; }

    public Event(string eventId, EventType eventType, DateTime occurredAt, string notificationId, TData data)
    {
        EventId = eventId;
        EventType = eventType;
        OccurredAt = occurredAt;
        NotificationId = notificationId;
        Data = data;
    }
}