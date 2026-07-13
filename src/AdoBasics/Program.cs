using System.Data;
using Microsoft.Data.Sqlite;

namespace AdoBasics;

internal static class Program
{
    private static void Main()
    {
        string databasePath = Path.Combine(AppContext.BaseDirectory, "students.db");
        string connectionString = $"Data Source={databasePath}";

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        CreateTable(connection);
        AddSampleData(connection);
        DisplayStudents(connection);
    }

    private static void CreateTable(SqliteConnection connection)
    {
        using var command = connection.CreateCommand();
        command.CommandText =
            """
            CREATE TABLE IF NOT EXISTS Students (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Course TEXT NOT NULL
            );
            """;
        command.ExecuteNonQuery();
    }

    private static void AddSampleData(SqliteConnection connection)
    {
        using var countCommand = connection.CreateCommand();
        countCommand.CommandText = "SELECT COUNT(*) FROM Students;";

        if (Convert.ToInt32(countCommand.ExecuteScalar()) > 0)
        {
            return;
        }

        using var insertCommand = connection.CreateCommand();
        insertCommand.CommandText =
            "INSERT INTO Students (Name, Course) VALUES ($name, $course);";

        // Parameters keep values separate from SQL and prevent SQL injection.
        insertCommand.Parameters.AddWithValue("$name", "Pragalva");
        insertCommand.Parameters.AddWithValue("$course", "CSC367");
        insertCommand.ExecuteNonQuery();
    }

    private static void DisplayStudents(SqliteConnection connection)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name, Course FROM Students ORDER BY Id;";

        using var reader = command.ExecuteReader();
        var table = new DataTable();
        // DataTable.Load creates a disconnected in-memory result, similar to an adapter fill.
        table.Load(reader);

        Console.WriteLine("Students in the SQLite database:");
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"{row["Id"]}: {row["Name"]} - {row["Course"]}");
        }
    }
}
