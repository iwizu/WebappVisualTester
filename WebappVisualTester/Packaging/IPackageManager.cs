using System;
using System.Threading.Tasks;

namespace WebappVisualTester.Packaging
{
    public interface IPackageManager
    {
        void CreatePackageFile(string filename);

        void CreatePackageWithProjectFile(string filename, string projectJson);

        string GetProjectFileInPackage(string filename);

        Task<bool> PackProject(Guid projectId, string projectFilename);

        bool UnpackProject(Guid projectId, string projectFilename);
    }
}
