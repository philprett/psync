using PSync.extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.classes
{
    class DataStore
    {
        private static DataStore singleton;

        private SQLiteConnection db;

        private DataStore()
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.SettingsDatabaseFoldername);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filename = Path.Combine(folder, Constants.SettingsDatabaseFilename);

            SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();
            sb.DataSource = filename;
            sb.Password = Constants.SettingsDatabasePassword;
            db = new SQLiteConnection(sb.ConnectionString);

            db.Open();
            CheckDBVersion();
        }

        private void CheckDBVersion()
        {
            int dbVersion;
            try
            {
                dbVersion = (int)db.ExecuteScalar("SELECT version FROM dbversion");
            }
            catch
            {
                dbVersion = 0;
            }

            if (dbVersion < 1)
            {
                db.ExecuteNonQuery("CREATE TABLE dbversion (version INT NOT NULL)");
                db.ExecuteNonQuery("INSERT INTO dbversion (version) VALUES (@dbversion)", new[] { new SQLiteParameter("@dbversion", 1) });
                dbVersion = 1;
            }

            if (dbVersion < 2)
            {
                db.ExecuteNonQuery("CREATE TABLE settings (name VARCHAR(1000) NOT NULL, value VARCHAR(1000) NOT NULL)");
                dbVersion = 2;
            }

            if (dbVersion < 3)
            {
                db.ExecuteNonQuery("CREATE TABLE foldersyncs (id VARCHAR(100) PRIMARY KEY, name VARCHAR(1000) NOT NULL, folder1 VARCHAR(1000) NOT NULL, folder2 VARCHAR(1000) NOT NULL, excludes VARCHAR(8000) NOT NULL)");
                dbVersion = 3;
            }
            db.ExecuteNonQuery("UPDATE dbversion SET version = @dbversion", new[] { new SQLiteParameter("@dbversion", dbVersion) });
        }

        public static DataStore Current
        {
            get
            {
                try
                {
                    if (singleton == null)
                    {
                        singleton = new DataStore();
                    }
                    return singleton;
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<FolderSync> GetFolderSyncs()
        {
            List<FolderSync> ret = new List<FolderSync>();
            DataTable rs = db.ExecuteQuery("SELECT id, name, folder1, folder2, excludes FROM foldersyncs");
            foreach (DataRow row in rs.Rows)
            {
                ret.Add(new FolderSync(row));
            }
            return ret;
        }

        public void SaveFolderSync(FolderSync folderSync)
        {
            int found = (int)(long)db.ExecuteScalar("SELECT count(*) FROM foldersyncs WHERE id = @id", new[] { new SQLiteParameter("@id", folderSync.ID.ToString()) });
            if (found > 0)
            {
                db.ExecuteNonQuery(
                    "UPDATE foldersyncs SET name = @name, folder1 = @folder1, folder2 = @folder2, excludes = @excludes WHERE id = @id",
                    new[]
                    {
                        new SQLiteParameter("@id",folderSync.ID.ToString()),
                        new SQLiteParameter("@name",folderSync.Name),
                        new SQLiteParameter("@folder1",folderSync.Folder1),
                        new SQLiteParameter("@folder2",folderSync.Folder2),
                        new SQLiteParameter("@excludes",string.Join("|", folderSync.Excludes)),
                    });
            }
            else
            {
                db.ExecuteNonQuery(
                    "INSERT INTO foldersyncs (id, name, folder1, folder2, excludes) VALUES (@id, @name, @folder1, @folder2, @excludes)",
                    new[]
                    {
                        new SQLiteParameter("@id",folderSync.ID.ToString()),
                        new SQLiteParameter("@name",folderSync.Name),
                        new SQLiteParameter("@folder1",folderSync.Folder1),
                        new SQLiteParameter("@folder2",folderSync.Folder2),
                        new SQLiteParameter("@excludes",string.Join("|", folderSync.Excludes)),
                    });
            }
        }

        public void DeleteFolderSync(FolderSync folderSync)
        {
            db.ExecuteNonQuery(
                "DELETE FROM foldersyncs WHERE id = @id",
                new[]
                {
                        new SQLiteParameter("@id",folderSync.ID.ToString()),
                });
        }
    }
}
