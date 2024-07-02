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
            components = new System.ComponentModel.Container();
            Search = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            addFilesToolStripMenuItem = new ToolStripMenuItem();
            addTagToolStripMenuItem = new ToolStripMenuItem();
            removeTagToolStripMenuItem = new ToolStripMenuItem();
            detailedViewToolStripMenuItem = new ToolStripMenuItem();
            openInExplorerToolStripMenuItem = new ToolStripMenuItem();
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
            fileType = new ColumnHeader();
            fileSize = new ColumnHeader();
            rightClickMenu = new ContextMenuStrip(components);
            addTagToolStripMenuItem1 = new ToolStripMenuItem();
            removeTagToolStripMenuItem1 = new ToolStripMenuItem();
            detailsToolStripMenuItem = new ToolStripMenuItem();
            openInExplorerToolStripMenuItem1 = new ToolStripMenuItem();
            fileSelect = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            taggerStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            rightClickMenu.SuspendLayout();
            SuspendLayout();
            // 
            // Search
            // 
            Search.Location = new Point(12, 36);
            Search.Name = "Search";
            Search.PlaceholderText = "hi";
            Search.Size = new Size(472, 23);
            Search.TabIndex = 1;
            Search.KeyPress += Search_KeyPress;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, addTagToolStripMenuItem, removeTagToolStripMenuItem, detailedViewToolStripMenuItem, openInExplorerToolStripMenuItem });
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
            // addTagToolStripMenuItem
            // 
            addTagToolStripMenuItem.Name = "addTagToolStripMenuItem";
            addTagToolStripMenuItem.Size = new Size(62, 20);
            addTagToolStripMenuItem.Text = "Add Tag";
            // 
            // removeTagToolStripMenuItem
            // 
            removeTagToolStripMenuItem.Name = "removeTagToolStripMenuItem";
            removeTagToolStripMenuItem.Size = new Size(83, 20);
            removeTagToolStripMenuItem.Text = "Remove Tag";
            // 
            // detailedViewToolStripMenuItem
            // 
            detailedViewToolStripMenuItem.Name = "detailedViewToolStripMenuItem";
            detailedViewToolStripMenuItem.Size = new Size(90, 20);
            detailedViewToolStripMenuItem.Text = "Detailed View";
            // 
            // openInExplorerToolStripMenuItem
            // 
            openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            openInExplorerToolStripMenuItem.Size = new Size(107, 20);
            openInExplorerToolStripMenuItem.Text = "Open In Explorer";
            openInExplorerToolStripMenuItem.Click += openInExplorerToolStripMenuItem_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(490, 35);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 3;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
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
            fileView.ContextMenuStrip = rightClickMenu;
            fileView.Location = new Point(12, 64);
            fileView.Name = "fileView";
            fileView.Size = new Size(553, 361);
            fileView.TabIndex = 6;
            fileView.UseCompatibleStateImageBehavior = false;
            fileView.View = View.Details;
            fileView.SelectedIndexChanged += fileView_SelectedIndexChanged;
            fileView.DoubleClick += fileView_DoubleClick;
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
            // fileType
            // 
            fileType.Text = "type";
            // 
            // fileSize
            // 
            fileSize.Text = "size";
            // 
            // rightClickMenu
            // 
            rightClickMenu.Items.AddRange(new ToolStripItem[] { addTagToolStripMenuItem1, removeTagToolStripMenuItem1, detailsToolStripMenuItem, openInExplorerToolStripMenuItem1 });
            rightClickMenu.Name = "contextMenuStrip1";
            rightClickMenu.Size = new Size(181, 114);
            rightClickMenu.Opening += contextMenuStrip1_Opening;
            // 
            // addTagToolStripMenuItem1
            // 
            addTagToolStripMenuItem1.Name = "addTagToolStripMenuItem1";
            addTagToolStripMenuItem1.Size = new Size(180, 22);
            addTagToolStripMenuItem1.Text = "Add Tag";
            addTagToolStripMenuItem1.Click += addTagToolStripMenuItem1_Click;
            // 
            // removeTagToolStripMenuItem1
            // 
            removeTagToolStripMenuItem1.Name = "removeTagToolStripMenuItem1";
            removeTagToolStripMenuItem1.Size = new Size(180, 22);
            removeTagToolStripMenuItem1.Text = "Remove Tag";
            removeTagToolStripMenuItem1.Click += removeTagToolStripMenuItem1_Click;
            // 
            // detailsToolStripMenuItem
            // 
            detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            detailsToolStripMenuItem.Size = new Size(180, 22);
            detailsToolStripMenuItem.Text = "Details";
            detailsToolStripMenuItem.Click += detailsToolStripMenuItem_Click;
            // 
            // openInExplorerToolStripMenuItem1
            // 
            openInExplorerToolStripMenuItem1.Name = "openInExplorerToolStripMenuItem1";
            openInExplorerToolStripMenuItem1.Size = new Size(180, 22);
            openInExplorerToolStripMenuItem1.Text = "Open In Explorer";
            openInExplorerToolStripMenuItem1.Click += openInExplorerToolStripMenuItem1_Click_1;
            // 
            // fileSelect
            // 
            fileSelect.FileName = "Select File(s)";
            fileSelect.Multiselect = true;
            fileSelect.FileOk += fileSelect_FileOk;
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
            rightClickMenu.ResumeLayout(false);
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
        private ToolStripMenuItem addTagToolStripMenuItem;
        private ToolStripMenuItem removeTagToolStripMenuItem;
        private ToolStripMenuItem detailedViewToolStripMenuItem;
        private ToolStripMenuItem openInExplorerToolStripMenuItem;
        private ContextMenuStrip rightClickMenu;
        private ToolStripMenuItem addTagToolStripMenuItem1;
        private ToolStripMenuItem removeTagToolStripMenuItem1;
        private ToolStripMenuItem detailsToolStripMenuItem;
        private ToolStripMenuItem openInExplorerToolStripMenuItem1;
    }
}
