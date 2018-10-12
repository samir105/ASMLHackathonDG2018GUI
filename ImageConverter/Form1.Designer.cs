namespace ImageConverter
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btLoad = new System.Windows.Forms.Button();
            this.btBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(12, 51);
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
            this.tbPath.Size = new System.Drawing.Size(621, 26);
            this.tbPath.TabIndex = 1;
            this.tbPath.Text = "C:\\Users\\Hackaton\\Desktop\\test.bmp";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 379);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btLoad
            // 
            this.btLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoad.Location = new System.Drawing.Point(682, 12);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 36);
            this.btLoad.TabIndex = 7;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.Location = new System.Drawing.Point(639, 12);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(37, 36);
            this.btBrowse.TabIndex = 8;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 484);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.btLoad);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btConvert);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Converter";
            this.ResizeBegin += new System.EventHandler(this.Form1_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

