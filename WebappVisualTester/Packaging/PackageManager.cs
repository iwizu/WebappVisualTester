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
                outStream.PutNextEntry(new ZipEntry(Path.GetFileNameWithoutExtension(filename) + ".json"));

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
