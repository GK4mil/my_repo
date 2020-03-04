using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
//TRZEBA SKOPIOWAC INTERROPT W BIN TAM GDZIE BEDZIE EXE
//ODWOLANIA TO LINK I LITE DDL
//podrozwiazaniem nazwa projektu trzeba wejsc w kompilacje i wylaczyc preferowany tryb 32 bit.
//using system.linq
//using system.data.sqllite
//system data sql lite org
using System.Security.Cryptography;

namespace WindowsFormsApplication2
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
            CreateDB();
            
        }
        AdminPanel _AdminPanel;
        UserPanel _UserPanel;
        SQLiteConnection connection;

        private void CreateDB()
        {
            try
            {
                if (!System.IO.File.Exists("baza.db"))
                {
                    connection = new SQLiteConnection("Data Source=baza.db;Version=3;");
                    SQLiteConnection.CreateFile("baza.db");
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE USER (ID INTEGER NOT NULL" +
                        " PRIMARY KEY AUTOINCREMENT , USERNAME VARCHAR(255), PASSWORD VARCHAR(255), ISADMIN INTEGER)", connection);
                    int k = cmd.ExecuteNonQuery();      //wywolanie komendy
                    cmd.CommandText = "INSERT INTO USER (ID, USERNAME, PASSWORD,ISADMIN) VALUES" +
                        " (@ID,@USERNAME, @PASSWORD, @ISADMIN)";

                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@ID", DbType.Int32).Value = 1;
                    cmd.Parameters.Add("@USERNAME", DbType.String).Value = "kamil";
                    cmd.Parameters.Add("@PASSWORD", DbType.String).Value = secure.Hash("haslo");
                    cmd.Parameters.Add("@ISADMIN", DbType.Int32).Value = 1;

                    cmd.ExecuteNonQuery();


                    cmd.CommandText = "INSERT INTO USER (USERNAME, PASSWORD,ISADMIN) VALUES" +
                        " (@USERNAME, @PASSWORD, @ISADMIN)";

                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@USERNAME", DbType.String).Value = "admin";
                    cmd.Parameters.Add("@PASSWORD", DbType.String).Value = secure.Hash("admin1");
                    cmd.Parameters.Add("@ISADMIN", DbType.Int32).Value = 1;

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@USERNAME", DbType.String).Value = "user1";
                    cmd.Parameters.Add("@PASSWORD", DbType.String).Value = secure.Hash("user");
                    cmd.Parameters.Add("@ISADMIN", DbType.Int32).Value = 0;

                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    cmd.Parameters.Add("@USERNAME", DbType.String).Value = "user";
                    cmd.Parameters.Add("@PASSWORD", DbType.String).Value = secure.Hash("user");
                    cmd.Parameters.Add("@ISADMIN", DbType.Int32).Value = 0;

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "CREATE TABLE RSS (ID INTEGER NOT NULL" +
                       " PRIMARY KEY AUTOINCREMENT , USERID INTEGER NOT NULL, channel STRING, title STRING,CONTENT STRING)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into rss values(0,0,'0','0','0')";
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void login_Click(object sender, EventArgs e)
        {

            try
            {
                connection = new SQLiteConnection("Data Source=baza.db;Version=3;");

                Int64 ID = 0;
                Int64 ISADMIN = 0;
                connection.Open();

                SQLiteCommand cmd = new SQLiteCommand("SELECT ID, ISADMIN FROM USER" +
                    " where USERNAME=@USERNAME AND PASSWORD=@PASSWORD", connection);

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@USERNAME", DbType.String).Value = loginBox.Text;
                cmd.Parameters.Add("@PASSWORD", DbType.String).Value = secure.Hash(passBox.Text);
                SQLiteDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ID = (Int64)rdr[0]; //lub rdr[0];
                    ISADMIN = (Int64)rdr[1];            //musi byc int64 bo baza jest 64 bit
                    if (ID > 0)
                        break;

                }
                if (rdr != null)
                    rdr.Close();
                connection.Close();

                if (ID > 0 && ISADMIN == 1)
                {
                    if ((_AdminPanel = ((checkifwinopen(typeof(AdminPanel))) as AdminPanel)) != null)
                    {
                        _AdminPanel.Focus();
                    }
                    else
                    {
                        (_AdminPanel = new AdminPanel(connection)).Show();
                    }

                }
                else if (ID > 0 && ISADMIN == 0)
                {

                    if ((_UserPanel = ((checkifwinopen(typeof(UserPanel))) as UserPanel)) != null)
                    {
                        _UserPanel.Focus();
                    }
                    else
                    {
                        (_UserPanel = new UserPanel(ID,connection)).Show();
                    }
                }
                else
                {
                    MessageBox.Show("Brak uzytkownikow");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }


        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        private Form checkifwinopen(Type FormType)
        {

            foreach (Form OpenedForm in Application.OpenForms)
            {
                if (OpenedForm.GetType() == FormType)
                    return OpenedForm;
            }
            return null;
        
        }

        private void U_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=baza.db;Version=3;");
            (_UserPanel = new UserPanel(3, connection)).Show();
        }

        private void A_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection("Data Source=baza.db;Version=3;");
            (_AdminPanel = new AdminPanel(connection)).Show();
            
        }
    }
}
