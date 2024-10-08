using System;
using DoubTech.ThirdParty.OpenAI.Realtime.EventProcessors;
using Oculus.Voice.Dictation;
using OpenAIRealtime;
using OpenAIRealtime.Data.ServerEvents.Responses.Audio;
using OpenAIRealtime.EventProcessors;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ThirdParty.OpenAI.Realtime.Utilities
{
    public class LatencyTracker : BaseEventProcessorMonoBehaviour<ResponseAudioDeltaEvent>
    {
        [SerializeField] private OpenAIRealtimeStreamer streamer;
        [SerializeField] private AppDictationExperience appDictationExperience;

        [SerializeField] private UnityEvent<float> onPerceivedLatency = new UnityEvent<float>();
        [SerializeField] private UnityEvent<string> onPerceivedLatencyString = new UnityEvent<string>();
        
        private SpeechStartedProcessor _speechStartedProcessor;
        private SpeechStoppedProcessor _speechStoppedProcessor;
        private float _lastPartialTime;

        private void OnEnable()
        {
            _speechStartedProcessor = streamer.GetComponentInChildren<SpeechStartedProcessor>();
            _speechStoppedProcessor = streamer.GetComponentInChildren<SpeechStoppedProcessor>();
            
            _speechStartedProcessor.OnSpeechStarted.AddListener(OnSpeechStarted);
            _speechStoppedProcessor.OnSpeechStopped.AddListener(OnSpeechStopped);
            appDictationExperience.TranscriptionEvents.OnPartialTranscription.AddListener(OnPartialTranscription);
        }

        private void OnDisable()
        {
            _speechStartedProcessor.OnSpeechStarted.RemoveListener(OnSpeechStarted);
            _speechStoppedProcessor.OnSpeechStopped.RemoveListener(OnSpeechStopped);
            appDictationExperience.TranscriptionEvents.OnPartialTranscription.RemoveListener(OnPartialTranscription);
        }

        private void OnSpeechStarted()
        {
            appDictationExperience.Activate();
        }

        private void OnSpeechStopped()
        {
            appDictationExperience.Deactivate();
        }

        private void OnPartialTranscription(string arg0)
        {
            _lastPartialTime = Time.time;
        }

        protected override void OnEventProcessed(ResponseAudioDeltaEvent data)
        {
            if(_lastPartialTime > 0)
            {
                var latency = Time.time - _lastPartialTime;
                onPerceivedLatency?.Invoke(latency);
                onPerceivedLatencyString?.Invoke(latency.ToString("F3") + "s");
                _lastPartialTime = -1;
            }
        }
    }
}