using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents
{
    /// <summary>
    /// Represents the error event structure.
    /// 
    /// Inherits from BaseEvent and includes error details.
    /// 
    /// Usage example:
    /// var errorEvent = new ErrorEvent
    /// {
    ///     EventId = "event_890",
    ///     ErrorDetails = new ErrorDetails
    ///     {
    ///         Type = "invalid_request_error",
    ///         Code = "invalid_event",
    ///         Message = "The 'type' field is missing.",
    ///         Param = null,
    ///         EventId = "event_567"
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(errorEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ErrorEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "error"
        /// </summary>
        public override string Type { get; set; } = "error";

        /// <summary>
        /// Gets or sets the details of the error.
        /// </summary>
        [JsonProperty("error")]
        public ErrorDetails ErrorDetails { get; set; }
    }

    /// <summary>
    /// Represents the details of an error.
    /// </summary>
    [Serializable]
    public class ErrorDetails
    {
        /// <summary>
        /// Gets or sets the type of the error.
        /// Example: "invalid_request_error"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the error code, if any.
        /// Example: "invalid_event"
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a human-readable error message.
        /// Example: "The 'type' field is missing."
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the parameter related to the error, if any.
        /// Example: null
        /// </summary>
        [JsonProperty("param")]
        public string Param { get; set; }

        /// <summary>
        /// Gets or sets the event_id of the client event that caused the error, if applicable.
        /// Example: "event_567"
        /// </summary>
        [JsonProperty("event_id")]
        public string RelatedEventId { get; set; }
    }
}
