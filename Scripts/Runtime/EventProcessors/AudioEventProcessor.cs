using System.Collections.Generic;
using OpenAIRealtime.Audio;
using OpenAIRealtime.Data.ServerEvents.Responses.Audio;
using UnityEngine;

namespace OpenAIRealtime.EventProcessors
{
    /// <summary>
    /// Processes audio events and plays received audio deltas through Unity's AudioSource.
    /// Uses a ring buffer to manage the data and a coroutine to stream it smoothly.
    /// </summary>
    [RequireComponent(typeof(AudioStreamingBuffer))]
    public class AudioEventProcessor : MultiEventProcessorMonoBehaviour
    {
        private AudioStreamingBuffer audioStreamingBuffer;

        /// <summary>
        /// Initializes the AudioSource and sets up the AudioClip buffer.
        /// </summary>
        void Start()
        {
            audioStreamingBuffer = GetComponent<AudioStreamingBuffer>();
        }

        /// <summary>
        /// Registers event processors for handling audio delta and done events.
        /// </summary>
        /// <param name="multiEventProcessor">The event processor used to register event handlers.</param>
        protected override void OnRegisterEventProcessors(MultiEventProcessor multiEventProcessor)
        {
            // Register processor for audio delta events (streamed audio chunks)
            multiEventProcessor.Add((ResponseAudioDeltaEvent ev) =>
            {
                byte[] audioData = System.Convert.FromBase64String(ev.Delta);
                audioStreamingBuffer.AddPCM16Audio(audioData);
            });

            // Register processor for audio done events (end of stream or audio complete)
            multiEventProcessor.Add((ResponseAudioDoneEvent ev) =>
            {
            });
        }
    }
}
