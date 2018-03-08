using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WiWeWa.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(Dependency))]
namespace WiWeWa.iOS
{
    class Dependency : IDependency
    {
        public string GetLocalFilePath(string file)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, file);
        }
    }
}
