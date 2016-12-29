namespace RS232
{
    partial class Konfiguracja
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.speedBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.controlBox = new System.Windows.Forms.ComboBox();
            this.stopBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flowBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.termBox = new System.Windows.Forms.ComboBox();
            this.termText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // portBox
            // 
            this.portBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portBox.FormattingEnabled = true;
            this.portBox.Location = new System.Drawing.Point(15, 25);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(121, 21);
            this.portBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Szybkość:";
            // 
            // speedBox
            // 
            this.speedBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speedBox.FormattingEnabled = true;
            this.speedBox.Location = new System.Drawing.Point(152, 25);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(121, 21);
            this.speedBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rozmiar pola danych:";
            // 
            // dataBox
            // 
            this.dataBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataBox.FormattingEnabled = true;
            this.dataBox.Location = new System.Drawing.Point(15, 65);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(121, 21);
            this.dataBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kontrola parzystości:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bity stopu:";
            // 
            // controlBox
            // 
            this.controlBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.controlBox.FormattingEnabled = true;
            this.controlBox.Location = new System.Drawing.Point(152, 64);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(121, 21);
            this.controlBox.TabIndex = 9;
            // 
            // stopBox
            // 
            this.stopBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopBox.FormattingEnabled = true;
            this.stopBox.Location = new System.Drawing.Point(15, 110);
            this.stopBox.Name = "stopBox";
            this.stopBox.Size = new System.Drawing.Size(121, 21);
            this.stopBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Kontrola Przepływu:";
            // 
            // flowBox
            // 
            this.flowBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flowBox.FormattingEnabled = true;
            this.flowBox.Location = new System.Drawing.Point(152, 110);
            this.flowBox.Name = "flowBox";
            this.flowBox.Size = new System.Drawing.Size(121, 21);
            this.flowBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Terminator:";
            // 
            // termBox
            // 
            this.termBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termBox.FormattingEnabled = true;
            this.termBox.Location = new System.Drawing.Point(15, 150);
            this.termBox.Name = "termBox";
            this.termBox.Size = new System.Drawing.Size(121, 21);
            this.termBox.TabIndex = 14;
            this.termBox.SelectedValueChanged += new System.EventHandler(this.termBox_SelectedValueChanged);
            // 
            // termText
            // 
            this.termText.Enabled = false;
            this.termText.Location = new System.Drawing.Point(153, 151);
            this.termText.MaxLength = 2;
            this.termText.Name = "termText";
            this.termText.Size = new System.Drawing.Size(120, 20);
            this.termText.TabIndex = 15;
            // 
            // Konfiguracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 223);
            this.Controls.Add(this.termText);
            this.Controls.Add(this.termBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.flowBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopBox);
            this.Controls.Add(this.controlBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Konfiguracja";
            this.Text = "Konfiguracja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox portBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox speedBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dataBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox controlBox;
        private System.Windows.Forms.ComboBox stopBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox flowBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox termBox;
        private System.Windows.Forms.TextBox termText;
    }
}