using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.SpeechService.Domain.SsmlFileReading.Models;

namespace Mmu.SpeechService.Domain.SsmlFileReading.Services
{
    public interface ISsmlFileReader
    {
        Task<IReadOnlyCollection<SsmlFile>> ReadInDirectoryAsync(string directoryName);

        Task<SsmlFile> ReadFileAsync(string fileName);
    }
}