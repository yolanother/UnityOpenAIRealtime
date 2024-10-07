using System.Threading;
using Meta.WitAi.Data;
using UnityEngine;

namespace OpenAIRealtime.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioStreamingBuffer : MonoBehaviour
    {
        [Header("Audio Configuration")]
        [Tooltip("Sample rate of the audio in Hz (e.g., 24000 for standard quality audio)")]
        public int sampleRate = 24000;

        [Header("Buffer Settings")]
        [Tooltip("Duration of the audio buffer in seconds")]
        public int bufferDuration = 30;

        [Header("Advanced Settings")]
        [Tooltip("Number of audio channels (1 for Mono, 2 for Stereo)")]
        [SerializeField]
        private int channels = 1; // Mono audio

        [Tooltip("Maximum number of samples in the audio clip")]
        [SerializeField]
        private int maxClipSamples; // Maximum number of samples in the clip

        [Tooltip("Current position to write to in the ring buffer")]
        [SerializeField]
        private int writePosition = 0; // Current write position in the buffer

        [Tooltip("Coroutine state for managing buffer fill state")]
        [SerializeField]
        private bool isFilling = false; // Coroutine state

        private int bufferSize;
        private AudioSource audioSource;
        private AudioClip audioClip;
        private bool isClipCreated = false;
        private int readPosition = 0;
        private float[] clipData;
        
        RingBuffer<float> ringBuffer;
        private RingBuffer<float>.Marker marker;
        private SynchronizationContext mainThreadContext;

        /// <summary>
        /// Initializes the audio streaming buffer, sets up the audio source, and starts playback.
        /// </summary>
        void Start()
        {
            mainThreadContext = SynchronizationContext.Current;
            bufferSize = bufferDuration * sampleRate;
            ringBuffer = new RingBuffer<float>(bufferSize);
            marker = ringBuffer.CreateMarker();
            maxClipSamples = bufferSize;
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.clip = audioClip;
            audioClip = AudioClip.Create("StreamingAudioClip", bufferSize, channels, sampleRate, true, OnAudioRead);
            audioSource.clip = audioClip;
            
            isClipCreated = true;
            
        }

        /// <summary>
        /// Adds new audio samples to the buffer to be streamed by the audio source.
        /// </summary>
        /// <param name="audio">Array of audio samples to add to the buffer.</param>
        /// <summary>
        /// Adds new audio samples to the buffer to be streamed by the audio source. Starts the audio source if not already playing.
        /// </summary>
        /// <param name="audio">Array of audio samples to add to the buffer.</param>
        /// <summary>
        /// Adds new audio samples to the buffer to be streamed by the audio source. Resets the state if the audio source is not playing, and always starts playing after adding audio.
        /// </summary>
        /// <param name="audio">Array of audio samples to add to the buffer.</param>
        public void AddAudio(float[] audio)
        {
            if (!isClipCreated) return;

            ringBuffer.Push(audio, 0, audio.Length);
            if(!audioSource.isPlaying) audioSource.Play();
        }
        
        /// <summary>
        /// Adds new PCM16 audio samples to the buffer by converting them to float samples.
        /// </summary>
        /// <param name="data">Array of PCM16 audio samples to add to the buffer.</param>
        public void AddPCM16Audio(byte[] data)
        {
            if (!isClipCreated) return;

            int sampleCount = data.Length / 2; // Each PCM16 sample is 2 bytes
            float[] audio = new float[sampleCount];

            for (int i = 0; i < sampleCount; i++)
            {
                short sample = (short)(data[i * 2] | (data[i * 2 + 1] << 8));
                audio[i] = sample / 32768.0f; // Convert PCM16 to float (-1.0 to 1.0)
            }

            AddAudio(audio);
        }

        /// <summary>
        /// Callback used to provide audio data to the audio source for playback.
        /// </summary>
        /// <param name="data">Array to be filled with audio data from the buffer.</param>
        /// <summary>
        /// Callback used to provide audio data to the audio source for playback. Stops the audio source if the end of the buffer is reached.
        /// </summary>
        /// <param name="data">Array to be filled with audio data from the buffer.</param>
        private void OnAudioRead(float[] data)
        {
            var read = marker.Read(data, 0, data.Length);
            /*if (read == 0 && null != mainThreadContext)
            {
                mainThreadContext.Post((object data) =>
                {
                    audioSource.Stop();
                    audioSource.time = 0;
                }, null);
            }*/
            // Fill remaining data with 0s
            for (int i = read; i < data.Length; i++)
            {
                data[i] = 0.0f;
            }
        }
    }
}