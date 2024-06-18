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

        public Tag GetTag(string searchTerm)
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


        public List<Tag> GetAllTags()
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

        public long CountTag(string searchTerm)
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

        public void AddTagToFile(string fileName, string tagName)
        {
            Int32 tag = -1;
            Int32 file = -1;
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadWriteCreate"))
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
                findTag.CommandText = $"" +
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
                        $"VALUES ('{file}, {tag}')";
                    addTag.ExecuteNonQuery();

                }

            }
        }

        public Int32 CreateTag(string tagName, string description = "")
        {
            Int32 newId = -1;
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadWriteCreate"))
            {
                var newTag = connection.CreateCommand();
                newTag.CommandText = $"" +
                    $"INSERT INTO TAGS" +
                    $"(tagName, description)" +
                    $"VALUES ({tagName}, {description});" +
                    $"SELECT last_insertrowid() LIMIT 1";

                connection.Open();

                using (var reader = newTag.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        newId = (Int32)reader.GetInt32(0);
                    }
                }
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

            public Tag(string name, string description, long count = 0)
            {
                this.name = name;
                this.description = description;
                this.count = count;
            }
        }


    }

}