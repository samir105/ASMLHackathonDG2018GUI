﻿namespace ImageConverter
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
            this.btConvert = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.rbBarCount4 = new System.Windows.Forms.RadioButton();
            this.rbBarCount3 = new System.Windows.Forms.RadioButton();
            this.rbBarCount2 = new System.Windows.Forms.RadioButton();
            this.rbBarCount1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(12, 104);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(106, 36);
            this.btConvert.TabIndex = 0;
            this.btConvert.Text = "Convert";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(12, 12);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(786, 26);
            this.tbPath.TabIndex = 1;
            this.tbPath.Text = "C:\\Users\\Hackaton\\Desktop\\test.bmp";
            // 
            // rbBarCount4
            // 
            this.rbBarCount4.AutoSize = true;
            this.rbBarCount4.Checked = true;
            this.rbBarCount4.Location = new System.Drawing.Point(12, 57);
            this.rbBarCount4.Name = "rbBarCount4";
            this.rbBarCount4.Size = new System.Drawing.Size(78, 24);
            this.rbBarCount4.TabIndex = 2;
            this.rbBarCount4.TabStop = true;
            this.rbBarCount4.Text = "4 bars";
            this.rbBarCount4.UseVisualStyleBackColor = true;
            this.rbBarCount4.Visible = false;
            // 
            // rbBarCount3
            // 
            this.rbBarCount3.AutoSize = true;
            this.rbBarCount3.Location = new System.Drawing.Point(132, 57);
            this.rbBarCount3.Name = "rbBarCount3";
            this.rbBarCount3.Size = new System.Drawing.Size(78, 24);
            this.rbBarCount3.TabIndex = 3;
            this.rbBarCount3.Text = "3 bars";
            this.rbBarCount3.UseVisualStyleBackColor = true;
            this.rbBarCount3.Visible = false;
            // 
            // rbBarCount2
            // 
            this.rbBarCount2.AutoSize = true;
            this.rbBarCount2.Location = new System.Drawing.Point(254, 57);
            this.rbBarCount2.Name = "rbBarCount2";
            this.rbBarCount2.Size = new System.Drawing.Size(78, 24);
            this.rbBarCount2.TabIndex = 4;
            this.rbBarCount2.Text = "2 bars";
            this.rbBarCount2.UseVisualStyleBackColor = true;
            this.rbBarCount2.Visible = false;
            // 
            // rbBarCount1
            // 
            this.rbBarCount1.AutoSize = true;
            this.rbBarCount1.Location = new System.Drawing.Point(371, 57);
            this.rbBarCount1.Name = "rbBarCount1";
            this.rbBarCount1.Size = new System.Drawing.Size(70, 24);
            this.rbBarCount1.TabIndex = 5;
            this.rbBarCount1.Text = "1 bar";
            this.rbBarCount1.UseVisualStyleBackColor = true;
            this.rbBarCount1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rbBarCount1);
            this.Controls.Add(this.rbBarCount2);
            this.Controls.Add(this.rbBarCount3);
            this.Controls.Add(this.rbBarCount4);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btConvert);
            this.Name = "Form1";
            this.Text = "Image Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.RadioButton rbBarCount4;
        private System.Windows.Forms.RadioButton rbBarCount3;
        private System.Windows.Forms.RadioButton rbBarCount2;
        private System.Windows.Forms.RadioButton rbBarCount1;
    }
}
