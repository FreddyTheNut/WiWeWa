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
        private string wisoDbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "IHKWiso.db");
        private string saveDbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SaveData.db");

        public string GetWisoDataBasePath()
        {
            if (!UpdateDatabase())
                CopyDatabaseIfNotExists();

            return wisoDbPath;
        }

        public string GetSaveDatabasePath()
        {
            return saveDbPath;
        }

        private void CopyDatabaseIfNotExists()
        {
           if (!File.Exists(wisoDbPath) || !(new FileInfo(wisoDbPath).Length > 0))
           {
               using (var br = new BinaryReader(Application.Context.Assets.Open("IHKWiso.db")))
               {
                   using (var bw = new BinaryWriter(new FileStream(wisoDbPath, FileMode.Create)))
                   {
                       byte[] buffer = new byte[2048];
                       int length = 0;
                       while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                       {
                           bw.Write(buffer, 0, length);
                       }
                   }
               }
           }
        }

        private bool UpdateDatabase()
        {
            string sourceFile = "/storage/emulated/0/Download/IHKWiso.db";

            if (File.Exists(sourceFile))
            {
                try
                {
                    File.Copy(sourceFile, wisoDbPath);
                    File.Delete(sourceFile);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}