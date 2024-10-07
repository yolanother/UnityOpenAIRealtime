using System;

namespace OpenAIRealtime.Data.ClientEvents.Audio
{
    /// <summary>
    /// Represents the input_audio_buffer.clear event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var inputAudioBufferClear = new InputAudioBufferClearEvent
    /// {
    ///     EventId = "event_012"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioBufferClear, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioBufferClearEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "input_audio_buffer.clear"
        /// </summary>
        public override string Type { get; set; } = "input_audio_buffer.clear";
    }
}