using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebappVisualTester.Packaging
{
    public class PackageManager : IPackageManager
    {
        public void CreatePackageFile(string filename)
        {
            using (var fs = File.Create(filename))
            {
            }
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

                using (var sw = new StreamWriter(outStream))
                {
                    //sw.Write(projectJson);
                }
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
