using OpenAIRealtime.Data.ServerEvents.Conversations.Items;
using UnityEngine;
using UnityEngine.Events;

namespace OpenAIRealtime.EventProcessors
{
    public class TranscriptionProcessor : MultiEventProcessorMonoBehaviour
    {
        [SerializeField] private UnityEvent<string> onPartialTranscription = new UnityEvent<string>();
        [SerializeField] private UnityEvent<string> onFullTranscription = new UnityEvent<string>();
        
        protected override void OnRegisterEventProcessors(MultiEventProcessor multiEventProcessor)
        {
            multiEventProcessor.Add<ConversationItemInputAudioTranscriptionCompletedEvent>(e =>
            {
                onPartialTranscription?.Invoke(e.Transcript);
                onFullTranscription?.Invoke(e.Transcript);
            });
        }
    }
}