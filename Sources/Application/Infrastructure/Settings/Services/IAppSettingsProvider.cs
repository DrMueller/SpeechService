using Mmu.FrenchLearningSystem.Infrastructure.Settings.Models;

namespace Mmu.FrenchLearningSystem.Infrastructure.Settings.Services
{
    public interface IAppSettingsProvider
    {
        AppSettings Settings { get; }
    }
}