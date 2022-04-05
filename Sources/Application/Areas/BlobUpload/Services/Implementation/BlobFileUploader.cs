using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Mmu.FrenchLearningSystem.Infrastructure.Settings.Services;

namespace Mmu.FrenchLearningSystem.Areas.BlobUpload.Services.Implementation
{
    public class BlobFileUploader : IBlobFileUploader
    {
        private readonly IAppSettingsProvider _appSettingProvider;

        public BlobFileUploader(IAppSettingsProvider appSettingProvider)
        {
            _appSettingProvider = appSettingProvider;
        }

        public async Task UploadAsync(string filePath)
        {
            var blobClient = new BlobClient(
                _appSettingProvider.Settings.BlobConnectionString,
                "frenchlearning",
                "LearnFrench.wav");

            await blobClient.UploadAsync(filePath, true);
        }
    }
}