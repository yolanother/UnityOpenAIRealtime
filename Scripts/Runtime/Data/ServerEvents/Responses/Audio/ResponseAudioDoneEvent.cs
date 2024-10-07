using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Responses.Audio
{
    /// <summary>
    /// Represents the response.audio.done event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseAudioDoneEvent = new ResponseAudioDoneEvent
    /// {
    ///     EventId = "event_5152",
    ///     ResponseId = "resp_001",
    ///     ItemId = "msg_008",
    ///     OutputIndex = 0,
    ///     ContentIndex = 0
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseAudioDoneEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseAudioDoneEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.audio.done"
        /// </summary>
        public override string Type { get; set; } = "response.audio.done";

        /// <summary>
        /// Gets or sets the ID of the response.
        /// Example: "resp_001"
        /// </summary>
        [JsonProperty("response_id")]
        public string ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item.
        /// Example: "msg_008"
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
    }
}