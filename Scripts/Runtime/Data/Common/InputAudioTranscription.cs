using Newtonsoft.Json;
using System;

namespace OpenAIRealtime.Data.ServerEvents
{
    /// <summary>
    /// Represents the input audio transcription configuration.
    /// 
    /// Usage example:
    /// var inputAudioTranscription = new InputAudioTranscription
    /// {
    ///     Enabled = true,
    ///     Model = "whisper-1"
    /// };
    /// 
    /// // To serialize the object to JSON:
    /// string json = JsonConvert.SerializeObject(inputAudioTranscription, Formatting.Indented);
    /// </summary>
    [Serializable]
    public class InputAudioTranscription
    {
        /// <summary>
        /// Gets or sets whether audio transcription is enabled.
        /// Example: true
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the model used for audio transcription.
        /// Example: "whisper-1"
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; } = "whisper-1";
    }
}