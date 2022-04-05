namespace Mmu.FrenchLearningSystem.Areas.WavCreation.Models
{
    public class WavCreationResult
    {
        public WavCreationResult(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; }
    }
}