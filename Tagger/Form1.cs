using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace Tagger
{

    public partial class Form1 : Form
    {
        const Boolean Debug = true;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDatabases();
        }

        private void InitializeDatabases()
        {
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadWriteCreate"))
            {
                var createTables = connection.CreateCommand();
                connection.Open();
                createTables.CommandText = "CREATE TABLE IF NOT EXISTS FILES(name TEXT,location TEXT," +
                    "type TEXT, size INTEGER, sources TEXT);" +
                    "CREATE TABLE IF NOT EXISTS FILETAGS(fileID INTEGER, tagID);" +
                    "CREATE TABLE IF NOT EXISTS TAGS(name TEXT, description TEXT, count INTEGER)";
                createTables.ExecuteNonQuery();
            }
        }

        private Boolean CheckIfFileInDB(string location)
        {
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var findFile = connection.CreateCommand();
                findFile.CommandText = $"" +
                    $"SELECT COUNT(*) from FILES WHERE `location` IS '{location}'";
                connection.Open();
                long count = (long)findFile.ExecuteScalar();

                return count > 0;
            }
        }

        private void AddFileToDB(string name, string location, string type, long size)
        {
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadWrite"))
            {
                var addFile = connection.CreateCommand();
                addFile.CommandText = $"" +
                    $"INSERT INTO FILES (name, location, type, size, sources)" +
                    $"VALUES ('{name}','{location}','{type}','{size}','')";
                connection.Open();
                addFile.ExecuteNonQuery();
                toolStripStatusLabel1.Text = $"Added {name}";
            }
        }

        private string ReadableFileSize(long size)
        {
            const long KB = 1024;
            const long MB = 1048576;
            const long GB = 1073741824;
            switch (size)
            {
                case >= GB:
                    return String.Format("{0:.##}", ((size * 1.0) / GB)) + " GB";
                case >= MB:
                    return String.Format("{0:.##}", ((size * 1.0) / MB)) + " MB";
                case >= KB:
                    return String.Format("{0:.##}", ((size * 1.0) / KB)) + " KB";
            }

            return "";
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileSelect.ShowDialog();
            string[] files = fileSelect.FileNames;
            if (files != null)
            {
                foreach (string file in files)
                {
                    //check if already in database and skip if true
                    string location = System.IO.Path.GetFullPath(file);
                    string fileName = System.IO.Path.GetFileName(file);
                    if (!CheckIfFileInDB(location) || Debug)
                    {
                        string fileType = System.IO.Path.GetExtension(file);
                        long fileSize = new System.IO.FileInfo(location).Length;
                        string tags = null ?? ""; //add functionality to pull existing tags from database
                        string[] items = [fileName, "", location, fileType, ReadableFileSize(fileSize).ToString()];
                        var newFile = new ListViewItem(items);
                        AddFileToDB(fileName, location, fileType, fileSize);
                        fileView.Items.Add(newFile);
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = $"{fileName} not added. It is already in the DB";
                    }
                }
            }

        }

        private List<SearchElement> parseSearch(string searchString, Boolean mode = false) //false means OR
        {
            const char tagSearch = '#';
            const char nameSearch = '$';
            const char typeSearch = '%';
            const char sourceSearch = '!';
            List<SearchElement> searchElements = new List<SearchElement>();

            var doubleQuote = searchString.IndexOf("\"");
            if (doubleQuote != -1)
            {
                var endQuote = searchString.IndexOf("\"", doubleQuote + 1);
                if (endQuote != -1)
                {
                    var andSearch = searchString.Substring(doubleQuote, endQuote);
                    searchString.Remove(doubleQuote, endQuote);
                    searchElements.Concat(parseSearch(andSearch));
                }
            }

            var splitted = searchString.Split(" ");
            foreach (var item in splitted)
            {
                if (item.IndexOf(tagSearch) != -1)
                {
                    searchElements.Add(new SearchElement("tag", mode, item.Substring(1)));
                }
                else if (item.IndexOf(nameSearch) != -1)
                {
                    searchElements.Add(new SearchElement("name", mode, item.Substring(1)));
                }
                else if (item.IndexOf(typeSearch) != -1)
                {
                    searchElements.Add(new SearchElement("type", mode, item.Substring(1)));
                }
                else if (item.IndexOf(sourceSearch) != -1)
                {
                    searchElements.Add(new SearchElement("source", mode, item.Substring(1)));
                }
            }

            return searchElements;
        }

        public void performSearch(List<SearchElement> toSearch)
        {

        }

        private void fileSelect_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void fileView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var searchStr = Search.Text;
            var toSearch = parseSearch(searchStr);
            if (toSearch != null && toSearch.Count > 0)
            {
                performSearch(toSearch);
            }
            else
            {
                toolStripStatusLabel1.Text = "Failed to search.  No valid search string provided";
            }
        }
    }

    public class SearchElement
    {
        string type;
        Boolean mode; //false means OR
        string value;

        public SearchElement(string type, bool mode, string value)
        {
            this.type = type;
            this.mode = mode;
            this.value = value;
        }
    }
}
