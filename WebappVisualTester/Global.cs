using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace WebappVisualTester
{
    public static class Global
    {
        public static bool DontCloseOtherInstances { get; set; } = true;
        public static string GetProjectsPath()
        {
            try
            {
                string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string projectsPath = currentPath + "\\Projects";
                if (!Directory.Exists(projectsPath))
                {
                    Directory.CreateDirectory(projectsPath);
                }
                return projectsPath;
            }
            catch { }
            return "";
        }

        public static void DeleteTempProjectDirectories()
        {
            var projectsPath=GetProjectsPath();            
                var directories = Directory.GetDirectories(projectsPath);
                if (directories.Any())
                {
                    foreach (var dir in directories)
                    {
                        Directory.Delete(dir,true);
                    }
                }            
        }
    }
}
