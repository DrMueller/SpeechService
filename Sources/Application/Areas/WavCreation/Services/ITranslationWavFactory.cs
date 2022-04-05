using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Models;

namespace Mmu.FrenchLearningSystem.Areas.WavCreation.Services
{
    public interface ITranslationWavFactory
    {
        Task<WavCreationResult> CreateAsync();
    }
}