using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class UserPanel : Form
    {

        public UserPanel(Int64 ID, SQLiteConnection connection)
        {
            InitializeComponent();
            this.ID = ID;
            this.connection = connection;
            filterbox.TextChanged += new EventHandler(ListRSS);
            savebutton.Click += new EventHandler(AddRSS);
            


        }
        Int64 ID = 0;
        SQLiteConnection connection = null;
        SQLiteDataAdapter dataadapter = null;
        DataSet dataset = null;

        private void UserPanel_Load(object sender, EventArgs e)
        {
            ListRSS(new object(), new EventArgs());
            
        }
        private void ListRSS(object sender, EventArgs e)
        {

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            dataadapter = new SQLiteDataAdapter("SELECT ID, USERID, channel, " +
                "title,CONTENT from RSS where (lower(content) like '%' || lower(@parameter) ||'%'" +
                "or lower(title) like '%' || lower(@parameter) ||'%' " +
                "or lower(channel) like '%' || lower(@parameter) ||'%') and USERID=@owner", connection);
            dataadapter.SelectCommand.Parameters.Clear();
            dataadapter.SelectCommand.Parameters.Add("@parameter", DbType.String).Value = filterbox.Text;
            dataadapter.SelectCommand.Parameters.Add("@owner", DbType.Int64).Value = ID;
            
            dataset = new DataSet();
            dataadapter.Fill(dataset, "RSS");
            dg.DataSource = dataset;
            dg.DataMember = "RSS";
            dg.ClearSelection();



        }
        private void AddRSS(object sender, EventArgs e)
        {
            Thread t = new Thread(() => 
            {
                Invoke(new MethodInvoker(() => {

                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();
                        SQLiteCommand cmd = new SQLiteCommand(connection);
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO RSS(USERID,channel,title,CONTENT) values(@userid,@channel,@title,@content)";
                        cmd.Parameters.Add("@userid", DbType.Int64).Value = ID;


                        System.Xml.XmlDocument rssXml = new System.Xml.XmlDocument();
                        rssXml.Load(urlbox.Text);
                        XmlNode rssnode = rssXml.SelectSingleNode("rss/channel/title");
                        cmd.Parameters.Add("@channel", DbType.String).Value = urlbox.Text;

                        XmlNodeList rssnodelist = rssXml.SelectNodes("rss/channel/item");
                        foreach (XmlNode x in rssnodelist)
                        {
                            string tmp = x.SelectSingleNode("description").InnerText;
                            int end = tmp.IndexOf(">");
                            tmp = tmp.Substring(end + 1, tmp.Length - end - 2).Trim();
                            cmd.Parameters.Add("@content", DbType.String).Value = tmp;
                            XmlNode node = x.SelectSingleNode("title");
                            cmd.Parameters.Add("@title", DbType.String).Value = node.InnerText;
                            cmd.ExecuteNonQuery();


                        }
                        ListRSS(new object(), new EventArgs());
                    }
                    catch (Exception ce)
                    {

                        MessageBox.Show("Prawdopodobnie nie podano wlasciwego linku\nKod bledu: " + ce.Message);
                        urlbox.Focus();
                        urlbox.SelectAll();


                    }




                }));


            });
            t.Start();

        }
        private void UserPanel_Resize(object sender, EventArgs e)
        {
            dg.Size = new Size( displaying.Size.Width-14, displaying.Size.Height - 43);
            label2.Location = new Point(label2.Location.X, dg.Size.Height+9);
            filterbox.Width = dg.Width - 67;
            filterbox.Location = new Point(filterbox.Location.X, label2.Location.Y );
            urlbox.Width = displaying.Width - 16;
        }

        private void usunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLiteCommand cmd = new SQLiteCommand("delete from rss where id=@param", connection);
            foreach (DataGridViewRow r in dg.SelectedRows)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@param", DbType.Int64).Value = r.Cells[0].Value;
                cmd.ExecuteNonQuery();
                
            }
            ListRSS(new object(), new EventArgs());
        }
    }
}
