using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Domain.SsmlFileReading.Models;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Models;

namespace Mmu.FrenchLearningSystem.Domain.WavCreation.Services
{
    public interface IWavFileFactory
    {
        Task<WavFile> CreateAsync(SsmlFile ssmlFile);
    }
}