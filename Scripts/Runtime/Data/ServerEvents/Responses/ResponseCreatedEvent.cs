using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace OpenAIRealtime.Data.ServerEvents.Responses
{
    /// <summary>
    /// Represents the response.created event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseCreatedEvent = new ResponseCreatedEvent
    /// {
    ///     EventId = "event_2930",
    ///     Response = new Response
    ///     {
    ///         Id = "resp_001",
    ///         ObjectType = "realtime.response",
    ///         Status = "in_progress",
    ///         StatusDetails = null,
    ///         Output = new List<object>(),
    ///         Usage = null
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseCreatedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseCreatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.created"
        /// </summary>
        public override string Type { get; set; } = "response.created";

        /// <summary>
        /// Gets or sets the response resource.
        /// </summary>
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}
