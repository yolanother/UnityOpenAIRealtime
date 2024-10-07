using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Sessions
{
    /// <summary>
    /// Represents the session.created event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var sessionCreatedEvent = new SessionCreatedEvent
    /// {
    ///     EventId = "event_1234",
    ///     Session = new Session
    ///     {
    ///         // Session properties go here
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(sessionCreatedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class SessionCreatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "session.created"
        /// </summary>
        public override string Type { get; set; } = "session.created";

        /// <summary>
        /// Gets or sets the session object that was created.
        /// </summary>
        [JsonProperty("session")]
        public Session Session { get; set; }
    }
}