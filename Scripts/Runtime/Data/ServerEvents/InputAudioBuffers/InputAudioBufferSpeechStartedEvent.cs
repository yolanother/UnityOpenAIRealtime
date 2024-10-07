using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.InputAudioBuffers
{
    /// <summary>
    /// Represents the input_audio_buffer.speech_started event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var inputAudioBufferSpeechStartedEvent = new InputAudioBufferSpeechStartedEvent
    /// {
    ///     EventId = "event_1516",
    ///     AudioStartMs = 1000,
    ///     ItemId = "msg_003"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioBufferSpeechStartedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioBufferSpeechStartedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "input_audio_buffer.speech_started"
        /// </summary>
        public override string Type { get; set; } = "input_audio_buffer.speech_started";

        /// <summary>
        /// Gets or sets the milliseconds since the session started when speech was detected.
        /// Example: 1000
        /// </summary>
        [JsonProperty("audio_start_ms")]
        public int AudioStartMs { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user message item that will be created when speech stops.
        /// Example: "msg_003"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}