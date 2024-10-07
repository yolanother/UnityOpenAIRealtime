using Newtonsoft.Json;
using System;
using OpenAIRealtime.Data.ServerEvents.Common;

namespace OpenAIRealtime.Data.ServerEvents.Responses.ContentParts
{
    /// <summary>
    /// Represents the response.content_part.added event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseContentPartAddedEvent = new ResponseContentPartAddedEvent
    /// {
    ///     EventId = "event_3738",
    ///     ResponseId = "resp_001",
    ///     ItemId = "msg_007",
    ///     OutputIndex = 0,
    ///     ContentIndex = 0,
    ///     Part = new ContentPart
    ///     {
    ///         Type = "text",
    ///         Text = ""
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseContentPartAddedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseContentPartAddedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.content_part.added"
        /// </summary>
        public override string Type { get; set; } = "response.content_part.added";

        /// <summary>
        /// Gets or sets the ID of the response.
        /// Example: "resp_001"
        /// </summary>
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item to which the content part was added.
        /// Example: "msg_007"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the index of the output item in the response.
        /// Example: 0
        /// </summary>
        [JsonProperty("output_index")]
        public int OutputIndex { get; set; }

        /// <summary>
        /// Gets or sets the index of the content part in the item's content array.
        /// Example: 0
        /// </summary>
        [JsonProperty("content_index")]
        public int ContentIndex { get; set; }

        /// <summary>
        /// Gets or sets the content part that was added.
        /// </summary>
        [JsonProperty("part")]
        public ContentPart Part { get; set; }
    }
}
