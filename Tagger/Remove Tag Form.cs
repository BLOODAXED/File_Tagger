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
        public Remove_Tag(string file)
        {
            InitializeComponent();
            label1.Text = file;
        }

        private void Remove_Tag_Load(object sender, EventArgs e)
        {
            var fileName = label1.Text;
            var tags = Tag_Handler.GetAllTagsOnFile(fileName);
            foreach(var tag in tags)
            {
                tagList.Items.Add($"{tag.name} ({tag.count})");
            }

        }

        private void tagList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
