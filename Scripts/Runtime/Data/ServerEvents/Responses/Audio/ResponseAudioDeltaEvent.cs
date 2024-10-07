using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Responses.Audio
{
    /// <summary>
    /// Represents the response.audio.delta event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var responseAudioDeltaEvent = new ResponseAudioDeltaEvent
    /// {
    ///     EventId = "event_4950",
    ///     ResponseId = "resp_001",
    ///     ItemId = "msg_008",
    ///     OutputIndex = 0,
    ///     ContentIndex = 0,
    ///     Delta = "Base64EncodedAudioDelta"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(responseAudioDeltaEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ResponseAudioDeltaEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "response.audio.delta"
        /// </summary>
        public override string Type { get; set; } = "response.audio.delta";

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

        /// <summary>
        /// Gets or sets the Base64-encoded audio data delta.
        /// Example: "Base64EncodedAudioDelta"
        /// </summary>
        [JsonProperty("delta")]
        public string Delta { get; set; }
    }
}
