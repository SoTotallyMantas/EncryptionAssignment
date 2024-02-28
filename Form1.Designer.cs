namespace EncryptionAssignment
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
            Input = new TextBox();
            Output = new TextBox();
            EncryptButton = new Button();
            DecryptButton = new Button();
            comboBox1 = new ComboBox();
            Key = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            selectFileToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Input
            // 
            Input.Location = new Point(22, 58);
            Input.Multiline = true;
            Input.Name = "Input";
            Input.Size = new Size(360, 276);
            Input.TabIndex = 0;
            // 
            // Output
            // 
            Output.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Output.Location = new Point(428, 58);
            Output.Multiline = true;
            Output.Name = "Output";
            Output.Size = new Size(360, 276);
            Output.TabIndex = 1;
            // 
            // EncryptButton
            // 
            EncryptButton.Location = new Point(27, 415);
            EncryptButton.Name = "EncryptButton";
            EncryptButton.Size = new Size(75, 23);
            EncryptButton.TabIndex = 2;
            EncryptButton.Text = "Encrypt";
            EncryptButton.UseVisualStyleBackColor = true;
            EncryptButton.Click += EncryptButton_Click;
            // 
            // DecryptButton
            // 
            DecryptButton.Location = new Point(108, 415);
            DecryptButton.Name = "DecryptButton";
            DecryptButton.Size = new Size(75, 23);
            DecryptButton.TabIndex = 3;
            DecryptButton.Text = "Decrypt";
            DecryptButton.UseVisualStyleBackColor = true;
            DecryptButton.Click += DecryptButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Raides ir skaiciai zodynas algoritmas", "ASCII Spausdinami simboliai algoritmas", "Raides ir skaiciai masyvas algoritmas" });
            comboBox1.Location = new Point(227, 340);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(194, 23);
            comboBox1.TabIndex = 4;
            // 
            // Key
            // 
            Key.Location = new Point(22, 386);
            Key.Name = "Key";
            Key.Size = new Size(161, 23);
            Key.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 366);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 6;
            label1.Text = "Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 40);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 7;
            label2.Text = "Input";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(428, 40);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 8;
            label3.Text = "Output";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Vigenere", "DES" });
            comboBox2.Location = new Point(27, 340);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(194, 23);
            comboBox2.TabIndex = 9;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { selectFileToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(37, 20);
            fileToolStripMenuItem1.Text = "File";
            // 
            // selectFileToolStripMenuItem
            // 
            selectFileToolStripMenuItem.Name = "selectFileToolStripMenuItem";
            selectFileToolStripMenuItem.Size = new Size(126, 22);
            selectFileToolStripMenuItem.Text = "Select File";
            selectFileToolStripMenuItem.Click += selectFileToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Key);
            Controls.Add(comboBox1);
            Controls.Add(DecryptButton);
            Controls.Add(EncryptButton);
            Controls.Add(Output);
            Controls.Add(Input);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Input;
        private TextBox Output;
        private Button EncryptButton;
        private Button DecryptButton;
        private ComboBox comboBox1;
        private TextBox Key;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem selectFileToolStripMenuItem;
    }
}