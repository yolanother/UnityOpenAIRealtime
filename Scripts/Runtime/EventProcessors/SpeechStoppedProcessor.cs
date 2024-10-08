using OpenAIRealtime.Data.ServerEvents.InputAudioBuffers;
using OpenAIRealtime.EventProcessors;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ThirdParty.OpenAI.Realtime.EventProcessors
{
    /// <summary>
    /// Processes the speech stopped event and triggers the corresponding Unity event.
    /// </summary>
    public class SpeechStoppedProcessor : BaseEventProcessorMonoBehaviour<InputAudioBufferSpeechStoppedEvent>
    {
        /// <summary>
        /// Event triggered when speech stops.
        /// </summary>
        [Header("Speech Events")]
        [Tooltip("Event triggered when speech stops.")]
        [SerializeField] private UnityEvent onSpeechStopped = new UnityEvent();
        
        /// <summary>
        /// Gets the Unity event that is triggered when speech stops.
        /// </summary>
        public UnityEvent OnSpeechStopped => onSpeechStopped;

        /// <summary>
        /// Processes the speech stopped event and invokes the onSpeechStopped event.
        /// </summary>
        /// <param name="data">The speech stopped event data.</param>
        protected override void OnEventProcessed(InputAudioBufferSpeechStoppedEvent data)
        {
            onSpeechStopped?.Invoke();
        }
    }
}