using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.InputAudioBuffers
{
    /// <summary>
    /// Represents the input_audio_buffer.speech_stopped event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var inputAudioBufferSpeechStoppedEvent = new InputAudioBufferSpeechStoppedEvent
    /// {
    ///     EventId = "event_1718",
    ///     AudioEndMs = 2000,
    ///     ItemId = "msg_003"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioBufferSpeechStoppedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioBufferSpeechStoppedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "input_audio_buffer.speech_stopped"
        /// </summary>
        public override string Type { get; set; } = "input_audio_buffer.speech_stopped";

        /// <summary>
        /// Gets or sets the milliseconds since the session started when speech stopped.
        /// Example: 2000
        /// </summary>
        [JsonProperty("audio_end_ms")]
        public int AudioEndMs { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user message item that will be created.
        /// Example: "msg_003"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}