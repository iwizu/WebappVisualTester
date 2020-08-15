using System.Threading.Tasks;

namespace WebappVisualTester.Models
{
    public interface IProjectManager
    {
        string ProjectFilename { get; set; }
        Project Project { get; set; }
        bool NewProject();
        bool LoadProject();
        Task SaveProject();
        void CreateTestFolder(Test test);

    }
}
