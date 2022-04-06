using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Models;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Models;
using Mmu.FrenchLearningSystem.Infrastructure.Settings.Services;

namespace Mmu.FrenchLearningSystem.Areas.WavCreation.Services.Implementation
{
    public class AudioWavFactory : IAudioWavFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public AudioWavFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<WavCreationResult> CreateAsync(SsmlFile ssmlFile)
        {
            var speechConfig = CreateSpeechConfig();
            using var speechSynthesizer = new SpeechSynthesizer(speechConfig);

            var speechSynthResult = await speechSynthesizer.SpeakSsmlAsync(ssmlFile.XmlContent);

            if (speechSynthResult.Reason != ResultReason.SynthesizingAudioCompleted)
            {
                Debugger.Break();

                throw new Exception("Could not create translation.");
            }

            var tempPath = Path.GetTempFileName();
            File.Delete(tempPath);
            tempPath = Path.ChangeExtension(tempPath, "wav");
            await File.WriteAllBytesAsync(tempPath, speechSynthResult.AudioData);

            return new WavCreationResult(tempPath);
        }

        private SpeechConfig CreateSpeechConfig()
        {
            var speechConfig = SpeechConfig.FromSubscription(
                _appSettingsProvider.Settings.SpeechServiceApiKey,
                _appSettingsProvider.Settings.SpeechServiceRegion);

            return speechConfig;
        }
    }
}