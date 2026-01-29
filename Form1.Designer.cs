
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
            this.label3 = new System.Windows.Forms.Label();
            this.Menu1 = new System.Windows.Forms.Button();
            this.Menu2 = new System.Windows.Forms.Button();
            this.Menu3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(960, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Menu 2";
            // 
            // Menu1
            // 
            this.Menu1.Location = new System.Drawing.Point(1780, 484);
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(120, 50);
            this.Menu1.TabIndex = 3;
            this.Menu1.Text = "button1";
            this.Menu1.UseVisualStyleBackColor = true;
            this.Menu1.Click += new System.EventHandler(this.Menu1_Click);
            // 
            // Menu2
            // 
            this.Menu2.Location = new System.Drawing.Point(1780, 540);
            this.Menu2.Name = "Menu2";
            this.Menu2.Size = new System.Drawing.Size(120, 50);
            this.Menu2.TabIndex = 4;
            this.Menu2.Text = "button2";
            this.Menu2.UseVisualStyleBackColor = true;
            this.Menu2.Click += new System.EventHandler(this.Menu2_Click_1);
            // 
            // Menu3
            // 
            this.Menu3.Location = new System.Drawing.Point(1780, 596);
            this.Menu3.Name = "Menu3";
            this.Menu3.Size = new System.Drawing.Size(120, 50);
            this.Menu3.TabIndex = 5;
            this.Menu3.Text = "button4";
            this.Menu3.UseVisualStyleBackColor = true;
            this.Menu3.Click += new System.EventHandler(this.Menu3_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.Location = new System.Drawing.Point(480, 270);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1000, 550);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(511, 291);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 50);
            this.button4.TabIndex = 7;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Menu3);
            this.Controls.Add(this.Menu2);
            this.Controls.Add(this.Menu1);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button btMenu1;
        private System.Windows.Forms.Button btMenu2;
        private System.Windows.Forms.Button btMenu3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Menu1;
        private System.Windows.Forms.Button Menu2;
        private System.Windows.Forms.Button Menu3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
    }
}

