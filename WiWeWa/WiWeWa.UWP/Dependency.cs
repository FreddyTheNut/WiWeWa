using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WiWeWa.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(Dependency))]
namespace WiWeWa.UWP
{
    class Dependency : IDependency
    {
        public string GetLocalFilePath(string file)
        {
            var documentsPath = ApplicationData.Current.LocalFolder;
            return Path.Combine(documentsPath.DisplayName, file);
        }
    }
}
