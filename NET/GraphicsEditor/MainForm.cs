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
    public partial class MainForm : Form
    {
        public float startAngle=0;
        public float sweepAngle=1;
        ChangeColor cc = null;
        private Color kol;
        MainForm mf = null;
        String t;
        bool fill = false;
        Point prev = Point.Empty;
        Point curr = Point.Empty;
        float tickn;
        public float tickne
        {
            get
            {
                return tickn;
            }
            set
            {
                tickn = value;
                thickness_label.Text = "Grubosc: " + tickne;
            }
        }
        Bitmap bm = null;
        int zoom = 1;
        public  Color kolor {
            get
            {
                return kol;
            }
            set
            {
                kol = value;
                kolor_label.Text = "Color: "+kolor.ToString();
            }
        }

        public String tool
        {
            get
            {
                return t;
            }
            set
            {
                t = value;
                narzedzie_label.Text = "Tool: " + tool;
            }
        }
        List<Point> pointList = new List<Point>();

        public MainForm()
        {
            InitializeComponent();
            mf = this;
            wspolrzedne_label.Text = "Position: -, -";
            kolor= Color.FromArgb(255, 0, 0, 0);
            tool = "none";
            tickne = 1;
            bm= new Bitmap(1024, 768);
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                    bm.SetPixel(i, j, Color.FromArgb(255,255,255,255));
            }
            pictureBox.Image = bm;
            
        }
        private void showImage(string path)
        {
            pictureBox.Image = Image.FromFile(path);
            zoom = 1;
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult.No== MessageBox.Show("Czy chcesz zamknąć? Zapisz wszystkie potrzebne zmiany! ", "Uwaga",MessageBoxButtons.YesNo))
                e.Cancel = true;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            imagepanel.Width = this.Width - 91;
            imagepanel.Height = this.Height - 92;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.JPEG; *.PNG)|*.bmp;*.jpg;*.gif;*.jpeg;*.png";
            ofd.Multiselect = false;
            ofd.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
            if (ofd.ShowDialog() == DialogResult.OK)
                showImage(ofd.FileName);
        }
        public void drawPie()
        {
            if(!fill)
            {
                Graphics g = Graphics.FromImage(pictureBox.Image);
                g.DrawPie(new Pen(kolor), pointList[0].X, pointList[0].Y, Math.Abs(pointList[1].X - pointList[0].X), Math.Abs(pointList[1].X - pointList[0].X),
                    startAngle, sweepAngle);
                pictureBox.Refresh();
                pointList.Clear();
            }
            else
            {
                Graphics g = Graphics.FromImage(pictureBox.Image);
                g.FillPie(new SolidBrush(kolor), pointList[0].X, pointList[0].Y, Math.Abs(pointList[1].X - pointList[0].X), Math.Abs(pointList[1].X - pointList[0].X),
                    startAngle, sweepAngle);
                pictureBox.Refresh();
                pointList.Clear();
            }
        }
        private void czyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bm = new Bitmap(1024, 768);
            for (int i = 0; i < bm.Width; i++)
            {
                for (int j = 0; j < bm.Height; j++)
                    bm.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
            }
            pictureBox.Image = bm;
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
        private void kolor_button_Click(object sender, EventArgs e)
        {
            cc = new ChangeColor();
            cc.Show();
            if ((cc = (ChangeColor)checkifwinopen(typeof(ChangeColor))) == null)
                (cc = new ChangeColor()).Show();
            else
                cc.Focus();
        }

        private void zoomIn_button_Click(object sender, EventArgs e)
        {
            if (zoom < 6)
            {
                zoom++;
                pictureBox.Size = new Size((int)(pictureBox.Width * 1.1),(int)( pictureBox.Height * 1.1));
                bm = new Bitmap(pictureBox.Image, (int)(pictureBox.Image.Width * 1.1), (int)(pictureBox.Image.Height * 1.1));
                Graphics g = Graphics.FromImage(bm);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                pictureBox.Image = bm;
            }
        }

        private void zoomOut_button_Click(object sender, EventArgs e)
        {
            if (zoom > 1)
            {
                zoom--;
                pictureBox.Size = new Size((int)(pictureBox.Width * 0.9), (int)(pictureBox.Height * 0.9));
                bm = new Bitmap(pictureBox.Image, (int)(pictureBox.Image.Width * 0.9), (int)(pictureBox.Image.Height * 0.9));
                Graphics g = Graphics.FromImage(bm);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                pictureBox.Image = bm;
            }
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "jpg";
            sfd.Filter = "JPG images (*.jpg)|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

        }

        private void morewidth_button_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap temp = (Bitmap)pictureBox.Image;
                bm = new Bitmap(pictureBox.Image.Width + 10, pictureBox.Image.Height);

                for (int i = 0; i < temp.Width; i++)
                {
                    for (int j = 0; j < temp.Height; j++)
                        bm.SetPixel(i, j, temp.GetPixel(i, j));
                }

                for (int i = temp.Width; i < bm.Width; i++)
                {
                    for (int j = 0; j < bm.Height; j++)
                    {
                        bm.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                    }
                }
                pictureBox.Image = bm;
            }
            
        }

        private void lesswidth_button_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap temp = (Bitmap)pictureBox.Image;
                bm = new Bitmap(pictureBox.Image.Width - 10, pictureBox.Image.Height);

                for (int i = 0; i < bm.Width; i++)
                {
                    for (int j = 0; j < temp.Height; j++)
                        bm.SetPixel(i, j, temp.GetPixel(i, j));
                }
                pictureBox.Image = bm;
            }
        }

        private void moreheight_button_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap temp = (Bitmap)pictureBox.Image;
                bm = new Bitmap(pictureBox.Image.Width, pictureBox.Image.Height + 10);

                for (int i = 0; i < temp.Width; i++)
                {
                    for (int j = 0; j < temp.Height; j++)
                        bm.SetPixel(i, j, temp.GetPixel(i, j));
                }

                for (int i = 0; i < bm.Width; i++)
                {
                    for (int j = temp.Height; j < bm.Height; j++)
                    {
                        bm.SetPixel(i, j, Color.FromArgb(255, 255, 255, 255));
                    }
                }
                pictureBox.Image = bm;
            }
        }

        private void lessheight_button_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap temp = (Bitmap)pictureBox.Image;
                bm = new Bitmap(pictureBox.Image.Width, pictureBox.Image.Height - 10);

                for (int i = 0; i < temp.Width; i++)
                {
                    for (int j = 0; j < bm.Height; j++)
                        bm.SetPixel(i, j, temp.GetPixel(i, j));
                }
                pictureBox.Image = bm;
            }
        }

        private void punkt_button_Click(object sender, EventArgs e)
        {
            tool = "punkt";
            prev = Point.Empty;
            curr = Point.Empty;
        }

        private void kolo_button_Click(object sender, EventArgs e)
        {
            tool = "kolo";
            prev = Point.Empty;
            curr = Point.Empty;
        }

        private void kwadrat_button_Click(object sender, EventArgs e)
        {
            tool = "kwadrat";
            prev = Point.Empty;
            curr = Point.Empty;
        }

        private void elipsa_button_Click(object sender, EventArgs e)
        {
            tool = "elipsa";
            prev = Point.Empty;
            curr = Point.Empty;
        }

        private void luk_button_Click(object sender, EventArgs e)
        {
            tool = "luk";
            prev = Point.Empty;
            curr = Point.Empty;
            pointList.Clear();
        }

        private void wycinek_button_Click(object sender, EventArgs e)
        {
            tool = "wycinek kola";
            prev = Point.Empty;
            curr = Point.Empty;
            pointList.Clear();
        }

        private void wielokat_button_Click(object sender, EventArgs e)
        {
            tool = "wielokat";
            prev = Point.Empty;
            curr = Point.Empty;
        }

        private void bezier_button_Click(object sender, EventArgs e)
        {
            tool = "bezier";
            prev = Point.Empty;
            curr = Point.Empty;
            pointList.Clear();
        }

        private void gumka_button_Click(object sender, EventArgs e)
        {
            tool = "gumka";
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

        private void fill_button_Click(object sender, EventArgs e)
        {
            if(!fill)
            {
                fill = !fill;
                fill_button.Text = "No Fill";
            }
            else
            {
                fill = !fill;
                fill_button.Text = "Fill";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tickne =(float) numericUpDown1.Value;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (tool)
            {
                case "punkt":
                    {
                        Graphics g = Graphics.FromImage(pictureBox.Image);
                        g.DrawEllipse(new Pen(kolor, tickne), e.X - (tickne / 2), e.Y - (tickne / 2), tickne, tickne);
                        pictureBox.Refresh();
                        prev = e.Location;
                        break;
                    }
                case "kolo":
                    {
                        prev = e.Location;
                        break;
                    }
                case "kwadrat":
                    {
                        prev = e.Location;
                        break;
                    }
                case "elipsa":
                    {
                        prev = e.Location;
                        break;
                    }
                case "luk":
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            pointList.Add(e.Location);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.DrawCurve(new Pen(kolor, tickne), pointList.ToArray());
                            pictureBox.Refresh();
                            pointList.Clear();
                        }
                        break;
                    }
                case "wycinek kola":
                    {
                        pointList.Add(e.Location);
                        break;
                    }
                case "wielokat":
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            pointList.Add(e.Location);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            if(fill)
                            {
                                g.FillPolygon(new SolidBrush(kolor), pointList.ToArray());
                            }
                            else
                            {
                                g.DrawPolygon(new Pen(kolor, tickne), pointList.ToArray());
                            }
                            
                            pictureBox.Refresh();
                            pointList.Clear();
                        }

                        break;
                    }
                case "bezier":
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            pointList.Add(e.Location);
                            if(pointList.Count==4)
                            {
                                Graphics g = Graphics.FromImage(pictureBox.Image);
                                g.DrawBezier(new Pen(kolor, tickne), pointList[0], pointList[1], pointList[2], pointList[3]);
                                pointList.Clear();
                            }
                        }
                            pictureBox.Refresh();
                        
                        break;
                    }
                case "gumka":
                    {
                        Graphics g = Graphics.FromImage(pictureBox.Image);
                        g.FillRectangle(new SolidBrush(Color.White), e.X - (tickne / 2), e.Y - (tickne / 2), tickne, tickne);
                        pictureBox.Refresh();
                        break;
                    }

            }
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            wspolrzedne_label.Text = "Position: " + e.Location.ToString();
            
            switch (tool)
            {
                case "punkt":
                    {
                        if (e.Button == MouseButtons.Left && tool == "punkt")
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.DrawLine(new Pen(kolor, tickne), prev.X, prev.Y, e.X, e.Y);
                            prev = e.Location;
                            pictureBox.Refresh();
                        }
                        break;
                    }
                case "kolo":
                    {
                       


                        break;
                    }
                case "kwadrat":
                    {



                        break;
                    }
                case "elipsa":
                    {




                        break;
                    }
                case "luk":
                    {




                        break;
                    }
                case "wycinek":
                    {


                        break;
                    }
                case "wielokat":
                    {


                        break;
                    }
                case "bezier":
                    {



                        break;
                    }
                case "gumka":
                    {
                        break;
                    }

            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (tool)
            {
                
                case "kolo":
                    {
                        if (!fill&&e.Button==MouseButtons.Left)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.DrawEllipse(new Pen(kolor,tickne),prev.X,prev.Y,(e.Y-prev.Y+e.X-prev.X)/2, (e.Y - prev.Y + e.X - prev.X) / 2);
                            pictureBox.Refresh();
                        }
                        else if(MouseButtons.Left==e.Button)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.FillEllipse(new SolidBrush(kolor), prev.X, prev.Y, (e.Y - prev.Y + e.X - prev.X) / 2, (e.Y - prev.Y + e.X - prev.X) / 2);
                            pictureBox.Refresh();
                        }
                        break;
                    }
                case "kwadrat":
                    {
                        if (!fill && e.Button == MouseButtons.Left)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.DrawRectangle(new Pen(kolor, tickne), prev.X, prev.Y, (e.Y - prev.Y + e.X - prev.X) / 2, (e.Y - prev.Y + e.X - prev.X) / 2);
                            pictureBox.Refresh();
                        }
                        else if (MouseButtons.Left == e.Button)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.FillRectangle(new SolidBrush(kolor), prev.X, prev.Y, (e.Y - prev.Y + e.X - prev.X) / 2, (e.Y - prev.Y + e.X - prev.X) / 2);
                            pictureBox.Refresh();
                        }
                        break;
                    }
                case "elipsa":
                    {
                        if (!fill && e.Button == MouseButtons.Left)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.DrawEllipse(new Pen(kolor, tickne), prev.X, prev.Y, e.X - prev.X, e.Y - prev.Y);
                            pictureBox.Refresh();
                        }
                        else if (MouseButtons.Left == e.Button)
                        {
                            Graphics g = Graphics.FromImage(pictureBox.Image);
                            g.FillEllipse(new SolidBrush(kolor), prev.X, prev.Y,e.X-prev.X,e.Y-prev.Y);
                            pictureBox.Refresh();
                        }
                        break;
                    }
                
                case "wycinek kola":
                    {
                        pointList.Add(e.Location);
                            new PieProperty().Show();
                        break;
                        
                    }
                case "wielokat":
                    {
                        break;
                    }
                case "bezier":
                    {



                        break;
                    }
                case "gumka":
                    {
                        break;
                    }

            }
        }
    }
}
