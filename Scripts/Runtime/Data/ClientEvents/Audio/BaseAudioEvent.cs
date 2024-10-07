using System;
using Newtonsoft.Json;

namespace OpenAIRealtime.Data.ClientEvents.Audio
{
    /// <summary>
    /// Base class for events that include audio data.
    /// </summary>
    [Serializable]
    public abstract class BaseAudioEvent : BaseEvent
    {
        /// <summary>
        /// Gets or sets the base64-encoded audio data.
        /// This represents the PCM16 format audio in base64 encoding.
        /// </summary>
        [JsonProperty("audio")]
        public string Audio { get; set; }

        /// <summary>
        /// Sets the audio property from a float[] input captured by Unity's microphone.
        /// The float[] is converted to PCM16 and then encoded to base64.
        /// </summary>
        /// <param name="audioData">The float[] audio data captured by Unity's microphone.</param>
        public void SetAudioFromFloatArray(float[] audioData)
        {
            // Convert the float[] to PCM16
            byte[] pcm16Data = ConvertFloatArrayToPCM16(audioData);

            // Convert the PCM16 data to base64
            Audio = Convert.ToBase64String(pcm16Data);
        }
        
        /// <summary>
        /// Static factory method to create an InputAudioBufferAppendEvent instance
        /// from a float[] array captured by Unity's microphone.
        /// </summary>
        /// <param name="audioData">The float[] audio data captured by Unity's microphone.</param>
        /// <returns>An instance of InputAudioBufferAppendEvent with the audio set.</returns>
        public static T Create<T>(float[] audioData) where T: BaseAudioEvent, new()
        {
            var eventInstance = new T();
            eventInstance.SetAudioFromFloatArray(audioData);
            return eventInstance;
        }

        /// <summary>
        /// Converts a float[] array of audio data (ranging from -1.0f to 1.0f) to PCM16 format.
        /// </summary>
        /// <param name="audioData">The float[] audio data to be converted.</param>
        /// <returns>Byte array containing the PCM16 encoded audio.</returns>
        public static byte[] ConvertFloatArrayToPCM16(float[] audioData)
        {
            byte[] pcm16Data = new byte[audioData.Length * 2]; // PCM16 is 2 bytes per sample

            for (int i = 0; i < audioData.Length; i++)
            {
                // Clamp the float value between -1.0f and 1.0f
                float clamped = Math.Max(-1.0f, Math.Min(1.0f, audioData[i]));

                // Convert the float to PCM16 (signed 16-bit integer)
                short pcmValue = (short)(clamped * short.MaxValue);

                // Store the PCM16 value as two bytes (little endian)
                pcm16Data[i * 2] = (byte)(pcmValue & 0xff);        // Lower byte
                pcm16Data[i * 2 + 1] = (byte)((pcmValue >> 8) & 0xff); // Higher byte
            }

            return pcm16Data;
        }
    }
}