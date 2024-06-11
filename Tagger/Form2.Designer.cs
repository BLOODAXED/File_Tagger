namespace Tagger
{
    partial class FileDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fileNameView = new TextBox();
            fileSizeView = new TextBox();
            locationView = new TextBox();
            typeView = new TextBox();
            tagView = new ListView();
            previewBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            SuspendLayout();
            // 
            // fileNameView
            // 
            fileNameView.Location = new Point(12, 12);
            fileNameView.Name = "fileNameView";
            fileNameView.Size = new Size(165, 23);
            fileNameView.TabIndex = 0;
            // 
            // fileSizeView
            // 
            fileSizeView.Location = new Point(212, 12);
            fileSizeView.Name = "fileSizeView";
            fileSizeView.Size = new Size(151, 23);
            fileSizeView.TabIndex = 1;
            // 
            // locationView
            // 
            locationView.Location = new Point(12, 64);
            locationView.Name = "locationView";
            locationView.Size = new Size(165, 23);
            locationView.TabIndex = 2;
            // 
            // typeView
            // 
            typeView.Location = new Point(212, 64);
            typeView.Name = "typeView";
            typeView.Size = new Size(151, 23);
            typeView.TabIndex = 3;
            // 
            // tagView
            // 
            tagView.Location = new Point(12, 127);
            tagView.Name = "tagView";
            tagView.Size = new Size(351, 218);
            tagView.TabIndex = 4;
            tagView.UseCompatibleStateImageBehavior = false;
            // 
            // previewBox
            // 
            previewBox.Location = new Point(409, 12);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(341, 333);
            previewBox.TabIndex = 5;
            previewBox.TabStop = false;
            // 
            // FileDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 357);
            Controls.Add(previewBox);
            Controls.Add(tagView);
            Controls.Add(typeView);
            Controls.Add(locationView);
            Controls.Add(fileSizeView);
            Controls.Add(fileNameView);
            Name = "FileDetails";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox fileNameView;
        private TextBox fileSizeView;
        private TextBox locationView;
        private TextBox typeView;
        private ListView tagView;
        private PictureBox previewBox;
    }
}