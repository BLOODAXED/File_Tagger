namespace Tagger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Search = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            addFilesToolStripMenuItem = new ToolStripMenuItem();
            searchButton = new Button();
            taggerStrip = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            previewBox = new PictureBox();
            fileView = new ListView();
            filename = new ColumnHeader();
            tags = new ColumnHeader();
            location = new ColumnHeader();
            fileSelect = new OpenFileDialog();
            fileType = new ColumnHeader();
            fileSize = new ColumnHeader();
            menuStrip1.SuspendLayout();
            taggerStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            SuspendLayout();
            // 
            // Search
            // 
            Search.Location = new Point(12, 35);
            Search.Name = "Search";
            Search.PlaceholderText = "hi";
            Search.Size = new Size(472, 23);
            Search.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(915, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addFilesToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // addFilesToolStripMenuItem
            // 
            addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            addFilesToolStripMenuItem.Size = new Size(122, 22);
            addFilesToolStripMenuItem.Text = "Add Files";
            addFilesToolStripMenuItem.Click += addFilesToolStripMenuItem_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(490, 35);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 3;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // taggerStrip
            // 
            taggerStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripProgressBar1 });
            taggerStrip.Location = new Point(0, 428);
            taggerStrip.Name = "taggerStrip";
            taggerStrip.Size = new Size(915, 22);
            taggerStrip.TabIndex = 4;
            taggerStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(68, 17);
            toolStripStatusLabel1.Text = "nothing yet";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Alignment = ToolStripItemAlignment.Right;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            toolStripProgressBar1.Click += toolStripProgressBar1_Click;
            // 
            // previewBox
            // 
            previewBox.Location = new Point(571, 64);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(344, 361);
            previewBox.TabIndex = 5;
            previewBox.TabStop = false;
            // 
            // fileView
            // 
            fileView.Columns.AddRange(new ColumnHeader[] { filename, tags, location, fileType, fileSize });
            fileView.Location = new Point(12, 64);
            fileView.Name = "fileView";
            fileView.Size = new Size(553, 361);
            fileView.TabIndex = 6;
            fileView.UseCompatibleStateImageBehavior = false;
            fileView.View = View.Details;
            fileView.SelectedIndexChanged += fileView_SelectedIndexChanged;
            // 
            // filename
            // 
            filename.Tag = "name";
            filename.Text = "Name";
            filename.Width = 120;
            // 
            // tags
            // 
            tags.Text = "tags";
            tags.Width = 120;
            // 
            // location
            // 
            location.Text = "location";
            location.Width = 120;
            // 
            // fileSelect
            // 
            fileSelect.FileName = "Select File(s)";
            fileSelect.Multiselect = true;
            fileSelect.FileOk += fileSelect_FileOk;
            // 
            // fileType
            // 
            fileType.Text = "type";
            // 
            // fileSize
            // 
            fileSize.Text = "size";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 450);
            Controls.Add(fileView);
            Controls.Add(previewBox);
            Controls.Add(taggerStrip);
            Controls.Add(searchButton);
            Controls.Add(Search);
            Controls.Add(menuStrip1);
            Name = "Form1";
            Text = "File Tagger";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            taggerStrip.ResumeLayout(false);
            taggerStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox Search;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Button searchButton;
        private StatusStrip taggerStrip;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox previewBox;
        private ListView fileView;
        private ToolStripMenuItem addFilesToolStripMenuItem;
        private OpenFileDialog fileSelect;
        private ColumnHeader filename;
        private ColumnHeader tags;
        private ColumnHeader location;
        private ColumnHeader fileType;
        private ColumnHeader fileSize;
    }
}
