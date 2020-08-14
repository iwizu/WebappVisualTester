using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace WebappVisualTester
{
    public partial class VisualNavigationForm : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        public VisualNavigationForm()
        {
            InitializeComponent();
            /*
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrlsAllowed = true;
            browserSettings.UniversalAccessFromFileUrlsAllowed = true;
            browserSettings.TextAreaResizeDisabled = true;
            string urlToNavigate =
                           Application.StartupPath + @"\res\www\shared\index.html";
            web_view = new WebView(urlToNavigate, browserSettings);
            */
            
            
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(@"C:\Users\iwizu\source\repos\WebappVisualTester\WebappVisualTester\bin\Debug\netcoreapp3.1\Screenshots\DeepZoom\a.html");
            chromeBrowser.BrowserSettings.WebSecurity = CefState.Disabled;
            chromeBrowser.BrowserSettings.FileAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            // Add it to the form and fill it to the form window.
            panel1.Controls.Clear();
            panel1.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void GetDeepZoomImages()
        {
            DeepZoomManager deepZoomManager = new DeepZoomManager();
            deepZoomManager.GetImages();
        }
    }
}
