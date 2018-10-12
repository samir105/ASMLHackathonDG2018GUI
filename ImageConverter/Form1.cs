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
        Bitmap bitmap;//=new Bitmap(320, 320);

        public Form1()
        {
            InitializeComponent();
        }

        public static byte[,] LoadBitmap(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,] pixels = new byte[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    Color color = bitmap.GetPixel(j, i);
                    bool hasColor = (color.R <255 || color.G <255 || color.B <255);
                    pixels[i, j] = (hasColor ? (byte)1 : (byte)0);
                }
            return pixels;
        }

        public static byte[,] ResizeImage(byte[,] origPixels, int newWidth, int newHeight)
        {
            byte[,] newPixels = new byte[newHeight, newWidth];
            int widthScale = origPixels.GetLength(1) / newWidth;
            int heightScale = origPixels.GetLength(0) / newHeight;
            for(int i=0;i<newHeight;i++)
            {
                for(int j=0;j<newWidth;j++)
                {
                    int sum = 0;
                    for(int ii=i*heightScale;ii<(i+1)*heightScale;ii++)
                    {
                        for(int jj=j*widthScale;jj<(j+1)*widthScale;jj++)
                        {
                            sum += origPixels[ii, jj];
                        }
                    }
                    if (sum >= widthScale * heightScale)
                        newPixels[i, j] = 1;
                    else
                        newPixels[i, j] = 0;
                }
            }
            return newPixels;
        }

        private void btConvert_Click(object sender, EventArgs e)
        {
            byte[,] origPixels = LoadBitmap(bitmap);
            /*if (rbBarCount1.Checked)
                barCount = 1;
            else if (rbBarCount2.Checked)
                barCount = 2;
            else if (rbBarCount3.Checked)
                barCount = 3;
            else barCount = 4;*/
            string txtPath = Path.ChangeExtension(path, "txt");
            for (int barCount = 1; barCount <= 4; barCount++)
            {
                int newWidth = 8 * barCount;
                int newHeight = 8 * 4;
                byte[,] scaledPixels = ResizeImage(origPixels, newWidth, newHeight);
                string text = ConvertToText(scaledPixels);
                File.WriteAllText(txtPath.Replace(".txt", "_BarCount"+barCount+".txt"), text);
            }
        }

        private static string ConvertToText(byte[,] pixels)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    sb.Append(pixels[i, j].ToString());
                }
                sb.Append("\r\n");
            }

            return sb.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap!=null)
            //e.Graphics.DrawImage(bitmap, new Point(0, 0));
            e.Graphics.DrawImage(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            path = tbPath.Text.Trim();
            bitmap = new Bitmap(path);
            panel1.Invalidate();
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bitmap files|*.bmp";
            openFileDialog1.Title = "Select a bitmap image file";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbPath.Text = openFileDialog1.FileName;
            }
        }
    }
}
