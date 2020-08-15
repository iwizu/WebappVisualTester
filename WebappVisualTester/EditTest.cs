﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public partial class EditTest : UserControl
    {
        IProjectManager projectManager;
        Test test;
        Form1 parentForm;

        public EditTest(Test test,Form1 parentForm,IProjectManager projectManager)
        {
            InitializeComponent();
            this.test = test;
            this.parentForm = parentForm;
            this.projectManager = projectManager;

            string testFolder = Global.GetTestFolderPath(test, projectManager.Project);
            if(!Directory.Exists(testFolder+"\\Images"))
            {
                Directory.CreateDirectory(testFolder + "\\Images");
            }
            if (!Directory.Exists(testFolder + "\\dzi"))
            {
                Directory.CreateDirectory(testFolder + "\\dzi");
            }
        }

        private void EditTest_Load(object sender, EventArgs e)
        {
            RefreshCommands();
        }
        public void RefreshCommands()
        {
            if (test != null)
            {
                txtTitle.Text = test.Title;
                if (test.Commands != null && test.Commands.Any())
                {
                    var ds= test.Commands
                          .OrderBy(i => i.OrderIndex)
                          .ToList();
                    dgrCommands.DataSource=ds;
                    dgrCommands.Columns["OrderIndex"].Visible = false;
                    dgrCommands.Columns["_type"].Visible = false;
                    dgrCommands.Columns["Id"].Visible = false;
                }
            }
        }

        private void btnUpOrder_Click(object sender, EventArgs e)
        {
            if (dgrCommands.SelectedRows.Count > 0)
            {
                var command = dgrCommands.SelectedRows[0].DataBoundItem as Command;
                if (command != null)
                {
                    var orderedCommands = test.Commands.OrderBy(i => i.OrderIndex).ToList();
                    var index = orderedCommands.IndexOf(command);
                    if (index > 0)
                    {
                        orderedCommands[index - 1].OrderIndex = index+1;
                        orderedCommands[index].OrderIndex = index;
                        projectManager.SaveProject();
                        RefreshCommands();
                        dgrCommands.ClearSelection();
                        dgrCommands.Rows[index - 1].Selected = true;
                    }
                }
            }
        }

        public string GetTitle()
        {
            return txtTitle.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            if (parentForm != null)
            {
                parentForm.RefreshTests();
            }
        }
        private void Save()
        {
            if (test == null||test.OrderIndex==0)
            {
                test = new Test();
                test.Title = txtTitle.Text;
                test.OrderIndex= 1;
                if(projectManager.Project.Tests.Any())
                {
                    test.OrderIndex = projectManager.Project.Tests.Max(i => i.OrderIndex) + 1;
                }
                projectManager.Project.Tests.Add(test);
                projectManager.CreateTestFolder(test);
            }
            else
            {
                test.Title = txtTitle.Text;
            }
            projectManager.SaveProject();
        }

        private void btnCreateCommand_Click(object sender, EventArgs e)
        {
            if (test.OrderIndex < 1)
                Save();
            var editCmd=DependencyInjector.Resolve<EditCommand>(new { test=test, parentForm=this, projectManager });
            if(editCmd!=null)
            {
                editCmd.ShowDialog();
            }
        }

        private void dgrCommands_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgrCommands.SelectedRows.Count>0)
            {
               var cmd= dgrCommands.SelectedRows[0].DataBoundItem;
                if (cmd != null)
                {
                    var editCmd = DependencyInjector.Resolve<EditCommand>(new { command= cmd, test = test, parentForm = this, projectManager });
                    if (editCmd != null)
                    {
                        editCmd.ShowDialog();
                    }
                }
            }
        }

        private void btnDownOrder_Click(object sender, EventArgs e)
        {
            if (dgrCommands.SelectedRows.Count > 0)
            {
                var cmd = dgrCommands.SelectedRows[0].DataBoundItem as Command;
                if (cmd != null)
                {
                    var orderedCommands = test.Commands.OrderBy(i => i.OrderIndex).ToList();
                    var index = orderedCommands.IndexOf(cmd);
                    if (index < test.Commands.Count - 1)
                    {
                        orderedCommands[index + 1].OrderIndex = index+1;
                        orderedCommands[index].OrderIndex = index + 2;
                        projectManager.SaveProject();
                        RefreshCommands();
                        dgrCommands.ClearSelection();
                        dgrCommands.Rows[index + 1].Selected = true;
                    }
                }
            }
        }

        private void btnRemoveCommand_Click(object sender, EventArgs e)
        {
            if (dgrCommands.SelectedRows.Count > 0)
            {
                var cmd = dgrCommands.SelectedRows[0].DataBoundItem as Command;
                if (cmd != null)
                {
                    test.Commands.Remove(cmd);
                }
            }
            projectManager.SaveProject();
            RefreshCommands();
        }

        private void btnExecuteTest_Click(object sender, EventArgs e)
        {
            var executor=DependencyInjector.Resolve<TestExecutor>(new { test = test });
           string res= executor.Start(null,null);
            richTextBox1.Text = res;

            var projectFolder=Global.GetProjectsPath()+"\\"+projectManager.Project.Id;
            var testImagesFolder = projectFolder + "\\Tests\\" + test.Id+"\\Images";
            var dziFolder= projectFolder + "\\Tests\\" + test.Id + "\\dzi";
            if (Directory.Exists(testImagesFolder) && Directory.Exists(dziFolder))
            {
                    var dz = DependencyInjector.Retrieve<DeepZoomManager>();
                    dz.GetImages(testImagesFolder, dziFolder);
            }
            else
                MessageBox.Show("Images or dzi directory in Test folder does not exist");

            projectManager.SaveProject();
        }

        private void btnVisualNavigation_Click(object sender, EventArgs e)
        {
            var visNavForm = DependencyInjector.Resolve<VisualNavigationForm>(new { test=test });
            visNavForm.ShowDialog();
        }
    }
}
