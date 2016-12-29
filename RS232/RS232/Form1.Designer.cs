namespace RS232
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.konfiguracjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.odbior = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nadawanie = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.wyslijHex = new System.Windows.Forms.Button();
            this.hexBox2 = new Be.Windows.Forms.HexBox();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.label3 = new System.Windows.Forms.Label();
            this.prompt = new System.Windows.Forms.RichTextBox();
            this.mODBUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konfiguracjaToolStripMenuItem,
            this.pingToolStripMenuItem,
            this.mODBUSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // konfiguracjaToolStripMenuItem
            // 
            this.konfiguracjaToolStripMenuItem.Name = "konfiguracjaToolStripMenuItem";
            this.konfiguracjaToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.konfiguracjaToolStripMenuItem.Text = "Konfiguracja";
            this.konfiguracjaToolStripMenuItem.Click += new System.EventHandler(this.konfiguracjaToolStripMenuItem_Click);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.Enabled = false;
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.pingToolStripMenuItem.Text = "Ping";
            this.pingToolStripMenuItem.Click += new System.EventHandler(this.pingToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 453);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.odbior);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nadawanie);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tryb Tekstowy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(516, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Wyślij";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Odbiór:";
            // 
            // odbior
            // 
            this.odbior.Location = new System.Drawing.Point(6, 227);
            this.odbior.Name = "odbior";
            this.odbior.ReadOnly = true;
            this.odbior.Size = new System.Drawing.Size(585, 183);
            this.odbior.TabIndex = 2;
            this.odbior.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nadawanie:";
            // 
            // nadawanie
            // 
            this.nadawanie.Location = new System.Drawing.Point(6, 32);
            this.nadawanie.Name = "nadawanie";
            this.nadawanie.Size = new System.Drawing.Size(585, 148);
            this.nadawanie.TabIndex = 0;
            this.nadawanie.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.wyslijHex);
            this.tabPage2.Controls.Add(this.hexBox2);
            this.tabPage2.Controls.Add(this.hexBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(597, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tryb Heksadecymalny";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nadawanie:";
            // 
            // wyslijHex
            // 
            this.wyslijHex.Location = new System.Drawing.Point(499, 228);
            this.wyslijHex.Name = "wyslijHex";
            this.wyslijHex.Size = new System.Drawing.Size(75, 23);
            this.wyslijHex.TabIndex = 2;
            this.wyslijHex.Text = "Wyślij";
            this.wyslijHex.UseVisualStyleBackColor = true;
            this.wyslijHex.Click += new System.EventHandler(this.wyslijHex_Click);
            // 
            // hexBox2
            // 
            this.hexBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox2.Location = new System.Drawing.Point(14, 257);
            this.hexBox2.Name = "hexBox2";
            this.hexBox2.ReadOnly = true;
            this.hexBox2.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox2.Size = new System.Drawing.Size(560, 155);
            this.hexBox2.TabIndex = 1;
            // 
            // hexBox1
            // 
            this.hexBox1.Enabled = false;
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox1.Location = new System.Drawing.Point(14, 43);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(560, 178);
            this.hexBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prompt:";
            // 
            // prompt
            // 
            this.prompt.Location = new System.Drawing.Point(16, 499);
            this.prompt.Name = "prompt";
            this.prompt.ReadOnly = true;
            this.prompt.Size = new System.Drawing.Size(585, 91);
            this.prompt.TabIndex = 5;
            this.prompt.Text = "";
            // 
            // mODBUSToolStripMenuItem
            // 
            this.mODBUSToolStripMenuItem.Enabled = false;
            this.mODBUSToolStripMenuItem.Name = "mODBUSToolStripMenuItem";
            this.mODBUSToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.mODBUSToolStripMenuItem.Text = "MODBUS";
            this.mODBUSToolStripMenuItem.Click += new System.EventHandler(this.mODBUSToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 598);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RS232";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem konfiguracjaToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox odbior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox nadawanie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox prompt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private Be.Windows.Forms.HexBox hexBox1;
        private Be.Windows.Forms.HexBox hexBox2;
        private System.Windows.Forms.Button wyslijHex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem mODBUSToolStripMenuItem;
    }
}

