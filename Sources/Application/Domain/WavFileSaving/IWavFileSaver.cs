using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Models;

namespace Mmu.FrenchLearningSystem.Domain.WavFileSaving
{
    public interface IWavFileSaver
    {
        Task SaveLocalAsync(WavFile wavFile);

        Task SaveToBlobAsync(WavFile wavFile);
    }
}
