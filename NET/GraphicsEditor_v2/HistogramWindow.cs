using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorByGawek
{
    public partial class HistogramWindow : Form
    {
        MainForm mf = null;
        public HistogramWindow()
        {
            InitializeComponent();
            mf = (MainForm)checkifwinopen(typeof(MainForm));
            
            ShowHisto((Bitmap)mf.pictureBox.Image);
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
        private void ShowHisto(Bitmap Img)
        {
            int[] ara = new int[256];
            int opt = -1;
            if (rbRed.Checked)
                opt = 0;
            if (rbGreen.Checked)
                opt = 1;
            if (rbBlue.Checked)
                opt = 2;
            for (int I = 0; I <= Img.Width - 1; I++)
            {
                for (int j = 0; j <= Img.Height - 1; j++)
                {
                    Color c = Img.GetPixel(I, j);
                    int p = 0;
                    switch (opt)
                    {
                        case 0:
                            {
                                p = c.R;
                                break;
                            }

                        case 1:
                            {
                                p = c.G;
                                break;
                            }

                        case 2:
                            {
                                p = c.B;
                                break;
                            }
                    }
                    ara[p] += 1;
                }
            }
            chart1.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series();

            for (int I = 0; I <= 255; I++)
                chart1.Series[0].Points.AddY(ara[I]);
        }

        private void rbRed_CheckedChanged(object sender, EventArgs e)
        {
            ShowHisto((Bitmap)mf.pictureBox.Image);
        }

        private void rbGreen_CheckedChanged(object sender, EventArgs e)
        {
            rbRed_CheckedChanged(sender, e);
        }
    }
}
