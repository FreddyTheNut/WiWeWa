using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WiWeWa.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Dependency))]
namespace WiWeWa.Droid
{
    public class Dependency : IDependency
    {
        public string GetLocalFilePath(string file)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, file);
        }
    }
}