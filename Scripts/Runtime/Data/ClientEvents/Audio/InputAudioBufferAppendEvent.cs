using System;

namespace OpenAIRealtime.Data.ClientEvents.Audio
{
    /// <summary>
    /// Represents the input_audio_buffer.append event structure.
    /// 
    /// Inherits from BaseAudioEvent and includes a static Create() method
    /// to convert and set audio from a float[] array.
    /// 
    /// Usage example:
    /// var inputAudioBufferAppend = InputAudioBufferAppendEvent.Create(audioData);
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioBufferAppend, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioBufferAppendEvent : BaseAudioEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "input_audio_buffer.append"
        /// </summary>
        public override string Type { get; set; } = "input_audio_buffer.append";
    }
}
