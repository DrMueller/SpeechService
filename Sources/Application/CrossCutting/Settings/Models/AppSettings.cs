using JetBrains.Annotations;

namespace Mmu.SpeechService.CrossCutting.Settings.Models
{
    [PublicAPI]
    public class AppSettings
    {
        public const string SectionKey = "AppSettings";
        public string BlobConnectionString { get; set; } = null!;
        public string SpeechServiceApiKey { get; set; } = null!;
        public string SpeechServiceRegion { get; set; } = null!;
    }
}