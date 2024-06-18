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
    }

    public class Tag
    {
        public string name
        { get; set; }
        public string description
        { get; set; }
        public long count
        { get; set; }

        public Tag(string name, string description, long count=0)
        {
            this.name = name;
            this.description = description;
            this.count = count;
        }
    }


}
