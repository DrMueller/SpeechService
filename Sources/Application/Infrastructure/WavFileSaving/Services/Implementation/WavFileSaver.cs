using System;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Models;
using Mmu.FrenchLearningSystem.Domain.WavFileSaving;
using Mmu.FrenchLearningSystem.Infrastructure.WavFileSaving.Services.Servants;

namespace Mmu.FrenchLearningSystem.Infrastructure.WavFileSaving.Services.Implementation
{
    public class WavFileSaver : IWavFileSaver
    {
        private readonly IBlobFileUploader _uploader;
        private readonly ILocalFileSaver _localSaver;

        public WavFileSaver(
            IBlobFileUploader uploader,
            ILocalFileSaver localSaver
            )
        {
            _uploader = uploader;
            _localSaver = localSaver;
        }

        public async Task SaveLocalAsync(WavFile wavFile)
        {
            await _localSaver.SaveLocalAsync(wavFile);
        }

        public async Task SaveToBlobAsync(WavFile wavFile)
        {
            await _uploader.UploadAsync(wavFile);
        }
    }
}
