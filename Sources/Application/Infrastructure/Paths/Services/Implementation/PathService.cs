using System;
using System.IO;

namespace Mmu.FrenchLearningSystem.Infrastructure.Paths.Services.Implementation
{
    public class PathService : IPathService
    {
        public string GetSsmlFilePath()
        {
            return Path.Combine(GetAssemblyPath(), "Infrastructure", "Assets");
        }

        public string GetWavDestinationPath()
        {
            var path = Path.Combine(GetAssemblyPath(), "WavFiles");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        private static string GetAssemblyPath()
        {
            var uri = new UriBuilder(typeof(PathService).Assembly.Location);
            var path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);

            return path!;
        }
    }
}