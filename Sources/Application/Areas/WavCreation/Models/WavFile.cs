using System.IO;

namespace Mmu.FrenchLearningSystem.Areas.WavCreation.Models
{
    public class WavFile
    {
        public WavFile(
            string originalFileName,
            byte[] audioData)
        {
            FileName = Path.ChangeExtension(originalFileName, ".wav");
            AudioData = audioData;
        }

#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] AudioData { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        public string FileName { get; }
    }
}