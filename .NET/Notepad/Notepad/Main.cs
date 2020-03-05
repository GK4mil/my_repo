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
            OtworzPlik.Filter = "Tekst|*.txt";
            zapiszPlik.Filter = "Tekst|*.txt";

        }
        List<FileNames> content = new List<FileNames>();  //lista nazw z zawartoscia

        string savedText = string.Empty;    //z pliku
        string currentText = string.Empty;  //edytowany

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
            if (content.Count == 0)
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


            RichTextBox r = new RichTextBox();
            r.Multiline = true;
            r.Dock = System.Windows.Forms.DockStyle.Fill;
            r.Location = new System.Drawing.Point(3, 3);
            r.Name = "richTextBox1";
            r.Size = new System.Drawing.Size(270, 205);
            r.TabIndex = 0;
            r.Text = savedText;
            t.Controls.Add(r);                       //dodanie reachtext do tabpage
            tabControl1.SelectTab(t);
            content.Add(new FileNames(Path.GetFileName(t.Text),r.Text));

        }
        private void SaveFile()
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
                //////////////////////////////////////////////////////////////////////////////
                if (findPath(activeTab.Text, activeRTB.Text) == true)       //funkcja sprawdzajaca z listy, czy plik sie zmienil
                {
                    if (MessageBox.Show("Zawartość pliku nie została zmieniona\nCzy mimo to chcesz zapisać plik?\n('Nie' nie zapisuje ponownie pliku" +
                        " i zamyka aktywną zakładkę).", "Uwaga", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        if (zapiszPlik.ShowDialog() == DialogResult.OK)
                        {
                            content.RemoveAt(ReturnIndexOfPath(activeTab.Text));
                            File.WriteAllText(zapiszPlik.FileName, activeRTB.Text); //zapis pliku
                            activeTab.Controls.Remove(activeRTB);                   //uswanie rtb
                            tabControl1.TabPages.Remove(activeTab);                 //usuwanie tabpage
                        }
                        else
                            return;
                    }
                    else
                    {
                        content.RemoveAt(ReturnIndexOfPath(activeTab.Text));
                        activeTab.Controls.Remove(activeRTB);                   //uswanie rtb
                        tabControl1.TabPages.Remove(activeTab);                 //usuwanie tabpage
                        return;
                    }
                }
                else if (zapiszPlik.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        content.RemoveAt(ReturnIndexOfPath(activeTab.Text));
                        File.WriteAllText(zapiszPlik.FileName, activeRTB.Text); //zapis pliku
                        activeTab.Controls.Remove(activeRTB);                   //uswanie rtb
                        tabControl1.TabPages.Remove(activeTab);                 //usuwanie tabpage
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            
        
                //////////////////////////////////////////////////////////////////////////////////
            }
            else
                MessageBox.Show("Brak otwartych plików", "Błąd");
        }
        private bool findPath(string name, string text)
        {
            foreach(FileNames f in content)
            {
                if(f.path==name)
                {
                    if (f.savedText == text)
                        return true;
                }
            }
            return false;
        }
        private int ReturnIndexOfPath(string name)
        {
            int i = 0;
            foreach (FileNames f in content)
            {
                if (f.path == name)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        private void zapiszIZamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

     

        private void zamknijZakładkeBezZapisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage activeTab = tabControl1.SelectedTab;  //aktywny tab
            RichTextBox activeRTB = null;               //aktywny richtextbox

            if (activeTab != null)                        //czy istnieje tab
            {
                foreach (Control contr in activeTab.Controls)
                {
                    if (typeof(RichTextBox) == contr.GetType())
                        activeRTB = (RichTextBox)contr;
                }
            }

            if (activeTab != null)                        //czy istnieje tab
            {
               if( MessageBox.Show("Czy na pewno chcesz zamknąć zakładkę bez zapisu?","Uwaga",MessageBoxButtons.YesNo)==DialogResult.Yes)
                    content.RemoveAt(ReturnIndexOfPath(activeTab.Text));
                    activeTab.Controls.Remove(activeRTB);                   //uswanie rtb
                    tabControl1.TabPages.Remove(activeTab);                 //usuwanie tabpage

            }
            else
                MessageBox.Show("Brak otwartego pliku!");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (content.Count != 0)
            {
                if (MessageBox.Show("Czy chcesz zamknąć program bez zapisu otwartych plików?", "Zapisywanie", MessageBoxButtons.YesNo) == DialogResult.No)
                    e.Cancel = true;
            }
          
        }
    }
}
