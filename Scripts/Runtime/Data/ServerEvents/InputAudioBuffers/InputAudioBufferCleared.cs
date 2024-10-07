using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.InputAudioBuffers
{
    /// <summary>
    /// Represents the input_audio_buffer.cleared event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var inputAudioBufferClearedEvent = new InputAudioBufferClearedEvent
    /// {
    ///     EventId = "event_1314"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioBufferClearedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioBufferClearedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "input_audio_buffer.cleared"
        /// </summary>
        public override string Type { get; set; } = "input_audio_buffer.cleared";
    }
}