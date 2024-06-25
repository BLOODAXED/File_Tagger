using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tagger
{
    public partial class AddTag : Form
    {
        
        public AddTag(string file)
        {
            InitializeComponent();
            label1.Text = file;
        }

        private void add_Click(object sender, EventArgs e)
        {
            var toAdd = tagInput.Text;
            Tag_Handler.AddTagToFile(label1.Text, toAdd);
            
        }

        private void tagInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
