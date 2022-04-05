using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Models;
using Mmu.FrenchLearningSystem.Infrastructure.Settings.Services;

namespace Mmu.FrenchLearningSystem.Areas.WavCreation.Services.Implementation
{
    public class TranslationWavFactory : ITranslationWavFactory
    {
        private readonly IAppSettingsProvider _appSettingsProvider;

        public TranslationWavFactory(IAppSettingsProvider appSettingsProvider)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        public async Task<WavCreationResult> CreateAsync()
        {
            var speechConfig = CreateSpeechConfig();
            using var speechSynthesizer = new SpeechSynthesizer(speechConfig);

            var ssmlXml = await ReadSsmlXmlAsync();
            var speechSynthResult = await speechSynthesizer.SpeakSsmlAsync(ssmlXml);

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

        private static async Task<string> ReadSsmlXmlAsync()
        {
            var uri = new UriBuilder(typeof(TranslationWavFactory).Assembly.Location);
            var path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);
            var fullPath = Path.Combine(path!, "Infrastructure", "Assets", "Texts.xml");
            var xmlContent = await File.ReadAllTextAsync(fullPath);

            return xmlContent;
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