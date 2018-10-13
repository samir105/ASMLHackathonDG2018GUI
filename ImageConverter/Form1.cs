using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        string API_DOMAIN = "http://10.14.0.205/";

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
                int side = panel1.Width / 2;
                if (panel1.Height < side)
                    side = panel1.Height;
                int left = (panel1.Width / 2 - side) / 2;
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
                Rectangle rect = new Rectangle(left + panel1.Width / 2, top, side, side);
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
                File.WriteAllText(Path.Combine(txtPath, fileName) + " " + barCount + ".txt", text);
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

        private async void btSend_Click(object sender, EventArgs e)
        {
            string queryFormat = "SHAPES/?A1={0}&A2={1}&A3={2}&A4={3}&B1={4}&B2={5}&B3={6}&B4={7}";
            byte[,] pixelsA = ImageTools.LoadBitmap(bitmapA);
            byte[,] pixelsB = ImageTools.LoadBitmap(bitmapB);

            byte[,] scaledPixelsA1 = ImageTools.ResizeImageCentered(pixelsA, 8 * 1, 8 * 4);
            string textA1 = ImageTools.ConvertToText(scaledPixelsA1).Replace("\r\n", "");

            byte[,] scaledPixelsA2 = ImageTools.ResizeImageCentered(pixelsA, 8 * 2, 8 * 4);
            string textA2 = ImageTools.ConvertToText(scaledPixelsA1).Replace("\r\n", "");

            byte[,] scaledPixelsA3 = ImageTools.ResizeImageCentered(pixelsA, 8 * 3, 8 * 4);
            string textA3 = ImageTools.ConvertToText(scaledPixelsA1).Replace("\r\n", "");

            byte[,] scaledPixelsA4 = ImageTools.ResizeImageCentered(pixelsA, 8 * 4, 8 * 4);
            string textA4 = ImageTools.ConvertToText(scaledPixelsA1).Replace("\r\n", "");

            byte[,] scaledPixelsB1 = ImageTools.ResizeImageCentered(pixelsB, 8 * 1, 8 * 4);
            string textB1 = ImageTools.ConvertToText(scaledPixelsB1).Replace("\r\n", "");

            byte[,] scaledPixelsB2 = ImageTools.ResizeImageCentered(pixelsB, 8 * 2, 8 * 4);
            string textB2 = ImageTools.ConvertToText(scaledPixelsB1).Replace("\r\n", "");

            byte[,] scaledPixelsB3 = ImageTools.ResizeImageCentered(pixelsB, 8 * 3, 8 * 4);
            string textB3 = ImageTools.ConvertToText(scaledPixelsB1).Replace("\r\n", "");

            byte[,] scaledPixelsB4 = ImageTools.ResizeImageCentered(pixelsB, 8 * 4, 8 * 4);
            string textB4 = ImageTools.ConvertToText(scaledPixelsB1).Replace("\r\n", "");

            string queryStr = String.Format(queryFormat,
                textA1, textA2, textA3, textA4,
                textB1, textB2, textB3, textB4);

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(API_DOMAIN + queryStr))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();

                if (result != null && result.Length >= 0)
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("Error! Empty result");
                }
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string queryStr = "/ACTIVE_NODE_COUNT";

                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(API_DOMAIN + queryStr))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();

                    if (result != null && result.Length >= 0)
                    {
                        laActiveNodeCount.Text = "Active node count: " + result;
                    }
                    else
                    {
                        //MessageBox.Show("Error! Empty result");
                    }
                }
            }
            catch (Exception exp)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1_Tick(sender, null);
        }
    }
}
