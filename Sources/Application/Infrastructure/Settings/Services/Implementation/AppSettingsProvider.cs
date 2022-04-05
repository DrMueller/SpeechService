using Microsoft.Extensions.Options;
using Mmu.FrenchLearningSystem.Infrastructure.Settings.Models;

namespace Mmu.FrenchLearningSystem.Infrastructure.Settings.Services.Implementation
{
    public class AppSettingsProvider : IAppSettingsProvider
    {
        private readonly IOptions<AppSettings> _settings;

        public AppSettingsProvider(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public AppSettings Settings => _settings.Value;
    }
}