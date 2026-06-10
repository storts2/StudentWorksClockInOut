using System;
using System.Collections.Generic;
using System.Text;

namespace StudentWorksClockInOut.Config;

public static class Constants
{
    public const string employeeDbName = "Employee.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string employeeDbPath =>
        Path.Combine(FileSystem.AppDataDirectory, employeeDbName);
}
