using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorByGawek
{
    public partial class AdjustWindow : Form
    {
        MainForm mf = null;
        float gam = 1;

        public AdjustWindow()
        {
            InitializeComponent();
            mf = (MainForm)checkifwinopen(typeof(MainForm));
            gam = 1;
        }

        private Form checkifwinopen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }
            return null;
        }

        private  Bitmap AdjustContrast(Bitmap Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }

        private Bitmap AdjustBrightness(Bitmap Image, int Value)
        {
            Bitmap TempBitmap = Image;
            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);
            Graphics NewGraphics = Graphics.FromImage(NewBitmap);
            float FinalValue = (float)Value / 255.0f;
            float[][] FloatColorMatrix ={
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                };
            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);
            ImageAttributes Attributes = new ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();
            return NewBitmap;
        }

        private Bitmap AdjustGamma(Image image, float gamma)
        {
            // Set the ImageAttributes object's gamma value.
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetGamma(gamma);

            // Draw the image onto the new bitmap
            // while applying the new gamma value.
            Point[] points =
            {
        new Point(0, 0),
        new Point(image.Width, 0),
        new Point(0, image.Height),
    };
            Rectangle rect =
                new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mf.pictureBox.Image = AdjustContrast((Bitmap)mf.pictureBox.Image, 5);
            mf.pictureBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mf.pictureBox.Image = AdjustContrast((Bitmap)mf.pictureBox.Image, -5);
            mf.pictureBox.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mf.pictureBox.Image = AdjustBrightness((Bitmap)mf.pictureBox.Image, -20);
            mf.pictureBox.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mf.pictureBox.Image = AdjustBrightness((Bitmap)mf.pictureBox.Image, 20);
            mf.pictureBox.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (gam != 6.5f)
                gam += 0.25f;
            mf.pictureBox.Image = AdjustGamma((Bitmap)mf.pictureBox.Image, 1.25f);
            mf.pictureBox.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (gam != 0.25f)
                gam -= 0.25f;
            mf.pictureBox.Image = AdjustGamma((Bitmap)mf.pictureBox.Image, 0.75f);
            mf.pictureBox.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mf.pictureBox.Image = HistogramShift((Bitmap)mf.pictureBox.Image, 20);
            mf.pictureBox.Refresh();
        }
        public Bitmap HistogramShift(Bitmap OriginalImage, int offset)
        {
            Bitmap image = OriginalImage;

            if (offset < 1 || offset > 254)
            {
                throw new Exception("Offset value must be in range from 1 to 254");
            }

            for (int m = 0; m < image.Width; m++)
            {
                for (int n = 0; n < image.Height; n++)
                {
                    Color pixel = image.GetPixel(m, n);
                    int gs = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));

                    int newgs = (int)(gs + offset);
                    if (newgs > 255)
                        newgs = 255;
                    image.SetPixel(m, n, Color.FromArgb(255, newgs, newgs, newgs));

                }
            }

            return image;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mf.pictureBox.Image = mf.fip.Rotate((Bitmap)mf.pictureBox.Image, (double)angleField.Value);
        }
    }
    
}
