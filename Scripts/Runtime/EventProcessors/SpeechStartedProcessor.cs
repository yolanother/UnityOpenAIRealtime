using OpenAIRealtime.Data.ServerEvents.InputAudioBuffers;
using OpenAIRealtime.EventProcessors;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ThirdParty.OpenAI.Realtime.EventProcessors
{
    /// <summary>
    /// Processes the speech started event and triggers the corresponding Unity event.
    /// </summary>
    public class SpeechStartedProcessor : BaseEventProcessorMonoBehaviour<InputAudioBufferSpeechStartedEvent>
    {
        /// <summary>
        /// Event triggered when speech starts.
        /// </summary>
        [Header("Speech Events")]
        [Tooltip("Event triggered when speech starts.")]
        [SerializeField] private UnityEvent onSpeechStarted = new UnityEvent();

        /// <summary>
        /// Gets the Unity event that is triggered when speech starts.
        /// </summary>
        public UnityEvent OnSpeechStarted => onSpeechStarted;

        /// <summary>
        /// Processes the speech started event and invokes the onSpeechStarted event.
        /// </summary>
        /// <param name="data">The speech started event data.</param>
        protected override void OnEventProcessed(InputAudioBufferSpeechStartedEvent data)
        {
            onSpeechStarted?.Invoke();
        }
    }
}