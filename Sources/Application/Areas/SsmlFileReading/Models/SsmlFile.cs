namespace Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Models
{
    public class SsmlFile
    {
        public SsmlFile(
            string fileName,
            string xmlContent)
        {
            FileName = fileName;
            XmlContent = xmlContent;
        }

        public string XmlContent { get; }
        public string FileName { get; }
    }
}