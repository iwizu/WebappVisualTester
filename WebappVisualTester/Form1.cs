﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public partial class Form1 : Form
    {
        IProjectManager projectManager;
        ILogger<Form1> logger;
        public Form1(IProjectManager projectManager, ILogger<Form1> logger)
        {
            InitializeComponent();
            this.projectManager = projectManager;
            this.logger = logger;
            logger.LogInformation("Init Form1");
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            if (projectManager.NewProject())
            {
                lblProjectPath.Text = projectManager.ProjectFilename;
            }
        }

        private void btnOpenProject_Click(object sender, EventArgs e)
        {
            if (projectManager.LoadProject())
            {
                lblProjectPath.Text = projectManager.ProjectFilename;
                if (projectManager.Project != null)
                    txtProjectTitle.Text = projectManager.Project.Title;
                RefreshTests();
            }
        }

        public void RefreshTests()
        {
            if (projectManager.Project.Tests!=null&& projectManager.Project.Tests.Any())
            {
                dgrTests.DataSource = projectManager.Project.Tests
                     .OrderBy(i => i.OrderIndex)
                     .ToList();
                dgrTests.Columns["OrderIndex"].Visible = false;
                dgrTests.Columns["_type"].Visible = false;
                dgrTests.Columns["Id"].Visible = false;
            }
            else
            {
                dgrTests.DataSource = null;
            }
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            projectManager.Project.Title = txtProjectTitle.Text;
            projectManager.SaveProject();
        }

        private void btnTestUp_Click(object sender, EventArgs e)
        {
            if(dgrTests.SelectedRows.Count>0)
            {
                var test = dgrTests.SelectedRows[0].DataBoundItem as Test;
                if(test!=null)
                {
                    var orderedProjects = projectManager.Project.Tests.OrderBy(i => i.OrderIndex).ToList();
                    var index= orderedProjects.IndexOf(test);
                    if(index>0)
                    {
                        orderedProjects[index - 1].OrderIndex = index + 1;
                        orderedProjects[index].OrderIndex = index;
                        projectManager.SaveProject();
                        RefreshTests();
                        dgrTests.ClearSelection();
                        dgrTests.Rows[index-1].Selected =true;
                    }
                }
            }
        }

        private void btnTestDown_Click(object sender, EventArgs e)
        {
            if (dgrTests.SelectedRows.Count > 0)
            {
                var test = dgrTests.SelectedRows[0].DataBoundItem as Test;
                if (test != null)
                {
                    var orderedTests = projectManager.Project.Tests.OrderBy(i => i.OrderIndex).ToList();
                    var index = orderedTests.IndexOf(test);
                    if (index < projectManager.Project.Tests.Count-1)
                    {
                        orderedTests[index + 1].OrderIndex = index + 1;
                        orderedTests[index].OrderIndex = index + 2;
                        projectManager.SaveProject();
                        RefreshTests();
                        dgrTests.ClearSelection();
                        dgrTests.Rows[index + 1].Selected = true;
                    }
                }
            }
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            var et = DependencyInjector.Resolve<EditTest>(new { parentForm = this });
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(et);
            et.Dock = DockStyle.Fill;
        }

        private void btnTestDelete_Click(object sender, EventArgs e)
        {
            if (dgrTests.SelectedRows.Count > 0)
            {
                var tst = dgrTests.SelectedRows[0].DataBoundItem as Test;
                if (tst != null)
                {
                    projectManager.Project.Tests.Remove(tst);
                }
            }
            projectManager.SaveProject();
            RefreshTests();
        }

        private void btnDuplicateTest_Click(object sender, EventArgs e)
        {
            if (dgrTests.SelectedRows.Count > 0)
            {
                var test = dgrTests.SelectedRows[0].DataBoundItem as Test;
                if (test != null)
                {
                    Test newTest = test.GetClone();
                    newTest.OrderIndex= projectManager.Project.Tests.Count;
                    projectManager.Project.Tests.Add(newTest);
                    RefreshTests();
                }
            }
        }

        private void dgrTests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrTests.SelectedRows.Count > 0)
            {
                var test = dgrTests.SelectedRows[0].DataBoundItem as Test;
                if (test != null)
                {
                    var et = DependencyInjector.Resolve<EditTest>(new { test = test });
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(et);
                    et.Dock = DockStyle.Fill;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var settings=DependencyInjector.Retrieve<ProjectSettingsForm>();
            settings.ShowDialog();
        }
    }
}
