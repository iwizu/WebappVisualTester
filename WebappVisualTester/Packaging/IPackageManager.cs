using System;
using System.Collections.Generic;
using System.Text;

namespace WebappVisualTester.Packaging
{
    public interface IPackageManager
    {
        void CreatePackageFile(string filename);

        void CreatePackageWithProjectFile(string filename, string projectJson);
    }
}
