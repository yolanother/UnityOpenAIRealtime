using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Conversations.Items
{
    /// <summary>
    /// Represents the conversation.item.input_audio_transcription.failed event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var transcriptionFailedEvent = new ConversationItemInputAudioTranscriptionFailedEvent
    /// {
    ///     EventId = "event_2324",
    ///     ItemId = "msg_003",
    ///     ContentIndex = 0,
    ///     Error = new TranscriptionError
    ///     {
    ///         Type = "transcription_error",
    ///         Code = "audio_unintelligible",
    ///         Message = "The audio could not be transcribed.",
    ///         Param = null
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(transcriptionFailedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class ConversationItemInputAudioTranscriptionFailedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "conversation.item.input_audio_transcription.failed"
        /// </summary>
        public override string Type { get; set; } = "conversation.item.input_audio_transcription.failed";

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
        /// Gets or sets the details of the transcription error.
        /// </summary>
        [JsonProperty("error")]
        public TranscriptionError Error { get; set; }
    }

    /// <summary>
    /// Represents the details of a transcription error.
    /// </summary>
    [Serializable]
    public class TranscriptionError
    {
        /// <summary>
        /// Gets or sets the type of error.
        /// Example: "transcription_error"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the error code, if any.
        /// Example: "audio_unintelligible"
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a human-readable error message.
        /// Example: "The audio could not be transcribed."
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the parameter related to the error, if any.
        /// Example: null
        /// </summary>
        [JsonProperty("param")]
        public string Param { get; set; }
    }
}
