using OpenAIRealtime.Data.ServerEvents.InputAudioBuffers;
using OpenAIRealtime.EventProcessors;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ThirdParty.OpenAI.Realtime.EventProcessors
{
    public class SpeechStoppedProcessor : BaseEventProcessorMonoBehaviour<InputAudioBufferSpeechStoppedEvent>
    {
        [SerializeField] private UnityEvent onSpeechStopped = new UnityEvent();
        protected override void OnEventProcessed(InputAudioBufferSpeechStoppedEvent data)
        {
            onSpeechStopped?.Invoke();
        }
    }
}