using Newtonsoft.Json;
using System;
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
            
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "vtest Files | *.vtest";
            fileDialog.DefaultExt = "vtest";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ProjectFilename = fileDialog.FileName;
                var projectStr=packageManager.GetProjectFileInPackage(ProjectFilename);

                this.Project = JsonConvert.DeserializeObject<Project>(projectStr, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });

                IsDirty = false;
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool NewProject()
        {
            if (IsDirty && MessageBox.Show("There are unsaved changes. Do you want to Save them first?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveProject();
            }
            
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "vtest Files | *.vtest";
            fileDialog.DefaultExt = "vtest";
            if (fileDialog.ShowDialog()==DialogResult.OK)
            {
                ProjectFilename = fileDialog.FileName;
                Project = new Project();
                IsDirty = false;
            }
            else
            {
                return false;
            }
            return true;
        }

        public void SaveProject()
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
                packageManager.CreatePackageWithProjectFile(ProjectFilename, jsonData);
            }
        }
    }
}
