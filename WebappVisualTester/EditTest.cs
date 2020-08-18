using Microsoft.Extensions.Logging;
using System;
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
        ILogger logger;
        Test test;
        Form1 parentForm;

        public EditTest(Test test,Form1 parentForm,IProjectManager projectManager, ILogger logger)
        {
            InitializeComponent();
            this.test = test;
            this.parentForm = parentForm;
            this.projectManager = projectManager;
            this.logger = logger;

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
                        .Select(i=> new { 
                         i.Id,
                            i.Title,
                            BelongsToCommand =test.Commands.FirstOrDefault(j=>j.Id==i.BelongsToCommandIndex)?.Title,
                            i.RunSuccessfuly,
                            i.OrderIndex
                        })
                          .OrderBy(i => i.OrderIndex)
                          .ToList();
                    dgrCommands.DataSource=ds;
                    dgrCommands.Columns["OrderIndex"].Visible = false;
                    dgrCommands.Columns["Id"].Visible = false;
                    ResizeGrid();

                    bool runSuccessfuly = true;
                    foreach(var itm in test.Commands)
                    {
                        if (!itm.RunSuccessfuly)
                        {
                            runSuccessfuly = false;
                        }
                    }
                    var img = Properties.Resources.Ok_48px;
                    if (!runSuccessfuly)
                        img = Properties.Resources.Error_48px;
                        picResult.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            picResult.Image = img;
                        });                  
                }
            }
        }

        private void btnUpOrder_Click(object sender, EventArgs e)
        {
            if (dgrCommands.SelectedRows.Count > 0)
            {
                //var cmd= dgrCommands.SelectedRows[0].DataBoundItem;
                Guid? id = dgrCommands.SelectedRows[0].Cells["Id"].Value as Guid?;
                if (id.HasValue)
                {
                    var command = test.Commands.FirstOrDefault(i => i.Id == id);
                    if (command != null)
                    {
                        var orderedCommands = test.Commands.OrderBy(i => i.OrderIndex).ToList();
                        var index = orderedCommands.IndexOf(command);
                        if (index > 0)
                        {
                            orderedCommands[index - 1].OrderIndex = index + 1;
                            orderedCommands[index].OrderIndex = index;
                            projectManager.SaveProject();
                            RefreshCommands();
                            dgrCommands.ClearSelection();
                            dgrCommands.Rows[index - 1].Selected = true;
                        }
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
                Guid? id=dgrCommands.SelectedRows[0].Cells["Id"].Value as Guid?;
                if (id.HasValue)
                {
                    var cmd = test.Commands.FirstOrDefault(i => i.Id == id);
                    if (cmd != null)
                    {
                        var editCmd = DependencyInjector.Resolve<EditCommand>(new { command = cmd, test = test, parentForm = this, projectManager });
                        if (editCmd != null)
                        {
                            editCmd.ShowDialog();
                        }
                    }
                }
            }
        }

        private void btnDownOrder_Click(object sender, EventArgs e)
        {
            //var cmd= dgrCommands.SelectedRows[0].DataBoundItem;
            if (dgrCommands.SelectedRows.Count > 0)
            {
                Guid? id = dgrCommands.SelectedRows[0].Cells["Id"].Value as Guid?;
                if (id.HasValue)
                {
                    var cmd = test.Commands.FirstOrDefault(i => i.Id == id);
                    if (cmd != null)
                    {
                        var orderedCommands = test.Commands.OrderBy(i => i.OrderIndex).ToList();
                        var index = orderedCommands.IndexOf(cmd);
                        if (index < test.Commands.Count - 1)
                        {
                            orderedCommands[index + 1].OrderIndex = index + 1;
                            orderedCommands[index].OrderIndex = index + 2;
                            projectManager.SaveProject();
                            RefreshCommands();
                            dgrCommands.ClearSelection();
                            dgrCommands.Rows[index + 1].Selected = true;
                        }
                    }
                }
            }
        }

        private void btnRemoveCommand_Click(object sender, EventArgs e)
        {
            if (dgrCommands.SelectedRows.Count > 0)
            {
                Guid? id = dgrCommands.SelectedRows[0].Cells["Id"].Value as Guid?;
                if (id.HasValue)
                {
                    var cmd = test.Commands.FirstOrDefault(i => i.Id == id);
                    if (cmd != null)
                    {
                        test.Commands.Remove(cmd);
                    }
                }
            }
            projectManager.SaveProject();
            RefreshCommands();
        }

        private void btnExecuteTest_Click(object sender, EventArgs e)
        {
            var projectFolder = Global.GetProjectsPath() + "\\" + projectManager.Project.Id;
            var testImagesFolder = projectFolder + "\\Tests\\" + test.Id + "\\Images";
            var dziFolder = projectFolder + "\\Tests\\" + test.Id + "\\dzi";
            DeleteAllInDirectory(testImagesFolder);
            DeleteAllInDirectory(dziFolder);
            logger.LogInformation("Execute Test started. Project folder:" + projectFolder
                + "\nTestImagesFolder:" + testImagesFolder
                + "\nDziFolder:" + dziFolder);


            var executor =DependencyInjector.Resolve<TestExecutor>(new { test = test });
           string res= executor.Start(null,null);
            richTextBox1.Text = res;

            
            if (Directory.Exists(testImagesFolder) && Directory.Exists(dziFolder))
            {
                    var dz = DependencyInjector.Retrieve<DeepZoomManager>();
                    dz.GetImages(testImagesFolder, dziFolder);
            }
            else
                MessageBox.Show("Images or dzi directory in Test folder does not exist");

            projectManager.SaveProject();
            RefreshCommands();
        }

        private void DeleteAllInDirectory(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void btnVisualNavigation_Click(object sender, EventArgs e)
        {
            var visNavForm = DependencyInjector.Resolve<VisualNavigationForm>(new { test=test });
            visNavForm.ShowDialog();
        }

        private void dgrCommands_Resize(object sender, EventArgs e)
        {
            ResizeGrid();
        }
        private void ResizeGrid()
        {
            if (dgrCommands.ColumnCount == 5)
            {
                dgrCommands.Columns["RunSuccessfuly"].Width = 29;
                dgrCommands.Columns["BelongsToCommand"].Width = 150;
                var value = dgrCommands.Width -
                    dgrCommands.Columns["RunSuccessfuly"].Width -
                    dgrCommands.Columns["BelongsToCommand"].Width
                   - dgrCommands.RowHeadersWidth - 2;
                dgrCommands.Columns["Title"].Width = value;
            }
        }
        private void dgrCommands_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
                    dgrCommands.Rows[e.RowIndex].Cells[2].ReadOnly = true;                       
        }
    }
}
