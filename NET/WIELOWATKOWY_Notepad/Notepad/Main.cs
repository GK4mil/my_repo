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
using System.Threading;
namespace Notepad
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
            OtworzPlik.FileName = "";
            OtworzPlik.Filter = "Tekst|*.txt";
            zapiszPlik.Filter = "Tekst|*.txt";


            
        }
        

        string savedText = string.Empty;    //z pliku
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (OtworzPlik.ShowDialog() == DialogResult.OK)
            {
                
                Thread t = new Thread(() => 
                {
                   
                        openFile(OtworzPlik.FileName);

                  
                });
                t.Start();
                t = null;
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
            {
                Close();
            }
            else if (MessageBox.Show("Czy chcesz zamknąć program bez zapisu otwartych plików?", "Zapisywanie", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
            else
                return;
        }
        private void openFile(string file)
        {
            try
            {
                string filecontent = string.Empty;

                filecontent=File.ReadAllText(file);
                addTab(file, filecontent);
                
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void addTab(string fileName, string filecontent)
        {
            if (InvokeRequired)
            {
                
                Invoke(new MethodInvoker(()=> 
                {
                    TabPage t = new TabPage();          //nowy tabpage
                    t.Text = Path.GetFileName(fileName);
                    


                    RichTextBox r = new RichTextBox();
                    r.Multiline = true;
                    r.Dock = System.Windows.Forms.DockStyle.Fill;
                    r.Location = new System.Drawing.Point(3, 3);
                    r.Name = "richTextBox1";
                    r.Size = new System.Drawing.Size(270, 205);
                    r.TabIndex = 0;
                    r.Text = filecontent;
                    t.Controls.Add(r);                       //dodanie reachtext do tabpage
                  
                    tabControl1.Controls.Add(t);        //dodanie tabpage do tabcontrol
                }));
            }
            else
            {
                TabPage t = new TabPage();          //nowy tabpage
                t.Text = fileName;



                RichTextBox r = new RichTextBox();
                r.Multiline = true;
                r.Dock = System.Windows.Forms.DockStyle.Fill;
                r.Location = new System.Drawing.Point(3, 3);
                r.Name = "richTextBox1";
                r.Size = new System.Drawing.Size(270, 205);
                r.TabIndex = 0;
                r.Text = filecontent;
                t.Controls.Add(r);                       //dodanie reachtext do tabpage

                tabControl1.Controls.Add(t);        //dodanie tabpage do tabcontrol
            }
           
            

        }
        private void SaveFile()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SaveFile));
            }
            
            else
            {
                TabPage activeTab = tabControl1.SelectedTab;  //aktywny tab
                RichTextBox activeRTB = null;               //aktywny richtextbox

                if (activeTab != null)                        //czy istnieje tab
                { foreach (Control contr in activeTab.Controls)
                    {
                        if (typeof(RichTextBox) == contr.GetType())
                            activeRTB = (RichTextBox)contr;
                    }
                }

                if (activeRTB != null)      //jezeli kontrolka niepusta
                {

                    zapiszPlik.FileName = activeTab.Text;       //nazwa pliku



                    if (zapiszPlik.ShowDialog() == DialogResult.OK)
                    {

                        File.WriteAllText(zapiszPlik.FileName, activeRTB.Text); //zapis pliku
                        activeTab.Controls.Remove(activeRTB);                   //uswanie rtb
                        tabControl1.TabPages.Remove(activeTab);                 //usuwanie tabpage
                    }
                    else
                        return;

                }
                else
                {
                    MessageBox.Show("Brak otwartych zakladek");
                }
            }
        }
      
        private void zapiszIZamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => 
            {
                SaveFile();
            });
            t.Start();
            t = null;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                if (MessageBox.Show("Czy chcesz zamknąć program?", "Zapisywanie", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
           
          
        }
    }
}
