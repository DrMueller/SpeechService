using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.FileSaving.Services;
using Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Services;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Services;

namespace Mmu.FrenchLearningSystem.Areas.Orchestration.Services.Implementation
{
    public class AudoCreationOrchestrator : IAudoCreationOrchestrator
    {
        private readonly IWavFileFactory _audioWavFactory;
        private readonly IBlobFileUploader _blobFileUploader;
        private readonly IFileSaver _fileSaver;
        private readonly ISsmlFileReader _ssmlFileReader;

        public AudoCreationOrchestrator(
            IWavFileFactory audioWavFactory,
            IBlobFileUploader blobFileUploader,
            ISsmlFileReader ssmlFileReader,
            IFileSaver fileSaver)
        {
            _audioWavFactory = audioWavFactory;
            _blobFileUploader = blobFileUploader;
            _ssmlFileReader = ssmlFileReader;
            _fileSaver = fileSaver;
        }

        public async Task CreateAsync()
        {
            var otherFiles = await _ssmlFileReader.ReadOtherFilesAsync();

            foreach (var of in otherFiles)
            {
                var wavResult = await _audioWavFactory.CreateAsync(of);
                await _fileSaver.SaveAsync(wavResult);
            }

            var translationSsmlFile = await _ssmlFileReader.ReadTranslationFileAsync();
            var wavFile = await _audioWavFactory.CreateAsync(translationSsmlFile);
            await _blobFileUploader.UploadAsync(wavFile);
        }
    }
}