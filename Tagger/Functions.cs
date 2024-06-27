using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Tagger
{
    internal class Functions
    {
        public static string SafeGetString(SqliteDataReader reader, int column)
        {
            if (!reader.IsDBNull(column))
            {
                return reader.GetString(column);
            }
            return string.Empty;
        }

        public static Int32 getFileId(string fileName)
        {
            Int32 fileId = -1;
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var findFile = connection.CreateCommand();
                findFile.CommandText = $"" +
                    $"SELECT id " +
                    $"from FILES " +
                    $"WHERE name IS '{fileName}'";

                connection.Open();

                using (var reader = findFile.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        fileId = reader.GetInt32(0);
                    }
                }
            }
            return fileId;
        }
    }
}
