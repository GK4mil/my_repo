using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
namespace RSS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Thread tt = new Thread(() => {
                System.Xml.XmlDocument rssXml = new System.Xml.XmlDocument();
                rssXml.Load(textBox1.Text);
                XmlNode rssnode = rssXml.SelectSingleNode("rss/channel/title");
                AddTitle(rssnode.InnerText);
                XmlNodeList rssnodelist = rssXml.SelectNodes("rss/channel/item");
                foreach(XmlNode x in rssnodelist)
                {
                    string tmp = x.SelectSingleNode("description").InnerText;
                    int end = tmp.IndexOf(">");
                    tmp = tmp.Substring(end + 1, tmp.Length - end - 2).Trim();
                    XmlNode node = x.SelectSingleNode("title");
                    string title = node.InnerText;
                   

                    Add(title, tmp);

                }
            });
            tt.Start();
        }
        private void AddTitle(string title)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => {
                    richTextBox1.Text += title + ":" + Environment.NewLine + Environment.NewLine;

                }));
            }
        }
        private void Add(string title, string desc)
        {
            if(InvokeRequired)
            {
                Invoke(new MethodInvoker(() => {
                    richTextBox1.Text+=title+":" + Environment.NewLine + Environment.NewLine + desc + Environment.NewLine + Environment.NewLine;

                }));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
