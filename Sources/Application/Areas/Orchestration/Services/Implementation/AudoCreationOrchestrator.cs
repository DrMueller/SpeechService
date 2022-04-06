using System.IO;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.BlobUpload.Services;
using Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Services;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Services;

namespace Mmu.FrenchLearningSystem.Areas.Orchestration.Services.Implementation
{
    public class AudoCreationOrchestrator : IAudoCreationOrchestrator
    {
        private readonly IBlobFileUploader _blobFileUploader;
        private readonly ISsmlFileReader _ssmlFileReader;
        private readonly IAudioWavFactory _audioWavFactory;

        public AudoCreationOrchestrator(
            IAudioWavFactory audioWavFactory,
            IBlobFileUploader blobFileUploader,
            ISsmlFileReader ssmlFileReader)
        {
            _audioWavFactory = audioWavFactory;
            _blobFileUploader = blobFileUploader;
            _ssmlFileReader = ssmlFileReader;
        }

        public async Task CreateAsync()
        {
            var otherFiles = await _ssmlFileReader.ReadOtherFilesAsync();
            foreach(var of in otherFiles)
            {
                var wavResult = await _audioWavFactory.CreateAsync(of);
                File.Delete(wavResult.FilePath);
            }

            var translationSsmlFile = await _ssmlFileReader.ReadTranslationFileAsync();
            var transWavResult = await _audioWavFactory.CreateAsync(translationSsmlFile);
            await _blobFileUploader.UploadAsync(transWavResult.FilePath);
            File.Delete(transWavResult.FilePath);
        }
    }
}