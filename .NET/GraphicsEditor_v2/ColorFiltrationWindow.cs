using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge;
using FIP;


namespace GraphicsEditorByGawek
{
    public partial class ColorFiltrationWindow : Form
    {
        MainForm mf = null;
        public ColorFiltrationWindow()
        {
            InitializeComponent();
            mf = (MainForm)checkifwinopen(typeof(MainForm));

            ImageStatistics stat = new ImageStatistics((Bitmap)mf.pictureBox.Image);
            AForge.Math.Histogram histogram = stat.Red;
            redmax.Value = histogram.Max;
            redmin.Value = histogram.Min;
            histogram = stat.Green;
            greenmax.Value = histogram.Max;
            greenmin.Value = histogram.Min;
            histogram = stat.Blue;
            bluemax.Value = histogram.Max;
            bluemin.Value = histogram.Min;
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

        private void button1_Click(object sender, EventArgs e)
        {
            mf.pictureBox.Image = rdraw();


        }
        private Bitmap rdraw()
        {
            Bitmap result=(Bitmap)mf.pictureBox.Image;
           
            
            ColorFiltering cf = new ColorFiltering();
            
            cf.Red = new IntRange(redmin.Value, redmax.Value);
            cf.Green = new IntRange(greenmin.Value, greenmax.Value);
            cf.Blue = new IntRange(bluemin.Value, bluemax.Value);
            cf.ApplyInPlace(result);

            return result;
        }
    }
}
