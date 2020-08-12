using System;
using System.Windows.Forms;
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
            DependencyInjector.Register<IProjectManager, ProjectManager>();
            DependencyInjector.Register<IPackageManager, PackageManager>();
            DependencyInjector.Register<ICommand, NavigateToUrlCommand>();


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DependencyInjector.Retrieve<Form1>());
        }
    }
}
