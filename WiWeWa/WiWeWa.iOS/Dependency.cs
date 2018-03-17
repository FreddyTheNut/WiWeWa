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
        private string wisoDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Databases", "IHKWiso.db");
        private string saveDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Databases", "SaveData.db");

        public string GetWisoDataBasePath()
        {
            string libFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

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
                var existingDb = NSBundle.MainBundle.PathForResource("IHKWiso", "db");
                File.Copy(existingDb, wisoDbPath);
            }
        }

        private bool UpdateDatabase()
        {
            return false;
        }
    }
}
