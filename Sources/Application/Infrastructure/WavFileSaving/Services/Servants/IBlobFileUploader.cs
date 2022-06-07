using System.Threading.Tasks;
using Mmu.SpeechService.Domain.WavCreation.Models;

namespace Mmu.SpeechService.Infrastructure.WavFileSaving.Services.Servants
{
    public interface IBlobFileUploader
    {
        Task UploadAsync(WavFile wavFile);
    }
}