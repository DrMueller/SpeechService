using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Models;
using Mmu.FrenchLearningSystem.Infrastructure.Paths.Services;

namespace Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Services.Implementation
{
    public class SsmlFileReader : ISsmlFileReader
    {
        private readonly IPathService _pathService;

        public SsmlFileReader(IPathService pathService)
        {
            _pathService = pathService;
        }

        public async Task<IReadOnlyCollection<SsmlFile>> ReadOtherFilesAsync()
        {
            var otherTranslationFilesPath = Path.Combine(_pathService.GetSsmlFilePath(), "OtherTranslations");

            var files = Directory.GetFiles(otherTranslationFilesPath);

            var result = new List<SsmlFile>();

            foreach (var file in files)
            {
                var xmlContent = await File.ReadAllTextAsync(file);
                result.Add(new SsmlFile(Path.GetFileName(file), xmlContent));
            }

            return result;
        }

        public async Task<SsmlFile> ReadTranslationFileAsync()
        {
            var fullPath = Path.Combine(_pathService.GetSsmlFilePath(), "TranslationTexts.xml");
            var xmlContent = await File.ReadAllTextAsync(fullPath);

            return new SsmlFile(Path.GetFileName(fullPath), xmlContent);
        }
    }
}