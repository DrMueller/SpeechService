using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Models;

namespace Mmu.FrenchLearningSystem.Infrastructure.WavFileSaving.Services.Servants
{
    public interface IBlobFileUploader
    {
        Task UploadAsync(WavFile wavFile);
    }
}