using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public partial class VisualNavigationForm : Form
    {
        public ChromiumWebBrowser chromeBrowser;
        readonly Test test;
        readonly IProjectManager projectManager;
        public VisualNavigationForm(Test test, IProjectManager projectManager)
        {
            InitializeComponent();
            this.test=test;
            this.projectManager = projectManager;

            RefreshBrowser();
        }

        public void RefreshBrowser()
        {
            picWait.Visible = true;
            Application.DoEvents();
            string pagePath = PrepareIndexPage();
            chromeBrowser = new ChromiumWebBrowser(pagePath);
            chromeBrowser.BrowserSettings.WebSecurity = CefState.Disabled;
            chromeBrowser.BrowserSettings.FileAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.ConsoleMessage += ChromeBrowser_ConsoleMessage;
            chromeBrowser.LoadingStateChanged += ChromeBrowser_LoadingStateChanged;

            // Add it to the form and fill it to the form window.
            panel1.Controls.Clear();
            panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void ChromeBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                picWait.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    picWait.Visible = false;
                });
                Application.DoEvents();
            }
        }


        private void ChromeBrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private string PrepareIndexPage()
        {
            try
            {
                string visualNavigationFolder = Global.GetVisualNavigationPath();
                string testFolder = Global.GetTestFolderPath(test, projectManager.Project);
                string dziFolder = testFolder + "\\dzi";
                string indexFilename = visualNavigationFolder + "\\index.html";
                if (!Directory.Exists(visualNavigationFolder)
                    || !Directory.Exists(testFolder)
                    || !File.Exists(indexFilename)
                    || !Directory.Exists(dziFolder))
                {
                    MessageBox.Show("VisualNavigation directory does not exist");
                    return "";
                }

                bool firstItemInList = true;
                List<string> dataRecord = new List<string>();
                string data = "";
                var orderedScreenshotCommands = test.Commands.Where(i=>i._type.Contains("TakeScreenshotCommand")).OrderBy(i => i.OrderIndex).ToList();
                foreach (var cmd in orderedScreenshotCommands)
                {
                    dataRecord.Add(cmd.Title);
                    if (firstItemInList)
                    {
                        firstItemInList = false;
                        data = "{ title: '"+ cmd.Title + "', details: '' }";
                    }
                    else
                    {
                        data += ",\n{ title: '" + cmd.Title + "', details: '' }";
                    }
                }

                firstItemInList = true;
                List<string> dziFiles = Directory.GetFiles(dziFolder, "*.dzi").OrderBy(f => f).ToList();
                string tileSources = "";
                foreach(var dziFile in dziFiles)
                {
                    if(firstItemInList)
                    {
                        firstItemInList = false;
                        tileSources = "{ tileSource: 'dzi/" + Path.GetFileName(dziFile) + "' }";
                    }
                    else
                    {
                        tileSources += ",\n{ tileSource: 'dzi/" + Path.GetFileName(dziFile) + "' }";
                    }                    
                }
                
                string indexInTestFolderPath = testFolder + "\\index.html";
                File.Copy(indexFilename, indexInTestFolderPath,true);
                string indexContents=File.ReadAllText(indexInTestFolderPath);
                int tileSize =0;
                int rows = 0;
                int margin=0;
                if(int.TryParse(txtTileSize.Text,out tileSize)
                    && int.TryParse(txtRows.Text, out rows)
                    && int.TryParse(txtMargin.Text, out margin))
                {
                    indexContents=indexContents.Replace("__TILEWIDTH__", tileSize.ToString());
                    indexContents = indexContents.Replace("__ROWSNUM__", rows.ToString());
                    indexContents = indexContents.Replace("__MARGINBETWEENTILES__", margin.ToString());
                    indexContents = indexContents.Replace("__TILESOURCES__", tileSources);
                    indexContents = indexContents.Replace("__DATA__", data);
                    File.WriteAllText(indexInTestFolderPath, indexContents);
                    return indexInTestFolderPath;
                }
            }
            catch
            { }
            return "";
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshBrowser();
        }
    }
}
