using System;
using Meta.WitAi.Data;
using OpenAIRealtime.Data.ClientEvents.Audio;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace OpenAIRealtime.Events
{
    /// <summary>
    /// Handles streaming microphone input and sends audio data to the OpenAIRealtimeStreamer.
    /// </summary>
    public class StreamingMicInput : MonoBehaviour
    {
        /// <summary>
        /// Event triggered when the microphone starts listening.
        /// </summary>
        [Header("Microphone Events")]
        [Tooltip("Event triggered when the microphone starts listening.")]
        [SerializeField] private UnityEvent onStartedListening = new UnityEvent();

        /// <summary>
        /// Event triggered when the microphone stops listening.
        /// </summary>
        [Tooltip("Event triggered when the microphone stops listening.")]
        [SerializeField] private UnityEvent onStoppedListening = new UnityEvent();

        /// <summary>
        /// The streamer responsible for sending audio events.
        /// </summary>
        [Header("Streamer Settings")]
        [Tooltip("The streamer responsible for sending audio events.")]
        [SerializeField] private OpenAIRealtimeStreamer streamer;

        /// <summary>
        /// Called when the component is enabled.
        /// </summary>
        private void OnEnable()
        {
            
        }

        /// <summary>
        /// Called when the component is disabled.
        /// </summary>
        private void OnDisable()
        {
            StopListening();
        }

        /// <summary>
        /// Starts listening to the microphone input.
        /// </summary>
        public void StartListening()
        {
            AudioBuffer.Instance.Events.OnSampleReady += OnSampleReady;
            AudioBuffer.Instance.StartRecording(this);

            var ev = new InputAudioBufferClearEvent();
            streamer.SendEvent(ev);
            onStartedListening?.Invoke();
        }

        /// <summary>
        /// Stops listening to the microphone input.
        /// </summary>
        public void StopListening()
        {
            var ev = new InputAudioBufferCommitEvent();
            streamer.SendEvent(ev);
            AudioBuffer.Instance.Events.OnSampleReady -= OnSampleReady;
            AudioBuffer.Instance.StopRecording(this);
            onStoppedListening?.Invoke();
        }

        /// <summary>
        /// Handles the sample ready event from the audio buffer.
        /// </summary>
        /// <param name="marker">The marker containing the audio data.</param>
        /// <param name="levelmax">The maximum audio level.</param>
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
    /// <summary>
    /// Custom editor for the StreamingMicInput component.
    /// </summary>
    [CustomEditor(typeof(StreamingMicInput))]
    public class StreamingMicInputEditor : Editor
    {
        /// <summary>
        /// Draws the custom inspector GUI.
        /// </summary>
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