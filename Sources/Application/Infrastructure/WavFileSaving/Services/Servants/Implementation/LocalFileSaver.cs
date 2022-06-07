using System.IO;
using System.Threading.Tasks;
using Mmu.SpeechService.CrossCutting.Paths.Services;
using Mmu.SpeechService.Domain.WavCreation.Models;

namespace Mmu.SpeechService.Infrastructure.WavFileSaving.Services.Servants.Implementation
{
    public class LocalFileSaver : ILocalFileSaver
    {
        private readonly IAssemblyPathService _pathService;

        public LocalFileSaver(IAssemblyPathService pathService)
        {
            _pathService = pathService;
        }

        public async Task SaveLocalAsync(WavFile wavFile)
        {
            var fullPath = Path.Combine(GetWavDestinationPath(), wavFile.FileName);

            await File.WriteAllBytesAsync(fullPath, wavFile.AudioData);
        }

        private string GetWavDestinationPath()
        {
            var path = Path.Combine(_pathService.GetAssemblyPath(), "WavFiles");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}