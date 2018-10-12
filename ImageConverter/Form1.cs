using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        string path;
        Bitmap bitmapA;
        Bitmap bitmapB;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, 0, 0, panel1.Width, panel1.Height);
            if (bitmapA != null)
            {
                int side = panel1.Width/2;
                if (panel1.Height < side)
                    side = panel1.Height;
                int left = (panel1.Width/2 - side) / 2;
                int top = (panel1.Height - side) / 2;
                Rectangle rect = new Rectangle(left, top, side, side);
                e.Graphics.DrawImage(bitmapA, rect);
            }
            if (bitmapB != null)
            {
                int side = panel1.Width / 2;
                if (panel1.Height < side)
                    side = panel1.Height;
                int left = (panel1.Width / 2 - side) / 2;
                int top = (panel1.Height - side) / 2;
                Rectangle rect = new Rectangle(left+panel1.Width/2, top, side, side);
                e.Graphics.DrawImage(bitmapB, rect);
            }
        }

        private void LoadImageIntoBitmap(ref Bitmap bitmap, string fileName)
        {
            path = tbPath.Text.Trim();
            bitmap = new Bitmap(path);
            panel1.Invalidate();

            byte[,] origPixels = ImageTools.LoadBitmap(bitmap);
            string txtPath = Path.GetDirectoryName(path);
            for (int barCount = 1; barCount <= 4; barCount++)
            {
                int newWidth = 8 * barCount;
                int newHeight = 8 * 4;
                byte[,] scaledPixels = ImageTools.ResizeImageCentered(origPixels, newWidth, newHeight);
                string text = ImageTools.ConvertToText(scaledPixels);
                File.WriteAllText(Path.Combine(txtPath,fileName)+" "+barCount+".txt", text);
            }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files|*.bmp;*.jpg;*.jped;*.png;*.gif";
            openFileDialog1.Title = "Select an image file";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbPath.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            //panel1.Invalidate();
        }

        private void btLoadA_Click(object sender, EventArgs e)
        {
            LoadImageIntoBitmap(ref bitmapA, "A");
        }

        private void btLoadB_Click(object sender, EventArgs e)
        {
            LoadImageIntoBitmap(ref bitmapB, "B");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}
