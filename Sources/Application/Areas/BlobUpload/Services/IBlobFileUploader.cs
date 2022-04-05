using System.Threading.Tasks;

namespace Mmu.FrenchLearningSystem.Areas.BlobUpload.Services
{
    public interface IBlobFileUploader
    {
        Task UploadAsync(string filePath);
    }
}