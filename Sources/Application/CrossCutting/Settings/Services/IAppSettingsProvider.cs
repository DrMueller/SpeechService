using Mmu.FrenchLearningSystem.CrossCutting.Settings.Models;

namespace Mmu.FrenchLearningSystem.CrossCutting.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}