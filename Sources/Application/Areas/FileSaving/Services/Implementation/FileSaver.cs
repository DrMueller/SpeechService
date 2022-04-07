using System.IO;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Models;
using Mmu.FrenchLearningSystem.Infrastructure.Paths.Services;

namespace Mmu.FrenchLearningSystem.Areas.FileSaving.Services.Implementation
{
    public class FileSaver : IFileSaver
    {
        private readonly IPathService _pathService;

        public FileSaver(IPathService pathService)
        {
            _pathService = pathService;
        }

        public async Task SaveAsync(WavFile wavFile)
        {
            var fullPath = Path.Combine(_pathService.GetWavDestinationPath(), wavFile.FileName);

            await File.WriteAllBytesAsync(fullPath, wavFile.AudioData);
        }
    }
}