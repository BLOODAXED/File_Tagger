using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
