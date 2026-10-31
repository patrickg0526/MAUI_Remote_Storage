namespace MAUI_Data_Access.Models
{
    public static class DatabaseConstants
    {
        public const string DatabaseFilename = "PeopleSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite
            // create the database if it doesn't exist
            | SQLite.SQLiteOpenFlags.Create
            // enable multi-threading
            | SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
