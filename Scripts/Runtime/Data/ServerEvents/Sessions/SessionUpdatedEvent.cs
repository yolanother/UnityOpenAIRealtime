using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents.Sessions
{
    /// <summary>
    /// Represents the session.updated event structure.
    /// 
    /// Inherits from BaseEvent.
    /// 
    /// Usage example:
    /// var sessionUpdatedEvent = new SessionUpdatedEvent
    /// {
    ///     EventId = "event_5678",
    ///     Session = new Session
    ///     {
    ///         Id = "sess_001",
    ///         ObjectType = "realtime.session",
    ///         Model = "gpt-4o-realtime-preview-2024-10-01",
    ///         Modalities = new List<string> { "text" },
    ///         Instructions = "New instructions",
    ///         Voice = "alloy",
    ///         InputAudioFormat = "pcm16",
    ///         OutputAudioFormat = "pcm16",
    ///         InputAudioTranscription = new InputAudioTranscription
    ///         {
    ///             Enabled = true,
    ///             Model = "whisper-1"
    ///         },
    ///         TurnDetection = new TurnDetection
    ///         {
    ///             Type = "none"
    ///         },
    ///         Tools = new List<Tool>(),
    ///         ToolChoice = "none",
    ///         Temperature = 0.7f,
    ///         MaxOutputTokens = 200
    ///     }
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(sessionUpdatedEvent, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class SessionUpdatedEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// Overridden from BaseEvent to specify this event type.
        /// Example: "session.updated"
        /// </summary>
        public override string Type { get; set; } = "session.updated";

        /// <summary>
        /// Gets or sets the updated session object.
        /// </summary>
        [JsonProperty("session")]
        public Session Session { get; set; }
    }
}