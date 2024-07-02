using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tagger
{
    public partial class Remove_Tag : Form
    {
        string FileId = "";
        public Remove_Tag(string file, string fileId)
        {
            InitializeComponent();
            label1.Text = file;
            this.FileId = fileId;
        }

        private void Remove_Tag_Load(object sender, EventArgs e)
        {
            var fileName = label1.Text;
            var tags = Tag_Handler.GetAllTagsOnFile(this.FileId);

            RefreshTagList(tags);

        }

        private void RefreshTagList(List<Tag_Handler.Tag> tags)
        {
            tagList.Items.Clear();
            foreach (var tag in tags)
            {
                tagList.Items.Add($"{tag.name} ({tag.count})");
            }
        }

        private void tagList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            List<Int32> tags = new List<Int32>();
            foreach (var item in tagList.CheckedItems)
            {
                tags.Add(Tag_Handler.GetTagIdByName(item.ToString().Split(" ")[0]));
            }
            Tag_Handler.RemoveTagByFileName(label1.Text, tags);

            RefreshTagList(Tag_Handler.GetAllTagsOnFile(this.FileId));
        }
    }
}
