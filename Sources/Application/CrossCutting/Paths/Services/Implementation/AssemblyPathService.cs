using System;
using System.IO;

namespace Mmu.FrenchLearningSystem.CrossCutting.Paths.Services.Implementation
{
    public class AssemblyPathService : IAssemblyPathService
    {
        //public string GetSsmlFilePath()
        //{
        //    return Path.Combine(GetAssemblyPath(), "CrossCutting", "Assets");
        //}

        //public string GetWavDestinationPath()
        //{
        //    var path = Path.Combine(GetAssemblyPath(), "WavFiles");

        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    return path;
        //}

        public string GetAssemblyPath()
        {
            var uri = new UriBuilder(typeof(AssemblyPathService).Assembly.Location);
            var path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);

            return path!;
        }
    }
}