using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Models;

namespace Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Services.Implementation
{
    public class SsmlFileReader : ISsmlFileReader
    {
        public async Task<IReadOnlyCollection<SsmlFile>> ReadOtherFilesAsync()
        {
            var otherTranslationFilesPath = Path.Combine(GetAssetsPath(), "OtherTranslations");

            var files = Directory.GetFiles(otherTranslationFilesPath);

            var result = new List<SsmlFile>();

            foreach (var file in files)
            {
                var xmlContent = await File.ReadAllTextAsync(file);
                result.Add(new SsmlFile(xmlContent));
            }

            return result;
        }

        public async Task<SsmlFile> ReadTranslationFileAsync()
        {
            var fullPath = Path.Combine(GetAssetsPath(), "TranslationTexts.xml");
            var xmlContent = await File.ReadAllTextAsync(fullPath);

            return new SsmlFile(xmlContent);
        }

        private static string GetAssetsPath()
        {
            var uri = new UriBuilder(typeof(SsmlFileReader).Assembly.Location);
            var path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);

            return Path.Combine(path!, "Infrastructure", "Assets");
        }
    }
}