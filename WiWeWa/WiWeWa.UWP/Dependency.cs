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
        public string GetLocalFilePath(string file)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            string dbPath = Path.Combine(path, file);

            CopyDatabaseIfNotExistsAsync(dbPath);

            return dbPath;
        }

        private void CopyDatabaseIfNotExistsAsync(string dbPath)
        {
            var storageFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!storageFile.FileExists(dbPath))
            {
                var assembly = this.GetType().Assembly;

                using (var resourceStream = assembly.GetManifestResourceStream("WiWeWa.UWP.IHKWiso.db"))
                {
                    using (var fileStream = storageFile.CreateFile(dbPath))
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
    }
}
