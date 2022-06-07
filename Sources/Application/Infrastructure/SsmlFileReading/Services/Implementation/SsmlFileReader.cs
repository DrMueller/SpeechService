using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Mmu.SpeechService.CrossCutting.Paths.Services;
using Mmu.SpeechService.Domain.SsmlFileReading.Models;
using Mmu.SpeechService.Domain.SsmlFileReading.Services;

namespace Mmu.SpeechService.Infrastructure.SsmlFileReading.Services.Implementation
{
    public class SsmlFileReader : ISsmlFileReader
    {
        private readonly IAssemblyPathService _pathService;

        public SsmlFileReader(IAssemblyPathService pathService)
        {
            _pathService = pathService;
        }

        public async Task<SsmlFile> ReadFileAsync(string fileName)
        {
            var fullFileName = Path.Combine(GetAssetsPath(), fileName);

            var xmlContent = await File.ReadAllTextAsync(fullFileName);

            return new SsmlFile(Path.GetFileName(fileName), xmlContent);
        }

        public async Task<IReadOnlyCollection<SsmlFile>> ReadInDirectoryAsync(string directoryName)
        {
            var fullPath = Path.Combine(GetAssetsPath(), directoryName);

            var files = Directory.GetFiles(fullPath);

            var result = new List<SsmlFile>();

            foreach (var file in files)
            {
                var xmlContent = await File.ReadAllTextAsync(file);
                result.Add(new SsmlFile(Path.GetFileName(file), xmlContent));
            }

            return result;
        }

        private string GetAssetsPath()
        {
            return Path.Combine(_pathService.GetAssemblyPath(), "CrossCutting", "Assets");
        }
    }
}