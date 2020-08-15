using System;
using System.IO;
using System.Reflection;
using System.Linq;
using WebappVisualTester.Models;

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

        public static string GetProjectFolderPath(Project project)
        {
            try
            {
                string currentPath = GetProjectsPath();
                string projectFolderPath = currentPath + "\\"+ project.Id;
                if (!Directory.Exists(projectFolderPath))
                {
                    Directory.CreateDirectory(projectFolderPath);
                }
                return projectFolderPath;
            }
            catch { }
            return "";
        }

        public static string GetTestFolderPath(Test test,Project project)
        {
            try
            { 
                string projectPath = GetProjectFolderPath(project);
                string testFolderPath = projectPath + "\\Tests\\"+test.Id;
                if (!Directory.Exists(testFolderPath))
                {
                    Directory.CreateDirectory(testFolderPath);
                }
                return testFolderPath;
            }
            catch { }
            return "";
        }

        public static string GetVisualNavigationPath()
        {
            try
            {
                string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string visualNavigationFolderPath = currentPath + "\\VisualNavigation";
                if (!Directory.Exists(visualNavigationFolderPath))
                {
                    Directory.CreateDirectory(visualNavigationFolderPath);
                }
                return visualNavigationFolderPath;
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
