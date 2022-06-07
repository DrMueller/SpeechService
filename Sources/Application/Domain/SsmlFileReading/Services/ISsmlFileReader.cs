using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Domain.SsmlFileReading.Models;

namespace Mmu.FrenchLearningSystem.Domain.SsmlFileReading.Services
{
    public interface ISsmlFileReader
    {
        Task<IReadOnlyCollection<SsmlFile>> ReadInDirectoryAsync(string directoryName);

        Task<SsmlFile> ReadFileAsync(string fileName);
    }
}