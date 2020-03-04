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
    public partial class ChangeColor : Form
    {
        Bitmap bm = null;
        MainForm mf=null;
        Graphics g = null;

        public ChangeColor()
        {
            InitializeComponent();
            bm = new Bitmap(35,35);
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == typeof(MainForm))
                {
                    mf = (MainForm)OpenForm;
                    break;
                }
            }
            redTrack.Value = mf.kolor.R;
            greenTrack.Value = mf.kolor.G;
            blueTrack.Value = mf.kolor.B;
            trackBar1.Value = mf.kolor.A;
            RefreshBitmap();
        }
        private void RefreshBitmap()
        {
            for(int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                    bm.SetPixel(i, j, mf.kolor);
            }
            pictureBox1.Image = bm;
            pictureBox1.Refresh();


        }
        private void redTrack_ValueChanged(object sender, EventArgs e)
        {
            mf.kolor = Color.FromArgb(mf.kolor.A, redTrack.Value, mf.kolor.G, mf.kolor.B);
            RefreshBitmap();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            mf.kolor = Color.FromArgb(trackBar1.Value, mf.kolor.R, mf.kolor.G, mf.kolor.B);
            RefreshBitmap();
        }

        private void greenTrack_ValueChanged(object sender, EventArgs e)
        {
            mf.kolor = Color.FromArgb(mf.kolor.A, mf.kolor.R, greenTrack.Value, mf.kolor.B);
            RefreshBitmap();
        }

        private void blueTrack_ValueChanged(object sender, EventArgs e)
        {
            mf.kolor = Color.FromArgb(mf.kolor.A, mf.kolor.R, mf.kolor.G, blueTrack.Value);
            RefreshBitmap();
        }
    }
}
