namespace Tagger
{
    partial class Remove_Tag
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
            label1 = new Label();
            tagList = new CheckedListBox();
            removeButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // tagList
            // 
            tagList.CheckOnClick = true;
            tagList.FormattingEnabled = true;
            tagList.Location = new Point(12, 41);
            tagList.Name = "tagList";
            tagList.Size = new Size(225, 310);
            tagList.TabIndex = 1;
            tagList.SelectedIndexChanged += tagList_SelectedIndexChanged;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(12, 357);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(75, 23);
            removeButton.TabIndex = 2;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // Remove_Tag
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 390);
            Controls.Add(removeButton);
            Controls.Add(tagList);
            Controls.Add(label1);
            Name = "Remove_Tag";
            Text = "Remove_Tag";
            Load += Remove_Tag_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckedListBox tagList;
        private Button removeButton;
    }
}