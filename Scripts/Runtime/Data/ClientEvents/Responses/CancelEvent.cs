using System;

namespace OpenAIRealtime.Data.ClientEvents.Responses
{
    /// <summary>
    /// Represents the response.cancel event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseCancel = new ResponseCancelEvent
    /// {
    ///     EventId = "event_567"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseCancel, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseCancelEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.cancel"
        /// </summary>
        public override string Type { get; set; } = "response.cancel";
    }
}