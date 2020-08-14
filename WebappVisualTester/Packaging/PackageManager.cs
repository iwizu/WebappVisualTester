using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Threading.Tasks;
using WebappVisualTester.Models;

namespace WebappVisualTester.Packaging
{
    public class PackageManager : IPackageManager
    {
        readonly IProjectManager projectManager;

        public PackageManager(IProjectManager projectManager)
        {
            this.projectManager = projectManager;
        }
        
        public void CreatePackageFile(string filename)
        {
            File.Create(filename);
        }

        public void CreatePackageWithProjectFile(string filename, string projectJson)
        {
            using (var fs = File.Create(filename))
            using (var outStream = new ZipOutputStream(fs))
            {
                outStream.PutNextEntry(new ZipEntry("project.json"));

                using (var sw = new StreamWriter(outStream))
                {
                    sw.Write(projectJson);
                }
            }
        }

        public void AddFileToPackage(string packageFilename, string filename, byte[] content)
        {
            using (var fs = File.Create(filename))
            using (var outStream = new ZipOutputStream(fs))
            {
                outStream.PutNextEntry(new ZipEntry(Path.GetFileNameWithoutExtension(filename) + ".json"));
                /*
                using (var sw = new StreamWriter(outStream))
                {
                    //sw.Write(projectJson);
                }
                */
            }
        }
        public string GetProjectFileInPackage(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (var zf = new ZipFile(fs))
                {
                    var ze = zf.GetEntry("project.json");
                    if (ze == null)
                    {
                        throw new ArgumentException("project.json", "not found in Zip");
                    }

                    StreamReader reader = new StreamReader(zf.GetInputStream(ze));
                    string contents = reader.ReadToEnd();
                    return contents;
                }
            }
        }

        public async Task<bool> PackProject()
        {
            return await Task.Run(() =>
            {
                bool result = true;
                var projectDirectory = Global.GetProjectsPath() + "\\" + projectManager.Project.Id;
                if (Directory.Exists(projectDirectory))
                {
                    ZipProjectDirectory(projectDirectory, projectManager.ProjectFilename);
                }
                return result;
            });    
        }

        //https://stackoverflow.com/a/22444096
        public bool UnpackProject(string projectFilename)
        {
            bool result = true;
            var projectDirectory = Global.GetProjectsPath() + "\\" + projectManager.Project.Id;
            if (!Directory.Exists(projectDirectory))
            {
                Directory.CreateDirectory(projectDirectory);
            }
                var targetDir = projectDirectory;
                FastZip fastZip = new FastZip();
                string fileFilter = null;

                // Will always overwrite if target filenames already exist
                fastZip.ExtractZip(projectFilename, targetDir, fileFilter);
            
            return result;
        }
        public void ZipProjectDirectory(string sourceDirectory,string zipFilename)
        {
            ZipOutputStream zip = new ZipOutputStream(File.Create(zipFilename));

            zip.SetLevel(5);

            ZipFolder(sourceDirectory, sourceDirectory, zip);
            zip.Finish();
            zip.Close();
        }

        //https://stackoverflow.com/q/7977668
        public static void ZipFolder(string RootFolder, string CurrentFolder, ZipOutputStream zStream)
        {
            string[] SubFolders = Directory.GetDirectories(CurrentFolder);

            foreach (string Folder in SubFolders)
                ZipFolder(RootFolder, Folder, zStream);

            string relativePath = CurrentFolder.Substring(RootFolder.Length) + @"/";

            if (relativePath.Length > 1)
            {
                ZipEntry dirEntry;

                dirEntry = new ZipEntry(relativePath);
                dirEntry.DateTime = DateTime.Now;
            }

            foreach (string file in Directory.GetFiles(CurrentFolder))
            {
                AddFileToZip(zStream, relativePath, file);
            }
        }
        private static void AddFileToZip(ZipOutputStream zStream, string relativePath, string file)
        {
            byte[] buffer = new byte[4096];
            string fileRelativePath = (relativePath.Length > 1 ? relativePath : string.Empty) + Path.GetFileName(file);
            ZipEntry entry = new ZipEntry(fileRelativePath);

            entry.DateTime = DateTime.Now;
            zStream.PutNextEntry(entry);

            using (FileStream fs = File.OpenRead(file))
            {
                int sourceBytes;

                do
                {
                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                    zStream.Write(buffer, 0, sourceBytes);
                } while (sourceBytes > 0);
            }
        }

        private string GetFilenameWithoutPathAndExtension(string filename)
        {
            return Path.GetFileNameWithoutExtension(filename);
        }

        private string GetOnlyDirectory(string filename)
        {
            return Path.GetDirectoryName(filename);
        }
    }
}
