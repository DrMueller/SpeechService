using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Models;

namespace Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Services
{
    public interface ISsmlFileReader
    {
        Task<IReadOnlyCollection<SsmlFile>> ReadOtherFilesAsync();

        Task<SsmlFile> ReadTranslationFileAsync();
    }
}