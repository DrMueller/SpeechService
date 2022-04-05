using System.IO;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.BlobUpload.Services;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Services;

namespace Mmu.FrenchLearningSystem.Areas.Orchestration.Services.Implementation
{
    public class CreateTranslationWavService : ICreateTranslationWavService
    {
        private readonly IBlobFileUploader _blobFileUploader;
        private readonly ITranslationWavFactory _translationWavFactory;

        public CreateTranslationWavService(
            ITranslationWavFactory translationWavFactory,
            IBlobFileUploader blobFileUploader)
        {
            _translationWavFactory = translationWavFactory;
            _blobFileUploader = blobFileUploader;
        }

        public async Task CreateAsync()
        {
            var wavResult = await _translationWavFactory.CreateAsync();
            await _blobFileUploader.UploadAsync(wavResult.FilePath);

            File.Delete(wavResult.FilePath);
        }
    }
}