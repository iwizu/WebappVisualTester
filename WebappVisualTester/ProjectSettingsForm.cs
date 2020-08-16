using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public partial class ProjectSettingsForm : Form
    {
        IProjectManager projectManager;
        public ProjectSettingsForm(IProjectManager projectManager)
        {
            InitializeComponent();
            this.projectManager = projectManager;
        }

        private void btnVisualNavigation_Click(object sender, EventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();           
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                lblStorePlace.Text = folderDialog.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            projectManager.Project.EnableCookies = chkEnableCookies.Checked;
            projectManager.Project.CookiesFolder = lblStorePlace.Text;
            projectManager.SaveProject();

            var settings = DependencyInjector.Retrieve<CefSettings>();
            settings.PersistSessionCookies = projectManager.Project.EnableCookies;
            settings.CachePath = projectManager.Project.CookiesFolder;

            Close();
        }

        private void ProjectSettingsForm_Load(object sender, EventArgs e)
        {
            chkEnableCookies.Checked = projectManager.Project.EnableCookies;
            lblStorePlace.Text = projectManager.Project.CookiesFolder;
        }
    }
}
