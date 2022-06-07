using System.Threading.Tasks;
using Mmu.SpeechService.Domain.SsmlFileReading.Models;
using Mmu.SpeechService.Domain.WavCreation.Models;

namespace Mmu.SpeechService.Domain.WavCreation.Services
{
    public interface IWavFileFactory
    {
        Task<WavFile> CreateAsync(SsmlFile ssmlFile);
    }
}