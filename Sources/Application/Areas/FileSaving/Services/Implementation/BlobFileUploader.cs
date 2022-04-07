using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Models;
using Mmu.FrenchLearningSystem.Infrastructure.Settings.Services;

namespace Mmu.FrenchLearningSystem.Areas.FileSaving.Services.Implementation
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