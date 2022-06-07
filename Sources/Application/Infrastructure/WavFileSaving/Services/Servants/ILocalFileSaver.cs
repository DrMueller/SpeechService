using System.Threading.Tasks;
using Mmu.SpeechService.Domain.WavCreation.Models;

namespace Mmu.SpeechService.Infrastructure.WavFileSaving.Services.Servants
{
    public interface ILocalFileSaver
    {
        Task SaveLocalAsync(WavFile wavFile);
    }
}