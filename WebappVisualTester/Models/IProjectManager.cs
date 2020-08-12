using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Models
{
    public interface IProjectManager
    {
        public string ProjectFilename { get; set; }
        public Project Project { get; set; }
        public bool NewProject();
        public bool LoadProject();
        public void SaveProject();

    }
}
