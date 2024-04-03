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
            saveOutputToolStripMenuItem = new ToolStripMenuItem();
            readRSAFileToolStripMenuItem = new ToolStripMenuItem();
            keyGroupBox = new GroupBox();
            RSAInpuGroupBox = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            label4 = new Label();
            YNumberInput = new TextBox();
            XNumberInput = new TextBox();
            button3 = new Button();
            menuStrip1.SuspendLayout();
            keyGroupBox.SuspendLayout();
            RSAInpuGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // Input
            // 
            Input.Location = new Point(22, 58);
            Input.Multiline = true;
            Input.Name = "Input";
            Input.Size = new Size(360, 263);
            Input.TabIndex = 0;
            // 
            // Output
            // 
            Output.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Output.Location = new Point(428, 58);
            Output.Multiline = true;
            Output.Name = "Output";
            Output.Size = new Size(360, 263);
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
            comboBox1.Location = new Point(222, 327);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(194, 23);
            comboBox1.TabIndex = 4;
            // 
            // Key
            // 
            Key.Location = new Point(6, 18);
            Key.Name = "Key";
            Key.Size = new Size(161, 23);
            Key.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
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
            comboBox2.Items.AddRange(new object[] { "Vigenere", "DES", "RSA" });
            comboBox2.Location = new Point(22, 327);
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
            menuStrip1.Size = new Size(911, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { selectFileToolStripMenuItem, saveOutputToolStripMenuItem, readRSAFileToolStripMenuItem });
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(37, 20);
            fileToolStripMenuItem1.Text = "File";
            // 
            // selectFileToolStripMenuItem
            // 
            selectFileToolStripMenuItem.Name = "selectFileToolStripMenuItem";
            selectFileToolStripMenuItem.Size = new Size(180, 22);
            selectFileToolStripMenuItem.Text = "Select File";
            selectFileToolStripMenuItem.Click += selectFileToolStripMenuItem_Click;
            // 
            // saveOutputToolStripMenuItem
            // 
            saveOutputToolStripMenuItem.Name = "saveOutputToolStripMenuItem";
            saveOutputToolStripMenuItem.Size = new Size(180, 22);
            saveOutputToolStripMenuItem.Text = "Save Output to File";
            saveOutputToolStripMenuItem.Click += saveOutputToolStripMenuItem_Click;
            // 
            // readRSAFileToolStripMenuItem
            // 
            readRSAFileToolStripMenuItem.Name = "readRSAFileToolStripMenuItem";
            readRSAFileToolStripMenuItem.Size = new Size(180, 22);
            readRSAFileToolStripMenuItem.Text = "Read RSA File";
            readRSAFileToolStripMenuItem.Click += readRSAFileToolStripMenuItem_Click;
            // 
            // keyGroupBox
            // 
            keyGroupBox.Controls.Add(Key);
            keyGroupBox.Controls.Add(label1);
            keyGroupBox.Location = new Point(22, 356);
            keyGroupBox.Name = "keyGroupBox";
            keyGroupBox.Size = new Size(173, 47);
            keyGroupBox.TabIndex = 12;
            keyGroupBox.TabStop = false;
            // 
            // RSAInpuGroupBox
            // 
            RSAInpuGroupBox.BackColor = SystemColors.Control;
            RSAInpuGroupBox.Controls.Add(button3);
            RSAInpuGroupBox.Controls.Add(button2);
            RSAInpuGroupBox.Controls.Add(button1);
            RSAInpuGroupBox.Controls.Add(label5);
            RSAInpuGroupBox.Controls.Add(label4);
            RSAInpuGroupBox.Controls.Add(YNumberInput);
            RSAInpuGroupBox.Controls.Add(XNumberInput);
            RSAInpuGroupBox.Location = new Point(22, 356);
            RSAInpuGroupBox.Name = "RSAInpuGroupBox";
            RSAInpuGroupBox.Size = new Size(823, 60);
            RSAInpuGroupBox.TabIndex = 13;
            RSAInpuGroupBox.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(572, 30);
            button2.Name = "button2";
            button2.Size = new Size(110, 23);
            button2.TabIndex = 5;
            button2.Text = "AttemptCracking";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(417, 31);
            button1.Name = "button1";
            button1.Size = new Size(142, 23);
            button1.TabIndex = 4;
            button1.Text = "GeneratePrime";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(235, 11);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 3;
            label5.Text = "Y";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 11);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 2;
            label4.Text = "X";
            // 
            // YNumberInput
            // 
            YNumberInput.Location = new Point(235, 31);
            YNumberInput.Name = "YNumberInput";
            YNumberInput.Size = new Size(176, 23);
            YNumberInput.TabIndex = 1;
            // 
            // XNumberInput
            // 
            XNumberInput.Location = new Point(19, 31);
            XNumberInput.Name = "XNumberInput";
            XNumberInput.Size = new Size(194, 23);
            XNumberInput.TabIndex = 0;
            // 
            // button3
            // 
            button3.Location = new Point(691, 30);
            button3.Name = "button3";
            button3.Size = new Size(93, 23);
            button3.TabIndex = 6;
            button3.Text = "CalcPrivate";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(911, 450);
            Controls.Add(RSAInpuGroupBox);
            Controls.Add(keyGroupBox);
            Controls.Add(menuStrip1);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(DecryptButton);
            Controls.Add(EncryptButton);
            Controls.Add(Output);
            Controls.Add(Input);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            keyGroupBox.ResumeLayout(false);
            keyGroupBox.PerformLayout();
            RSAInpuGroupBox.ResumeLayout(false);
            RSAInpuGroupBox.PerformLayout();
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
        private ToolStripMenuItem saveOutputToolStripMenuItem;
        private GroupBox keyGroupBox;
        private GroupBox RSAInpuGroupBox;
        private Label label5;
        private Label label4;
        private TextBox YNumberInput;
        private TextBox XNumberInput;
        private Button button1;
        private Button button2;
        private ToolStripMenuItem readRSAFileToolStripMenuItem;
        private Button button3;
    }
}