using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Tagger
{
    public class Tag_Handler
    {

        public static Tag GetTag(string searchTerm)
        {
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var findTag = connection.CreateCommand();
                findTag.CommandText = $"" +
                    $"SELECT tagName, description " +
                    $"from TAGS " +
                    $"WHERE tagName IS '{searchTerm}'";

                connection.Open();

                using (var reader = findTag.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tag(reader.GetString(0), reader.GetString(1));
                    }
                }
            }
            return null;
        }


        public static List<Tag> GetAllTags()
        {
            List<Tag> tagList = new List<Tag>();
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var findTag = connection.CreateCommand();
                findTag.CommandText = $"" +
                    $"SELECT tagName, description " +
                    $"from TAGS ";

                connection.Open();

                using (var reader = findTag.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tagList.Add(new Tag(Functions.SafeGetString(reader, 0), Functions.SafeGetString(reader, 1)));
                    }
                }
                foreach (var tag in tagList)
                {
                    tag.count = CountTag(tag.name);
                }
            }
            return tagList;
        }

        public static List<Tag> GetAllTagsOnFile(string file)
        {
            List<Tag> tagList = new List<Tag>();
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var findTag = connection.CreateCommand();
                findTag.CommandText = $"" +
                    $"SELECT tagName from TAGS " +
                    $"JOIN FILETAGS on FILETAGS.tagID = TAGS.id " +
                    $"JOIN FILES on FILETAGS.fileID = FILES.id " +
                    $"WHERE FILES.name IS '{file}'";

                connection.Open();

                using (var reader = findTag.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tagList.Add(new Tag(Functions.SafeGetString(reader, 0)));
                    }
                }
                foreach (var tag in tagList)
                {
                    tag.count = CountTag(tag.name);
                }
            }
            return tagList;
        }

        public static long CountTag(string searchTerm)
        {
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var countTags = connection.CreateCommand();
                countTags.CommandText = $"" +
                    $"Select Count(tagID) From FILETAGS JOIN TAGS " +
                    $"on TAGS.id = FILETAGS.tagID " +
                    $"WHERE TAGS.tagName IS '{searchTerm}'";

                connection.Open();

                long count = (long)countTags.ExecuteScalar();

                return count;
            }
        }

        public static void AddTagToFile(string fileName, string tagName)
        {
            MessageBox.Show(fileName + " " + tagName);
            Int64 tag = -1;
            Int64 file = -1;
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var findTag = connection.CreateCommand();
                findTag.CommandText = $"" +
                    $"SELECT id " +
                    $"from TAGS " +
                    $"WHERE tagName IS '{tagName}'";

                connection.Open();

                using (var reader = findTag.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tag = reader.GetInt32(0);
                    }
                }
                var findFile = connection.CreateCommand();
                findFile.CommandText = $"" +
                    $"SELECT id " +
                    $"from FILES " +
                    $"WHERE name IS '{fileName}'";

                using (var reader = findFile.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        file = reader.GetInt32(0);
                    }
                }
            }

            if (file != -1)
            {
                if (tag == -1)
                {
                    tag = CreateTag(tagName);
                    if (tag == -1)
                    {
                        MessageBox.Show("Failed to add new tag");
                        return;
                    }
                }
                using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadWriteCreate"))
                {
                    connection.Open();
                    var addTag = connection.CreateCommand();
                    addTag.CommandText = $"" +
                        $"INSERT INTO FILETAGS " +
                        $"(fileID, tagID)" +
                        $"VALUES ('{file}', '{tag}')";
                    addTag.ExecuteNonQuery();

                }

            }
            else
            {
                MessageBox.Show("Failed to add new tag");
                return;
            }
        }

        public static Int64 CreateTag(string tagName, string description = "")
        {
            MessageBox.Show("creating new tag");
            Int64 newId = -1;
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadWriteCreate"))
            {
                var newTag = connection.CreateCommand();
                newTag.CommandText = $"" +
                    $"INSERT INTO TAGS" +
                    $"(tagName, description)" +
                    $"VALUES ('{tagName}', '{description}');" +
                    $"SELECT last_insert_rowid() LIMIT 1";

                MessageBox.Show(newTag.CommandText);
                connection.Open();
                
                newId = (Int64)newTag.ExecuteScalar();
            }

            return newId;
        }

        public class Tag
        {
            public string name
            { get; set; }
            public string description
            { get; set; }
            public long count
            { get; set; }

            public Tag(string name, string description = "", long count = 0)
            {
                this.name = name;
                this.description = description;
                this.count = count;
            }
        }


    }

}