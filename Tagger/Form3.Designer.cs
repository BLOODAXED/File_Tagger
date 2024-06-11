namespace Tagger
{
    partial class TagEditor
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
            tagSearch = new TextBox();
            tagDescription = new RichTextBox();
            currentTag = new TextBox();
            tagCount = new TextBox();
            saveTagChanges = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // tagSearch
            // 
            tagSearch.Location = new Point(12, 12);
            tagSearch.Name = "tagSearch";
            tagSearch.Size = new Size(205, 23);
            tagSearch.TabIndex = 0;
            // 
            // tagDescription
            // 
            tagDescription.Location = new Point(14, 80);
            tagDescription.Name = "tagDescription";
            tagDescription.Size = new Size(205, 104);
            tagDescription.TabIndex = 3;
            tagDescription.Text = "";
            // 
            // currentTag
            // 
            currentTag.Location = new Point(12, 51);
            currentTag.Name = "currentTag";
            currentTag.Size = new Size(145, 23);
            currentTag.TabIndex = 4;
            // 
            // tagCount
            // 
            tagCount.Location = new Point(163, 51);
            tagCount.Name = "tagCount";
            tagCount.Size = new Size(54, 23);
            tagCount.TabIndex = 5;
            // 
            // saveTagChanges
            // 
            saveTagChanges.Location = new Point(14, 190);
            saveTagChanges.Name = "saveTagChanges";
            saveTagChanges.Size = new Size(97, 23);
            saveTagChanges.TabIndex = 6;
            saveTagChanges.Text = "Save";
            saveTagChanges.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(115, 190);
            button1.Name = "button1";
            button1.Size = new Size(102, 23);
            button1.TabIndex = 7;
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = true;
            // 
            // TagEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 233);
            Controls.Add(button1);
            Controls.Add(saveTagChanges);
            Controls.Add(tagCount);
            Controls.Add(currentTag);
            Controls.Add(tagDescription);
            Controls.Add(tagSearch);
            Name = "TagEditor";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tagSearch;
        private RichTextBox tagDescription;
        private TextBox currentTag;
        private TextBox tagCount;
        private Button saveTagChanges;
        private Button button1;
    }
}