# Unity OpenAI Realtime API Library

Welcome to the **Unity OpenAI Realtime API** package! This library integrates OpenAI's Realtime API into Unity, allowing developers to interact with OpenAI models in real-time within Unity projects. With this package, you can build interactive applications such as in-game assistants, speech-to-text systems, dynamic content generation, and more, all using OpenAI's cutting-edge models.

* NOTE: This readme was quickly written by ChatGPT, this readme is mostly accurate, but needs some editing.

## Features

- **Real-time AI interaction**: Leverage OpenAI’s Realtime API for generating responses, handling speech recognition, and more in real time.
- **Support for multiple AI events**: Manage conversation responses, audio buffers, and more.
- **Processor-based architecture**: Handle incoming events using custom processors, such as audio playback and caption display.
- **Seamless Unity Integration**: Designed to work smoothly within Unity, making it easy to integrate AI-based features in your game or application.
- **Easy-to-use microphone and text input handling**: Capture audio or send text messages via simple components like `StreamingMicInput` and `TextInput`.
- **XR SDK Voice Integration**: Includes `com.meta.xr.sdk.voice` dependency to handle voice input in XR environments.

## Installation

### Method 1: Install via Unity Package Manager (Git URL)

1. Open Unity and navigate to `Window -> Package Manager`.
2. Click the "+" icon in the top left of the window and select "Add package from git URL...".
3. Paste the following URL and click "Add":
   ```
   https://github.com/yolanother/UnityOpenAIRealtime.git
   ```
4. Unity will automatically download and import the package into your project.

### Method 2: Download and Import the Unity Package

1. **Download the Unity Package:**
   - Clone this repository or download the latest release from the [releases section](#).

2. **Import the Package:**
   - In Unity, go to `Assets -> Import Package -> Custom Package...`.
   - Select the downloaded package and import all files.

### Set Up OpenAI API Credentials

1. In Unity, navigate to the Project tab, right-click on the directory where you'd like to create the configuration, and select `Create -> AI -> Open AI Config`.
2. Set the API key in the newly created `OpenAIConfig` asset.
3. Assign this asset in the `OpenAIManager` component of your scene.

   The configuration file can be found here: [OpenAIConfig.cs](https://github.com/yolanother/UnityOpenAIRealtime/blob/main/Scripts/Runtime/Data/OpenAIConfig.cs).

4. **Ensure Dependencies**:
   - This package depends on the **com.meta.xr.sdk.voice** package for voice handling. Ensure that this dependency is added to your Unity project.

## Quick Start

### 1. Add the Components

To use the OpenAI Realtime API, simply add the `OpenAIRealtimeStreamer` component to a game object in your scene. The necessary processors, microphone input, and text input components can be added directly through Unity's inspector.

```csharp
// No custom code required for initialization. Just add the components in the Unity Editor.
```

### 2. Capture Audio Input via `StreamingMicInput`

You can capture and send audio input to OpenAI using the `StreamingMicInput` component, which handles microphone input. Simply attach it to the same game object as the `OpenAIRealtimeStreamer` and call the `StartListening()` and `StopListening()` methods to control the mic.

```csharp
// Example of setting up microphone input
public class MicInputController : MonoBehaviour
{
    [SerializeField] private StreamingMicInput micInput;

    void Start()
    {
        micInput.StartListening();
    }

    void StopListening()
    {
        micInput.StopListening();
    }
}
```

### 3. Send Text Input via `TextInput`

For sending text input to OpenAI, add the `TextInput` component to the game object containing the `OpenAIRealtimeStreamer`. Use the `Send(string message)` method to send text input to the API.

```csharp
// Example of sending text input
public class TextInputController : MonoBehaviour
{
    [SerializeField] private TextInput textInput;

    public void SendText(string message)
    {
        textInput.Send(message);
    }
}
```

### 4. Handle Events via Processors

Incoming events are handled through processors, which allow you to process specific types of responses like audio playback or displaying captions.

#### Supported Processors

- **[AudioEventProcessor](https://github.com/yolanother/UnityOpenAIRealtime/blob/main/Scripts/Runtime/EventProcessors/AudioEventProcessor.cs)**: Handles the playback of audio responses.
- **[CaptionProcessor](https://github.com/yolanother/UnityOpenAIRealtime/blob/main/Scripts/Runtime/EventProcessors/CaptionProcessor.cs)**: Displays text captions from the AI responses.

#### General Setup

1. Add an `OpenAIRealtimeStreamer` component to a game object in your scene.
2. Create child game objects under the streamer object and attach the event processors (e.g., `AudioEventProcessor`, `CaptionProcessor`) to these child objects.

```csharp
// Example of setting up an OpenAIRealtimeStreamer with processors

// Attach the OpenAIRealtimeStreamer to a GameObject in your scene
OpenAIRealtimeStreamer streamer = gameObject.AddComponent<OpenAIRealtimeStreamer>();

// Add an AudioEventProcessor to handle audio responses
GameObject audioProcessorObject = new GameObject("AudioProcessor");
audioProcessorObject.transform.SetParent(gameObject.transform);
AudioEventProcessor audioProcessor = audioProcessorObject.AddComponent<AudioEventProcessor>();

// Add a CaptionProcessor to handle text responses
GameObject captionProcessorObject = new GameObject("CaptionProcessor");
captionProcessorObject.transform.SetParent(gameObject.transform);
CaptionProcessor captionProcessor = captionProcessorObject.AddComponent<CaptionProcessor>();
```

## API Documentation

The API includes the following key components:

- **OpenAIRealtimeClient**: Core class for interacting with the Realtime API. Handles initialization, event subscription, and sending data.
- **AudioBuffer**: Provides utilities for handling audio input and buffer commits.
- **TextInput**: Allows sending text input directly to OpenAI's models.

Detailed documentation for each component and example usage can be found in the `Docs/` folder.

## Examples

You can find example scenes under the `Examples/` directory that showcase how to use the package for common tasks like setting up conversations, capturing audio, and handling AI-generated responses.

## Requirements

- **Unity Version**: 2021.3 or higher
- **OpenAI API Key**: Sign up for access to the OpenAI Realtime API [here](https://openai.com/index/introducing-the-realtime-api/).
- **Meta XR SDK Voice**: Ensure you have the `com.meta.xr.sdk.voice` dependency installed.

## Contribution

We welcome contributions to improve the package. If you find a bug or have a feature request, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.md) file for details.

## Contact

For support, feel free to reach out to the maintainers via the [Issues](#) section.

---

Thank you for using **Unity OpenAI Realtime API Library**! We hope it enhances your Unity projects with cutting-edge AI capabilities.