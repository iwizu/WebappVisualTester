using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebappVisualTester.Models;
using WebappVisualTester.Packaging;

namespace WebappVisualTester
{
    public class ProjectManager : IProjectManager
    {
        PackageManager packageManager;
        public ProjectManager(PackageManager packageManager)
        {
            Project = new Project();
            this.packageManager = packageManager;
        }

        public string ProjectFilename { get; set; }

        public Project Project { get; set; }

        public bool IsDirty { get; set; }


        public bool LoadProject()
        {
            if (IsDirty && MessageBox.Show("There are unsaved changes. Do you want to Save them first?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveProject();
            }

            bool loadProject = CheckIfPreviousProjectDirectoryWillBeClosed();

            if (loadProject)
            {
                var fileDialog = new OpenFileDialog();
                fileDialog.Filter = "vtest Files | *.vtest";
                fileDialog.DefaultExt = "vtest";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProjectFilename = fileDialog.FileName;
                    string projectStr=packageManager.GetProjectFileInPackage(ProjectFilename);
                    this.Project = JsonConvert.DeserializeObject<Project>(projectStr, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects
                    });

                    var settings = DependencyInjector.Retrieve<CefSettings>();
                    settings.PersistSessionCookies = this.Project.EnableCookies;
                    settings.CachePath = this.Project.CookiesFolder;

                    packageManager.UnpackProject(this.Project.Id,ProjectFilename);

                    IsDirty = false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool NewProject()
        {
            if (IsDirty && MessageBox.Show("There are unsaved changes. Do you want to Save them first?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveProject();
            }

            bool createNewProject = CheckIfPreviousProjectDirectoryWillBeClosed();     

            if (createNewProject)
            {
                var fileDialog = new SaveFileDialog();
                fileDialog.Filter = "vtest Files | *.vtest";
                fileDialog.DefaultExt = "vtest";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProjectFilename = fileDialog.FileName;
                    Project = new Project();
                    IsDirty = false;

                    var projectsPath = Global.GetProjectsPath();
                    var projectPath = projectsPath + @"\\" + this.Project.Id;
                    if (!Directory.Exists(projectPath))
                    {
                        Directory.CreateDirectory(projectPath);
                        string projectJsonFilePath = projectPath + "\\project.json";
                        File.WriteAllText(projectJsonFilePath, "");
                        Directory.CreateDirectory(projectPath + "\\Tests");
                        Directory.CreateDirectory(projectPath + "\\openseadragon");
                        string openseadragonFolder = projectPath + "\\Openseadragon";                        
                        string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                        string visualNavigationFolder = currentPath + "\\VisualNavigation";
                        string openseadragonPath = visualNavigationFolder+"\\openseadragon";
                        Copy(openseadragonPath, projectPath + "\\openseadragon");                        
                    }
                    
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private bool CheckIfPreviousProjectDirectoryWillBeClosed()
        {
            var projectsPath = Global.GetProjectsPath();
            var previousProjectPath = projectsPath + @"\\" + this.Project.Id;
            if (Directory.Exists(previousProjectPath))
            {
                if (MessageBox.Show("Do you want to close the previous project?", "Close previous project?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CloseProject();
                }
                else
                {
                  return false;
                }
            }
            return true;
        }

        public void CloseProject()
        {
            var projectsPath = Global.GetProjectsPath();
            var projectPath = projectsPath + @"\\" + this.Project.Id;
            if (Directory.Exists(projectPath))
            {
                packageManager.PackProject(this.Project.Id,this.ProjectFilename);
            }
            Directory.Delete(projectPath,true);
        }

        public void CreateTestFolder(Test test)
        {
            var projectFolder = Global.GetProjectsPath() + "\\" + this.Project.Id;
            var testsFolder = projectFolder + "\\Tests";
            if(!Directory.Exists(testsFolder+"\\"+test.Id))
            {
                Directory.CreateDirectory(testsFolder + "\\" + test.Id+"\\Images");
                Directory.CreateDirectory(testsFolder + "\\" + test.Id + "\\dzi");
            }
        }

        public async Task SaveProject()
        {
            IsDirty = false;
            if (!string.IsNullOrEmpty(ProjectFilename))
            {                
                string jsonData = JsonConvert.SerializeObject(this.Project, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Objects,
                        TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                    });
                string projectJsonPath = Global.GetProjectsPath()+"\\"+this.Project.Id+"\\project.json";
                await File.WriteAllTextAsync(projectJsonPath, jsonData);
                await packageManager.PackProject(this.Project.Id,ProjectFilename);
            }
        }
    }
}
