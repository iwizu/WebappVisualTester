using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WebappVisualTester.Converters;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public class ProjectManager : IProjectManager
    {
        public ProjectManager()
        {
            Project = new Project();
        }

        public string ProjectFilename { get; set; }

        public Project Project { get; set; }

        public bool IsDirty { get; set; }


        public bool LoadProject()
        {
            if (IsDirty)
            {
                if (MessageBox.Show("There are unsaved changes. Do you want to Save them first?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveProject();
                }
            }
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Json Files | *.json";
            fileDialog.DefaultExt = "json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ProjectFilename = fileDialog.FileName;
                using (StreamReader file = File.OpenText(ProjectFilename))
                {
                    JsonSerializer serializer = new JsonSerializer();                    
                    //this.Project = (Project)serializer.Deserialize(file, typeof(Project));
                    this.Project =JsonConvert.DeserializeObject<Project>(file.ReadToEnd(), new CustomJsonConverter());
                }
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
            if (IsDirty)
            {
                if (MessageBox.Show("There are unsaved changes. Do you want to Save them first?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveProject();
                }
            }
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Json Files | *.json";
            fileDialog.DefaultExt = "json";
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
                string jsonData = JsonConvert.SerializeObject(this.Project, Formatting.None, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                File.WriteAllText(ProjectFilename, jsonData);
            }
        }
    }
}
