using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WebappVisualTester.Converters;
using WebappVisualTester.Models;
using WebappVisualTester.Packaging;

namespace WebappVisualTester
{
    public class ProjectManager : IProjectManager
    {
        IPackageManager packageManager;
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
            if (IsDirty)
            {
                if (MessageBox.Show("There are unsaved changes. Do you want to Save them first?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveProject();
                }
            }
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "vtest Files | *.vtest";
            fileDialog.DefaultExt = "vtest";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ProjectFilename = fileDialog.FileName;
                var projectStr=packageManager.GetProjectFileInPackage(ProjectFilename);
                /*
                JsonSerializer serializer = new JsonSerializer();
                this.Project = JsonConvert.DeserializeObject<Project>(projectStr, new CustomJsonConverter());
                          */
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
            if (IsDirty)
            {
                if (MessageBox.Show("There are unsaved changes. Do you want to Save them first?", "Unsaved changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveProject();
                }
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
                var binder = new TypeNameSerializationBinder("ConsoleApplication.{0}, ConsoleApplication");
                
                /*var toserialize = new Project();
                toserialize.Id = this.Project.Id;
                toserialize.Title = this.Project.Title;

                foreach(var test in this.Project.Tests)
                {
                    var t = new Test();
                    t.Id = test.Id;
                    t.OrderIndex = test.OrderIndex;
                    t.Title = test.Title;
                    foreach (var test in this.Project.Tests)
                    {
                        t.Commands
                    }
                }
                toserialize.Commands.Add(
            new ClickButtonCommand()
            {
                _type = "Some1"
            });
                toserialize.CollectionToSerialize.Add(
                    new FillTextboxCommand()
                    {
                        Something2 = "Some2"
                    });
                */
                string jsonData = JsonConvert.SerializeObject(this.Project, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        //TypeNameHandling = TypeNameHandling.Auto,
                        //Binder = binder
                        TypeNameHandling = TypeNameHandling.Objects,
                        TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
                    });
                
                /*
                string jsonData = JsonConvert.SerializeObject(this.Project, Formatting.None, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });*/
                packageManager.CreatePackageWithProjectFile(ProjectFilename, jsonData);
            }
        }
    }
}
