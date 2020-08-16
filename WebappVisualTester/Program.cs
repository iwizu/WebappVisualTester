using CefSharp;
using CefSharp.WinForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Unity;
using WebappVisualTester.Models;
using WebappVisualTester.Packaging;

namespace WebappVisualTester
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Process current = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(current.ProcessName);
                if (processes.Count() > 1)
                {
                    if (MessageBox.Show("The system found running instances of the program. Do you want to close them? Press No to keep them open", "Other instances found", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Global.DontCloseOtherInstances = false;
                        foreach (Process process in processes)
                        {
                            if (process.Id != current.Id)
                            {
                                process.Kill();
                                Global.DeleteTempProjectDirectories();
                            }
                        }
                    }
                    else
                    {
                        Global.DontCloseOtherInstances = true;
                    }
                }
                else
                {
                    Global.DeleteTempProjectDirectories();
                }
            }
            catch { }
            
            DependencyInjector.Register<IProjectManager, ProjectManager>();
            DependencyInjector.Register<IPackageManager, PackageManager>();
            DependencyInjector.Register<ICommand, NavigateToUrlCommand>();
            DependencyInjector.UnityContainer.RegisterType<DeepZoomManager>();
            DependencyInjector.UnityContainer.RegisterType<VisualNavigationForm>();
            DependencyInjector.UnityContainer.RegisterType<CefSettings>();

            CefSettings settings = DependencyInjector.Retrieve<CefSettings>();
            // Initialize cef with the provided settings
            settings.CefCommandLineArgs.Add("disable-gpu", "1");
            //settings.PersistSessionCookies = true;
            //settings.CachePath = @"C:\cookies";
            Cef.Initialize(settings);
            Cef.EnableHighDPISupport();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DependencyInjector.Retrieve<Form1>());
        }
    }
}
