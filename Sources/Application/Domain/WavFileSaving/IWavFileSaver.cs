using System.Threading.Tasks;
using Mmu.SpeechService.Domain.WavCreation.Models;

namespace Mmu.SpeechService.Domain.WavFileSaving
{
    public interface IWavFileSaver
    {
        Task SaveLocalAsync(WavFile wavFile);

        Task SaveToBlobAsync(WavFile wavFile);
    }
}
