using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Mmu.FrenchLearningSystem.CrossCutting.Settings.Services;
using Mmu.FrenchLearningSystem.Domain.SsmlFileReading.Models;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Models;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Services;

namespace Mmu.FrenchLearningSystem.Infrastructure.WavCreation.Services.Implementation
{
    public class WavFileFactory : IWavFileFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public WavFileFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<WavFile> CreateAsync(SsmlFile ssmlFile)
        {
            var speechConfig = CreateSpeechConfig();
            using var speechSynthesizer = new SpeechSynthesizer(speechConfig);

            var speechSynthResult = await speechSynthesizer.SpeakSsmlAsync(ssmlFile.XmlContent);

            if (speechSynthResult.Reason == ResultReason.SynthesizingAudioCompleted)
            {
                return new WavFile(
                    ssmlFile.FileName,
                    speechSynthResult.AudioData);
            }

            Debugger.Break();

            throw new Exception("Could not create translation.");
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