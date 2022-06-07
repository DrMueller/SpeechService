using Mmu.SpeechService.CrossCutting.Settings.Models;

namespace Mmu.SpeechService.CrossCutting.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}