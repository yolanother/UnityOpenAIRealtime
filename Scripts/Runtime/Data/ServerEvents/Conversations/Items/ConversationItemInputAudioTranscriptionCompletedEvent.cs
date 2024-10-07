using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.input_audio_transcription.completed event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var transcriptionCompletedEvent = new ConversationItemInputAudioTranscriptionCompletedEvent
    /// {
    ///     EventId = "event_2122",
    ///     ItemId = "msg_003",
    ///     ContentIndex = 0,
    ///     Transcript = "Hello, how are you?"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(transcriptionCompletedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemInputAudioTranscriptionCompletedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "conversation.item.input_audio_transcription.completed"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.input_audio_transcription.completed";

        /// <summary>
        /// Gets or sets the ID of the user message item.
        /// Example: "msg_003"
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// Gets or sets the index of the content part containing the audio.
        /// Example: 0
        /// </summary>
        [JsonProperty("content_index")]
        public int ContentIndex { get; set; }

        /// <summary>
        /// Gets or sets the transcribed text.
        /// Example: "Hello, how are you?"
        /// </summary>
        [JsonProperty("transcript")]
        public string Transcript { get; set; }
    }
}