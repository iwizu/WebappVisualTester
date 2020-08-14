using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.DeepZoomTools;

namespace WebappVisualTester
{
    public class DeepZoomManager
    {
        public void GetImages()
        {
            ImageCreator creator = new ImageCreator();
            creator.TileFormat = ImageFormat.Jpg;
            creator.TileOverlap = 1;
            creator.TileSize = 256;
            string path = @"C:\Users\iwizu\source\repos\WebappVisualTester\WebappVisualTester\bin\Debug\netcoreapp3.1\Screenshots";
            
            List<string> files = new List<string>();
            foreach(var file in Directory.GetFiles(path))
            {
                files.Add(file);
            };
            string root = path+"\\dzi\\";
            List<string> dzi = new List<string>();
            foreach (var name in files)
            {
                string output = Path.Combine(root, Path.GetFileNameWithoutExtension(name) + ".dzi");
                dzi.Add(output);
                creator.Create(name, output);
            }

            CollectionCreator ccreator = new CollectionCreator();
            ccreator.TileFormat = ImageFormat.Jpg;
            ccreator.TileOverlap = 1;
            ccreator.TileSize = 256;
            ccreator.Create(dzi, Path.Combine(root, "da.dzc"));
        }
    }
}
