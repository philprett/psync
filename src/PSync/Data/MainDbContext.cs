using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync.Data
{
    internal class MainDbContext : DbContext
    {
        private static MainDbContext singleton;

        private static System.Data.SQLite.SQLiteConnection Connection
        {
            get
            {
                string exeFilename = System.Reflection.Assembly.GetExecutingAssembly().Location;

                string filename = string.Empty;

                string[] args = Environment.GetCommandLineArgs();
                foreach (string arg in args)
                {
                    if (arg.StartsWith("/"))
                    {

                    }
                    else if (string.IsNullOrWhiteSpace(filename))
                    {
                        if (!arg.Equals(exeFilename, StringComparison.CurrentCultureIgnoreCase))
                        {
                            filename = arg;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(filename))
                {
                    filename =
                        System.IO.Path.Combine(
                            System.IO.Path.GetDirectoryName(exeFilename),
                            "psync.db");
                }

                return
                    new System.Data.SQLite.SQLiteConnection(
                        string.Format(
                            "Data Source={0}",
                            filename));
            }
        }

        private MainDbContext() : base(Connection, true)
        {
            Database.SetInitializer<MainDbContext>(new CreateDatabaseIfNotExists<MainDbContext>());
        }

        public static MainDbContext DB
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new MainDbContext();
                    singleton.InitializeTables();
                }
                return singleton;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public void InitializeTables()
        {
            Database.ExecuteSqlCommand(
                "CREATE TABLE IF NOT EXISTS FolderSync " +
                "(" +
                "ID INTEGER NOT NULL PRIMARY KEY, " +
                "Name TEXT NOT NULL," +
                "Folder1 TEXT NOT NULL," +
                "Folder2 TEXT NOT NULL," +
                "Excludes TEXT NOT NULL," +
                "LastSync DATETIME NOT NULL" +
                ")");

            Database.ExecuteSqlCommand(
                "CREATE TABLE IF NOT EXISTS Setting " +
                "(" +
                "ID INTEGER NOT NULL PRIMARY KEY, " +
                "Name TEXT NOT NULL," +
                "Value TEXT NOT NULL" +
                ")");

            Setting dbVersion = Settings.FirstOrDefault(s => s.Name == "dbversion");
            if (dbVersion == null)
            {
                dbVersion = new Setting() { Name = "dbversion", Value = "1" };
                Settings.Add(dbVersion);
                SaveChanges();
            }

            ////////////////////////////////////////////////////////////////////////////
            // Version 2
            ////////////////////////////////////////////////////////////////////////////
            if (dbVersion.Value.GetInt() < 2)
            {
                Database.ExecuteSqlCommand(
                    "CREATE TABLE IF NOT EXISTS SyncedFile " +
                    "(" +
                    "ID INTEGER NOT NULL PRIMARY KEY, " +
                    "Path TEXT NOT NULL," +
                    "LastModified DATETIME NOT NULL" +
                    ")");
                dbVersion.Value = "2";
                SaveChanges();
            }
        }

        public DbSet<FolderSync> FolderSyncs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SyncedFile> SyncedFiles { get; set; }

    }
}
