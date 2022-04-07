using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Areas.WavCreation.Models;

namespace Mmu.FrenchLearningSystem.Areas.FileSaving.Services
{
    public interface IBlobFileUploader
    {
        Task UploadAsync(WavFile wavFile);
    }
}