
namespace Projekt
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.btMenu3 = new System.Windows.Forms.Button();
            this.btMenu2 = new System.Windows.Forms.Button();
            this.btMenu1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(960, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu 3";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btMenu3
            // 
            this.btMenu3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btMenu3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btMenu3.Location = new System.Drawing.Point(1780, 596);
            this.btMenu3.Name = "btMenu3";
            this.btMenu3.Size = new System.Drawing.Size(120, 50);
            this.btMenu3.TabIndex = 5;
            this.btMenu3.Text = "Menu3";
            this.btMenu3.UseVisualStyleBackColor = false;
            this.btMenu3.Click += new System.EventHandler(this.btMenu3_Click);
            // 
            // btMenu2
            // 
            this.btMenu2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btMenu2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btMenu2.Location = new System.Drawing.Point(1780, 540);
            this.btMenu2.Name = "btMenu2";
            this.btMenu2.Size = new System.Drawing.Size(120, 50);
            this.btMenu2.TabIndex = 4;
            this.btMenu2.Text = "Menu2";
            this.btMenu2.UseVisualStyleBackColor = false;
            this.btMenu2.Click += new System.EventHandler(this.btMenu2_Click);
            // 
            // btMenu1
            // 
            this.btMenu1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btMenu1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btMenu1.Location = new System.Drawing.Point(1780, 484);
            this.btMenu1.Name = "btMenu1";
            this.btMenu1.Size = new System.Drawing.Size(120, 50);
            this.btMenu1.TabIndex = 3;
            this.btMenu1.Text = "Menu1";
            this.btMenu1.UseVisualStyleBackColor = false;
            this.btMenu1.Click += new System.EventHandler(this.btMenu1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(480, 270);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 550);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btMenu3);
            this.Controls.Add(this.btMenu2);
            this.Controls.Add(this.btMenu1);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btMenu3;
        private System.Windows.Forms.Button btMenu2;
        private System.Windows.Forms.Button btMenu1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}