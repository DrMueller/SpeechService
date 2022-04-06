namespace Mmu.FrenchLearningSystem.Areas.SsmlFileReading.Models
{
    public class SsmlFile
    {
        public SsmlFile(string xmlContent)
        {
            XmlContent = xmlContent;
        }

        public string XmlContent { get; }
    }
}