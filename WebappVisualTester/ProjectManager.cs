using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebappVisualTester.Models;
using WebappVisualTester.Packaging;

namespace WebappVisualTester
{
    public class ProjectManager : IProjectManager
    {
        readonly IPackageManager packageManager;
        public ProjectManager(IPackageManager packageManager)
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
                    packageManager.UnpackProject(ProjectFilename);

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
                }
                else
                {
                    return false;
                }
            }
            return true;
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
                packageManager.PackProject();
            }
            Directory.Delete(projectPath);
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
                await packageManager.PackProject();
            }
        }
    }
}
