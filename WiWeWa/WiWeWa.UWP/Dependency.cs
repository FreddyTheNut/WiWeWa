using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
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
        private string wisoDbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "IHKWiso.db");
        private string saveDbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "SaveData.db");

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
            var storageFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!storageFile.FileExists(wisoDbPath) || !(new FileInfo(wisoDbPath).Length > 0))
            {
                var assembly = this.GetType().Assembly;

                using (var resourceStream = assembly.GetManifestResourceStream("WiWeWa.UWP.IHKWiso.db"))
                {
                    using (var fileStream = storageFile.CreateFile(wisoDbPath))
                    {
                        byte[] readBuffer = new byte[4096];
                        int bytes = -1;

                        while ((bytes = resourceStream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            fileStream.Write(readBuffer, 0, bytes);
                        }
                    }
                }
            }
        }

        private bool UpdateDatabase()
        {
            string sourceFile = Windows.Storage.UserDataPaths.GetDefault().Downloads;

            if (File.Exists(sourceFile))
            {
                try
                {
                    File.Copy(sourceFile, wisoDbPath, true);
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
