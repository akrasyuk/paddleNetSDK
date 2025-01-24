namespace PaddleBilling.Models.API.v1.Resources.NotificationsAndEvents;

public class NotificationDestination : Entity
{
    /// <summary>
    /// Short description for this notification destination. Shown in the Paddle dashboard.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Where notifications should be sent for this destination.
    /// Can be "email" or "url".
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Webhook endpoint URL or email address.
    /// </summary>
    public string Destination { get; set; }

    /// <summary>
    /// Whether Paddle should try to deliver events to this notification destination.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// API version that returned objects for events should conform to.
    /// Must be a valid version of the Paddle API. Can't be a version older than your account default.
    /// </summary>
    public int ApiVersion { get; set; }

    /// <summary>
    /// Whether potentially sensitive fields should be sent to this notification destination.
    /// </summary>
    public bool IncludeSensitiveFields { get; set; }

    /// <summary>
    /// Subscribed events for this notification destination.
    /// </summary>
    public List<SubscribedEvent> SubscribedEvents { get; set; }

    /// <summary>
    /// Webhook destination secret key, prefixed with pdl_ntfset_.
    /// Used for signature verification.
    /// </summary>
    public string EndpointSecretKey { get; set; }

    /// <summary>
    /// Whether Paddle should deliver real platform events, simulation events, or both to this notification destination.
    /// Can be "platform", "simulation", or "all".
    /// </summary>
    public string TrafficSource { get; set; }
}

public class SubscribedEvent
{
    /// <summary>
    /// Type of event sent by Paddle, in the format entity.event_type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Short description of this event type.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Group for this event type. Typically the entity that this event relates to.
    /// </summary>
    public string Group { get; set; }

    /// <summary>
    /// List of API versions that this event type supports.
    /// </summary>
    public List<int> AvailableVersions { get; set; }
}