using System;

namespace OpenAIRealtime.Data.ClientEvents.Audio
{
    /// <summary>
    /// Represents the input_audio_buffer.commit event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var inputAudioBufferCommit = new InputAudioBufferCommitEvent
    /// {
    ///     EventId = "event_789"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioBufferCommit, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioBufferCommitEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "input_audio_buffer.commit"
        /// </summary>
        public override string Type { get; set; } = "input_audio_buffer.commit";
    }
}