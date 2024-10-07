using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Responses.Text
{
    /// <summary>
    /// Represents the response.text.delta event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseTextDeltaEvent = new ResponseTextDeltaEvent
    /// {
    ///     EventId = "event_4142",
    ///     ResponseId = "resp_001",
    ///     ItemId = "msg_007",
    ///     OutputIndex = 0,
    ///     ContentIndex = 0,
    ///     Delta = "Sure, I can h"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseTextDeltaEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseTextDeltaEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.text.delta"
        /// </summary>
        public override string Type { get; set; } = "response.text.delta";

        /// <summary>
        /// Gets or sets the ID of the response.
        /// Example: "resp_001"
        /// </summary>
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item.
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
        /// Gets or sets the text delta.
        /// Example: "Sure, I can h"
        /// </summary>
        [JsonProperty("delta")]
        public string Delta { get; set; }
    }
}
