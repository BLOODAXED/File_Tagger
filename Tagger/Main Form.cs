using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

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
                createTables.CommandText = "CREATE TABLE IF NOT EXISTS FILES(id INTEGER, name TEXT,location TEXT," +
                    "type TEXT, size INTEGER, sources TEXT, PRIMARY KEY(id));" +
                    "CREATE TABLE IF NOT EXISTS FILETAGS(fileID INTEGER, tagID);" +
                    "CREATE TABLE IF NOT EXISTS TAGS(id INTEGER, tasgName TEXT, description TEXT, count INTEGER, PRIMARY KEY(id))";
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

        private List<SearchElement> parseSearch(string searchString)
        {
            const char tagSearch = '#';
            const char nameSearch = '$';
            const char typeSearch = '%';
            const char sourceSearch = '!';
            List<SearchElement> searchElements = new List<SearchElement>();

            var doubleQuote = searchString.IndexOf("\"");
            while (doubleQuote != -1)
            {
                var endQuote = searchString.IndexOf("\"", doubleQuote + 1);
                if (endQuote != -1)
                {
                    var orSearch = searchString.Substring(doubleQuote, endQuote);
                    var operand = searchString[doubleQuote - 1];
                    switch (operand)
                    {
                        case tagSearch:
                            searchElements.Add(new SearchElement("tagName", false, orSearch.Substring(1)));
                            break;
                        case nameSearch:
                            searchElements.Add(new SearchElement("name", false, orSearch.Substring(1)));
                            break;
                        case typeSearch:
                            searchElements.Add(new SearchElement("type", false, orSearch.Substring(1)));
                            break;
                        case sourceSearch:
                            searchElements.Add(new SearchElement("source", false, orSearch.Substring(1)));
                            break;
                        default:
                            searchElements.Add(new SearchElement("name", false, orSearch.Substring(0)));
                            break;
                    }

                    searchString.Remove(doubleQuote, endQuote);
                }
                else
                {
                    toolStripStatusLabel1.Text = "Failed to Parse String.  Missing close quote";
                    return null;
                }
                doubleQuote = searchString.IndexOf("\"");
            }

            var splitted = searchString.Split(" ");
            foreach (var item in splitted)
            {
                if (item.IndexOf(tagSearch) != -1)
                {
                    searchElements.Add(new SearchElement("tagName", true, item.Substring(1)));
                }
                else if (item.IndexOf(nameSearch) != -1)
                {
                    searchElements.Add(new SearchElement("name", true, item.Substring(1)));
                }
                else if (item.IndexOf(typeSearch) != -1)
                {
                    searchElements.Add(new SearchElement("type", true, item.Substring(1)));
                }
                else if (item.IndexOf(sourceSearch) != -1)
                {
                    searchElements.Add(new SearchElement("source", true, item.Substring(1)));
                }
                else
                {
                    searchElements.Add(new SearchElement("name", true, item.Substring(0)));
                }
            }

            return searchElements;
        }

        public void performSearch(List<SearchElement> toSearch)
        {
            string searchParams = "";
            foreach (var item in toSearch)
            {
                if (item.mode == false)
                {
                    if (item.type == "tag")
                    {
                        if (searchParams[^5..] != "WHERE")
                        {
                            searchParams += $@"WHERE {item.type} IS '{item.value}'";
                        }
                        else
                        {
                            searchParams += $@"OR WHERE {item.type} IS '{item.value}'";
                        }
                    }
                    else
                    {
                        if (searchParams[^5..] != "WHERE")
                        {
                            searchParams += $@"WHERE {item.type} LIKE '%{item.value}%'";
                        }
                        else
                        {
                            searchParams += $@"OR WHERE {item.type} LIKE '%{item.value}%'";
                        }
                    }
                }
                else
                {
                    if (item.type == "tag")
                    {
                        if (searchParams.Length < 5 || searchParams[^5..] != "WHERE")
                        {
                            searchParams += $@"WHERE {item.type} IS '{item.value}'";
                        }
                        else
                        {
                            searchParams += $@"AND WHERE {item.type} IS '{item.value}'";
                        }
                    }
                    else
                    {
                        if (searchParams.Length < 5 || searchParams[^5..] != "WHERE")
                        {
                            searchParams += $@"WHERE {item.type} LIKE '%{item.value}%'";
                        }
                        else
                        {
                            searchParams += $@"AND WHERE {item.type} LIKE '%{item.value}%'";
                        }
                    }
                }
            }
            using (var connection = new SqliteConnection("Data Source=tagger.sqlite;Mode=ReadOnly"))
            {
                var findFile = connection.CreateCommand();
                findFile.CommandText = $"" +
                    $"SELECT name, GROUP_CONCAT(tagName), location, type, size " +
                    $"from FILES LEFT JOIN FILETAGS on FILES.id = FILETAGS.fileID " +
                    $"LEFT JOIN TAGS on FILETAGS.tagID = TAGS.id" +
                    $" " + searchParams +
                    $"GROUP BY FILES.id";

                connection.Open();

                List<string[]> items = new List<string[]>();
                using (var reader = findFile.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add([Functions.SafeGetString(reader, 0), Functions.SafeGetString(reader, 1),
                            Functions.SafeGetString(reader, 2), Functions.SafeGetString(reader, 3), Functions.SafeGetString(reader, 4)]);
                        updateFileListView(items);
                    }
                }
            }
        }

        public void updateFileListView(List<string[]> items)
        {
            fileView.Items.Clear();
            foreach (string[] item in items)
            {
                fileView.Items.Add(new ListViewItem(item));
            }
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

        private void Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchButton_Click((object)sender, e);
            }
        }

        private void fileView_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show($"clicked " + fileView.SelectedItems[0].Text);
        }

        /*private void fileView_MouseDown(object sender, EventArgs e)
        {
            switch (e.)
            {
                case MouseButtons.Right:
                    {
                        rightClickMenu.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position
                    }
                    break;
            }
        }*/

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void addTagToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddTag form = new AddTag(fileView.SelectedItems[0].Text);
            form.ShowDialog();
        }

        private void removeTagToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Remove_Tag form = new Remove_Tag(fileView.SelectedItems[0].Text);
            form.ShowDialog();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openInExplorerToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        public void addTagToItem()
        {

        }

    }

    public class SearchElement
    {
        public string type
        { get; set; }
        public Boolean mode //false means OR
        { get; set; }
        public string value
        { get; set; }

        public SearchElement(string type, bool mode, string value)
        {
            this.type = type;
            this.mode = mode;
            this.value = value;
        }
    }
}
