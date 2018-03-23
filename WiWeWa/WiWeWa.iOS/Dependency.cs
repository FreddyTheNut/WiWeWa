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

            CopyDatabaseIfNotExists();

            return wisoDbPath;
        }

        public string GetSaveDatabasePath()
        {
            return saveDbPath;
        }

        private void CopyDatabaseIfNotExists()
        {
            if (!File.Exists(wisoDbPath))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("IHKWiso", "db");
                File.Copy(existingDb, wisoDbPath);
            }
            else
            {
                string wisoDB;
                string wisoDBcopy;

                using (StreamReader sr = new StreamReader(NSBundle.MainBundle.PathForResource("IHKWiso", "db")))
                {
                    wisoDB = sr.ReadToEnd();
                }

                using (StreamReader sr = new StreamReader(wisoDbPath))
                {
                    wisoDBcopy = sr.ReadToEnd();
                }

                if (wisoDB.Length != wisoDBcopy.Length)
                {
                    File.Delete(wisoDbPath);

                    var existingDb = NSBundle.MainBundle.PathForResource("IHKWiso", "db");
                    File.Copy(existingDb, wisoDbPath);
                }
            }
        }
    }
}
