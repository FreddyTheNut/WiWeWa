using Foundation;
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
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            string dbPath = Path.Combine(libFolder, file);

            CopyDatabaseIfNotExists(dbPath);

            return dbPath;
        }

        private void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("IHKWiso", "db");
                File.Copy(existingDb, dbPath);
            }

        }
    }
}
