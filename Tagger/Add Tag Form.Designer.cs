namespace Tagger
{
    partial class AddTag
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
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            label1 = new Label();
            tagInput = new TextBox();
            add = new Button();
            SuspendLayout();
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // tagInput
            // 
            tagInput.Location = new Point(28, 27);
            tagInput.Name = "tagInput";
            tagInput.Size = new Size(210, 23);
            tagInput.TabIndex = 1;
            tagInput.TextChanged += tagInput_TextChanged;
            // 
            // add
            // 
            add.Location = new Point(91, 59);
            add.Name = "add";
            add.Size = new Size(75, 23);
            add.TabIndex = 2;
            add.Text = "Add";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // AddTag
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 94);
            Controls.Add(add);
            Controls.Add(tagInput);
            Controls.Add(label1);
            Name = "AddTag";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private Label label1;
        private TextBox tagInput;
        private Button add;
    }
}