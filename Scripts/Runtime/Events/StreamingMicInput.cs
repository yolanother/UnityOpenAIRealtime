using System;
using Meta.WitAi.Data;
using OpenAIRealtime.Data.ClientEvents.Audio;
using UnityEditor;
using UnityEngine;

namespace OpenAIRealtime.Events
{
    public class StreamingMicInput : MonoBehaviour
    {
        [SerializeField] private OpenAIRealtimeStreamer streamer;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            StopListening();
        }

        public void StartListening()
        {
            AudioBuffer.Instance.Events.OnSampleReady += OnSampleReady;
            AudioBuffer.Instance.StartRecording(this);

            var ev = new InputAudioBufferClearEvent();
            streamer.SendEvent(ev);
        }

        public void StopListening()
        {
            AudioBuffer.Instance.Events.OnSampleReady -= OnSampleReady;
            AudioBuffer.Instance.StopRecording(this);
            var ev = new InputAudioBufferCommitEvent();
            streamer.SendEvent(ev);
        }

        private void OnSampleReady(RingBuffer<byte>.Marker marker, float levelmax)
        {
            // Base64 encode the marker data into a buffer
            var buffer = new byte[marker.AvailableByteCount];
            marker.Read(buffer, 0, buffer.Length);
            var base64 = Convert.ToBase64String(buffer);

            var ev = new InputAudioBufferAppendEvent()
            {
                Audio = base64
            };
            streamer.SendEvent(ev);
        }
    }
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(StreamingMicInput))]
    public class StreamingMicInputEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var script = (StreamingMicInput) target;
            if (GUILayout.Button("Start Listening"))
            {
                script.StartListening();
            }

            if (GUILayout.Button("Stop Listening"))
            {
                script.StopListening();
            }
        }
    }
    #endif
}