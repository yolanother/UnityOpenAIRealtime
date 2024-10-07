using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.InputAudioBuffers
{
    /// <summary>
    /// Represents the input_audio_buffer.committed event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var inputAudioBufferCommittedEvent = new InputAudioBufferCommittedEvent
    /// {
    ///     EventId = "event_1121",
    ///     PreviousItemId = "msg_001",
    ///     ItemId = "msg_002"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioBufferCommittedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioBufferCommittedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "input_audio_buffer.committed"
        /// </summary>
        public override string Type { get; set; } = "input_audio_buffer.committed";

        /// <summary>
        /// Gets or sets the ID of the preceding item after which the new item will be inserted.
        /// Example: "msg_001"
        /// </summary>
        [JsonProperty("previous_item_id")]
        public string PreviousItemId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user message item that will be created.
        /// Example: "msg_002"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}