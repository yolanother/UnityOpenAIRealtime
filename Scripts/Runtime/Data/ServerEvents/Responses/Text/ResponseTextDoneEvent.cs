using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Responses.Text
{
    /// <summary>
    /// Represents the response.text.done event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseTextDoneEvent = new ResponseTextDoneEvent
    /// {
    ///     EventId = "event_4344",
    ///     ResponseId = "resp_001",
    ///     ItemId = "msg_007",
    ///     OutputIndex = 0,
    ///     ContentIndex = 0,
    ///     Text = "Sure, I can help with that."
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseTextDoneEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseTextDoneEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.text.done"
        /// </summary>
        public override string Type { get; set; } = "response.text.done";

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
        /// Gets or sets the final text content.
        /// Example: "Sure, I can help with that."
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
