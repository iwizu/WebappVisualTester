using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebappVisualTester.Models;
using Unity;
using Unity.Lifetime;

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
            IUnityContainer UnityC;
            DependencyInjector.Register<IProjectManager, ProjectManager>();
            //DependencyInjector.Register<ICommand, Command>();


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(DependencyInjector.Retrieve<Form1>());
        }
    }
}
