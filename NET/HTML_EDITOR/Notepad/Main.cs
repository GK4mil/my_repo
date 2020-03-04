using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            OtworzPlik.FileName = "";
            OtworzPlik.Filter = "HTML|*.html";
            zapiszPlik.Filter = "HTML|*.html";
            tabControl1.Left = 13;
            tabControl1.Top = 53;
            tabControl1.Width = this.Width - 39;
            tabControl1.Height = this.Height - 100;
              

        }

        string savedText = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OtworzPlik.ShowDialog()==DialogResult.OK)
                openFile(OtworzPlik.FileName);
            
            
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
                
                    Close();
        }
        private void openFile(string file)
        {
            try
            {
                
                savedText=File.ReadAllText(file);   //odczyt pliku
                addTab(Path.GetFileName(file));     //dodanie taba
                     
        
               
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void addTab(string fileName)
        {
            TabPage t = new TabPage();          //nowy tabpage
            t.Text = fileName;
            tabControl1.Controls.Add(t);        //dodanie tabpage do tabcontrol
            

            WebBrowser wb = new WebBrowser();
            RichTextBox rt = new RichTextBox();
            rt.Width = tabControl1.Width / 2;
            rt.Height = tabControl1.Height;
            
            wb.Width = tabControl1.Width / 2-12;

            wb.Left = tabControl1.Width / 2+2;
            wb.Height = tabControl1.Height-2;



            
           
            rt.Text = savedText;
            wb.DocumentText = rt.Text;
            t.Controls.Add(rt);                       //dodanie webrowser do tabpage
            t.Controls.Add(wb);
            tabControl1.SelectTab(t);
            rt.TextChanged += new EventHandler(textChanged);
        }
        private void SaveFile()
        {
            TabPage activeTab = tabControl1.SelectedTab;  //aktywny tab
            RichTextBox activeRTB = null;               //aktywny richtextbox
            WebBrowser activeWb = null;

            if (activeTab != null)                        //czy istnieje tab
            { foreach (Control contr in activeTab.Controls)
                {
                    if (typeof(RichTextBox) == contr.GetType())
                        activeRTB = (contr as RichTextBox);
                    if(contr is WebBrowser)
                    {
                        activeWb = (contr as WebBrowser);
                    }
                }

                if (activeRTB != null && activeWb != null)      //jezeli kontrolka niepusta
                {
                    zapiszPlik.FileName = activeTab.Text;
                    if (zapiszPlik.ShowDialog() == DialogResult.OK)
                    {
                              //nazwa pliku
                                                                    //////////////////////////////////////////////////////////////////////////////


                        File.WriteAllText(zapiszPlik.FileName, activeRTB.Text); //zapis pliku
                        activeTab.Controls.Remove(activeRTB);                   //uswanie rtb
                        activeTab.Controls.Remove(activeWb);
                        tabControl1.TabPages.Remove(activeTab);

                        //usuwanie tabpage

                        activeTab = null;
                        activeRTB = null;
                        activeWb = null;



                        //////////////////////////////////////////////////////////////////////////////////
                    }
                }
            }
            else
                MessageBox.Show("Brak otwartych plików", "Błąd");

           
            
        }
        
        private void zapiszIZamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                if (MessageBox.Show("Czy chcesz zamknąć program?", "Zamykanie", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.SelectedTab;
            if (tabControl1.TabCount != 0)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is RichTextBox)
                    {
                        
                        string temp = string.Empty;
                        if ((c as RichTextBox).SelectionLength != 0)
                        {
                            temp = (c as RichTextBox).Text;
                            
                            temp = temp.Insert((c as RichTextBox).SelectionStart, "<b>");
                            temp = temp.Insert((c as RichTextBox).SelectionStart + 3+(c as RichTextBox).SelectionLength, "</b>");

                            (c as RichTextBox).Text = temp;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.SelectedTab;
            if (tabControl1.TabCount != 0)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is RichTextBox)
                    {

                        string temp = string.Empty;
                        if ((c as RichTextBox).SelectionLength != 0)
                        {
                            temp = (c as RichTextBox).Text;

                            temp = temp.Insert((c as RichTextBox).SelectionStart, "<i>");
                            temp = temp.Insert((c as RichTextBox).SelectionStart + 3 + (c as RichTextBox).SelectionLength, "</i>");

                            (c as RichTextBox).Text = temp;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabPage t = tabControl1.SelectedTab;
            if (tabControl1.TabCount != 0)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is RichTextBox)
                    {

                        string temp = string.Empty;
                        if ((c as RichTextBox).SelectionLength != 0)
                        {
                            temp = (c as RichTextBox).Text;

                            temp = temp.Insert((c as RichTextBox).SelectionStart, "<u>");
                            temp = temp.Insert((c as RichTextBox).SelectionStart + 3 + (c as RichTextBox).SelectionLength, "</u>");

                            (c as RichTextBox).Text = temp;
                        }
                    }
                }
            }
        }
        private void textChanged(object sender, EventArgs e)
        {
            
            TabPage t = tabControl1.SelectedTab;
            foreach(Control c in t.Controls)
            {
                if(c is WebBrowser)
                {
                    (c as WebBrowser).DocumentText = (sender as RichTextBox).Text;
                    
                }
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width - 39;
            tabControl1.Height = this.Height - 100;
            if (tabControl1.TabCount != 0)
            {
                foreach (TabPage tb in tabControl1.TabPages)
                {

                    foreach (Control c in tb.Controls )
                    {
                        if(c is RichTextBox)
                        {
                            c.Width = tabControl1.Width / 2;
                            c.Height = tabControl1.Height;
                        }
                        else if(c is WebBrowser)
                        {
                            c.Width = tabControl1.Width / 2 - 12;

                            c.Left = tabControl1.Width / 2 + 2;
                            c.Height = tabControl1.Height - 2;
                        }
                    }



            }
            }
        }
    }
    
}
