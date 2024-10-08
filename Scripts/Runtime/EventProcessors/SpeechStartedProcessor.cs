using OpenAIRealtime.Data.ServerEvents.InputAudioBuffers;
using OpenAIRealtime.EventProcessors;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ThirdParty.OpenAI.Realtime.EventProcessors
{
    public class SpeechStartedProcessor : BaseEventProcessorMonoBehaviour<InputAudioBufferSpeechStartedEvent>
    {
        [SerializeField] private UnityEvent onSpeechStarted = new UnityEvent();
        
        protected override void OnEventProcessed(InputAudioBufferSpeechStartedEvent data)
        {
            onSpeechStarted?.Invoke();
        }
    }
}