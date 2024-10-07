﻿using System.Text;
using OpenAIRealtime.Data.ServerEvents.Responses;
using OpenAIRealtime.Data.ServerEvents.Responses.AudioTranscripts;
using OpenAIRealtime.Data.ServerEvents.Responses.Text;
using UnityEngine;
using UnityEngine.Events;

namespace OpenAIRealtime.EventProcessors
{
    public class CaptionProcessor : MultiEventProcessorMonoBehaviour
    {
        [SerializeField] private UnityEvent<string> onPartialTextResponse = new UnityEvent<string>();
        [SerializeField] private UnityEvent<string> onFullTextResponse = new UnityEvent<string>();

        private StringBuilder _currentText = new StringBuilder();

        protected override void OnRegisterEventProcessors(MultiEventProcessor multiEventProcessor)
        {
            multiEventProcessor.Add<ResponseCreatedEvent>(e => _currentText.Clear());
            multiEventProcessor.Add<ResponseAudioTranscriptDeltaEvent>(e => ProcessPartial(e.Delta));
            multiEventProcessor.Add<ResponseTextDeltaEvent>(e => ProcessPartial(e.Delta));
            multiEventProcessor.Add<ResponseTextDoneEvent>(e => onFullTextResponse.Invoke(e.Text));
        }

        private void ProcessPartial(string delta)
        {
            _currentText.Append(delta);
            onPartialTextResponse.Invoke(_currentText.ToString());
        }
    }
}