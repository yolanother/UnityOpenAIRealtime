using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Responses
{
    /// <summary>
    /// Represents the response.output_item.done event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseOutputItemDoneEvent = new ResponseOutputItemDoneEvent
    /// {
    ///     EventId = "event_3536",
    ///     ResponseId = "resp_001",
    ///     OutputIndex = 0,
    ///     Item = new ResponseItem
    ///     {
    ///         Id = "msg_007",
    ///         ObjectType = "realtime.item",
    ///         Type = "message",
    ///         Status = "completed",
    ///         Role = "assistant",
    ///         Content = new List<Content>
    ///         {
    ///             new Content
    ///             {
    ///                 Type = "text",
    ///                 Text = "Sure, I can help with that."
    ///             }
    ///         }
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseOutputItemDoneEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseOutputItemDoneEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.output_item.done"
        /// </summary>
        public override string Type { get; set; } = "response.output_item.done";

        /// <summary>
        /// Gets or sets the ID of the response to which the item belongs.
        /// Example: "resp_001"
        /// </summary>
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the index of the output item in the response.
        /// Example: 0
        /// </summary>
        [JsonProperty("output_index")]
        public int OutputIndex { get; set; }

        /// <summary>
        /// Gets or sets the completed item.
        /// </summary>
        [JsonProperty("item")]
        public ResponseItem Item { get; set; }
    }
}
