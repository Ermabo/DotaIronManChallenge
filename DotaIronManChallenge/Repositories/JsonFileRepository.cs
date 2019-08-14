using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotaIronManChallenge.Repositories
{
    public abstract class JsonFileRepository
    {
        protected JArray GetArrayFromJsonFile(string projectRoot, string fileName)
        {
            return JArray.Parse(System.IO.File.ReadAllText($"{projectRoot}/{fileName}"));
        }
    }
}
