using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Mmu.SpeechService.CrossCutting.Settings.Services;
using Mmu.SpeechService.Domain.WavCreation.Models;

namespace Mmu.SpeechService.Infrastructure.WavFileSaving.Services.Servants.Implementation
{
    public class BlobFileUploader : IBlobFileUploader
    {
        private readonly IAppSettingsProvider _appSettingProvider;

        public BlobFileUploader(IAppSettingsProvider appSettingProvider)
        {
            _appSettingProvider = appSettingProvider;
        }

        public async Task UploadAsync(WavFile wavFile)
        {
            var blobClient = new BlobClient(
                _appSettingProvider.Settings.BlobConnectionString,
                "frenchlearning",
                "LearnFrench.wav");

            await blobClient.UploadAsync(new BinaryData(wavFile.AudioData), true);
        }
    }
}