using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02SasSExample
{
    class SpeechServiceTool
    {
        string apiKey= "ba478f693e654d43a4d95f6772a7a46a";
        public async Task<string> RecognizeAsync()
        {
            var conf = SpeechConfig.FromSubscription(apiKey, "eastus");
            return await RecognizeFromMic(conf);
        }

        //dotnet add package Microsoft.CognitiveServices.Speech
        private async Task<string> RecognizeFromMic(SpeechConfig speechConfig)
        {
            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, "pl-PL", audioConfig);

            var result = await recognizer.RecognizeOnceAsync();
            return result.Text;
        }
    }
}
