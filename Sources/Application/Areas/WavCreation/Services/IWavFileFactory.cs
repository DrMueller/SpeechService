using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Models;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Models;

namespace Mmu.FrenchLearningSystem.Areas.WavCreation.Services
{
    public interface IWavFileFactory
    {
        Task<WavFile> CreateAsync(SsmlFile ssmlFile);
    }
}