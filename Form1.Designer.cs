
namespace Projekt
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btMenu1 = new System.Windows.Forms.Button();
            this.btMenu2 = new System.Windows.Forms.Button();
            this.btMenu3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btMenu1
            // 
            this.btMenu1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btMenu1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btMenu1.Location = new System.Drawing.Point(1780, 484);
            this.btMenu1.Name = "btMenu1";
            this.btMenu1.Size = new System.Drawing.Size(120, 50);
            this.btMenu1.TabIndex = 0;
            this.btMenu1.Text = "Menu1";
            this.btMenu1.UseVisualStyleBackColor = false;
            this.btMenu1.Click += new System.EventHandler(this.btMenu1_Click);
            // 
            // btMenu2
            // 
            this.btMenu2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btMenu2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btMenu2.Location = new System.Drawing.Point(1780, 540);
            this.btMenu2.Name = "btMenu2";
            this.btMenu2.Size = new System.Drawing.Size(120, 50);
            this.btMenu2.TabIndex = 1;
            this.btMenu2.Text = "Menu2";
            this.btMenu2.UseVisualStyleBackColor = false;
            this.btMenu2.Click += new System.EventHandler(this.btMenu2_Click);
            // 
            // btMenu3
            // 
            this.btMenu3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btMenu3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btMenu3.Location = new System.Drawing.Point(1780, 596);
            this.btMenu3.Name = "btMenu3";
            this.btMenu3.Size = new System.Drawing.Size(120, 50);
            this.btMenu3.TabIndex = 2;
            this.btMenu3.Text = "Menu3";
            this.btMenu3.UseVisualStyleBackColor = false;
            this.btMenu3.Click += new System.EventHandler(this.btMenu3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(960, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu 1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(480, 270);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 550);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(525, 305);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 46);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btMenu3);
            this.Controls.Add(this.btMenu2);
            this.Controls.Add(this.btMenu1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTisch1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btMenu1;
        private System.Windows.Forms.Button btMenu2;
        private System.Windows.Forms.Button btMenu3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
    }
}

