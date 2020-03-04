﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace WindowsFormsApplication2
{
    public partial class AdminPanel : Form
    {
        SQLiteDataAdapter dataadapter;
        private SQLiteConnection connection;
        DataSet dataset;
        DataGridView d1;
        TabControl tab;
        ComboBox typeofuser = null;
        TextBox newusername = null;
        TextBox newpassword = null;
        SQLiteCommand cmd = null;
        Label usernamel = null;
        Label passwordl = null;
        Label typel = null;
        Button b = null;




        public AdminPanel(SQLiteConnection c)
        {
            InitializeComponent();
            //info_adminPanel.Text="Jestes zalogowany jako: "+nazwa;
            connection = c;
            c.Open();
            this.StartPosition = FormStartPosition.CenterScreen;
            d1 = new DataGridView();
            




        }
        private void CreateTabControl()
        {
            tab = new TabControl();
            tab.Dock = DockStyle.Fill;
            TabPage page = new TabPage();
            page.Text="Users";
            page.Name = "Users";
            this.d1.AllowUserToAddRows = false;
            this.d1.AllowUserToDeleteRows = false;
            this.d1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d1.ContextMenuStrip = this.contextMenuStrip1;
            this.d1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.d1.Location = new System.Drawing.Point(0, 86);
            this.d1.Name = "dataGridView1";
            this.d1.ReadOnly = true;
            this.d1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d1.Size = new System.Drawing.Size(507, 204);

            
           
            
            page.Controls.Add(d1);

            tab.TabPages.Add(page);
            Controls.Add(tab);
            page = new TabPage("Adding");

            usernamel = new Label();
            usernamel.Location = new System.Drawing.Point(3,10);
            usernamel.Size = new System.Drawing.Size(73, 13);
            usernamel.Text = "Username:";
            page.Controls.Add(usernamel);

            passwordl = new Label();
            passwordl.Location = new System.Drawing.Point(3, 39);
            passwordl.Size = new System.Drawing.Size(73, 13);
            passwordl.Text = "Password:";
            page.Controls.Add(passwordl);



            typel = new Label();
            typel.Location = new System.Drawing.Point(3, 68);
            typel.Size = new System.Drawing.Size(73, 13);
            typel.Text = "Account type:";
            page.Controls.Add(typel);
            // 
            // comboBox1
            //
            typeofuser = new ComboBox();
            typeofuser.FormattingEnabled = true;
            typeofuser.Items.AddRange(new object[] {
            "ADMIN",
            "NORMAL"});
            typeofuser.Location = new System.Drawing.Point(typel.Right+3, typel.Location.Y);
            typeofuser.Size = new System.Drawing.Size(121, 21);
            
            typeofuser.DropDownStyle = ComboBoxStyle.DropDownList;
            page.Controls.Add(typeofuser);
            // 
            //userpassword
            newpassword = new TextBox();
            newpassword.Location = new System.Drawing.Point(passwordl.Right+3,passwordl.Location.Y);
            newpassword.Size = new System.Drawing.Size(121, 18);
            newpassword.PasswordChar = '*';
            newpassword.TabIndex = 2;
            
            page.Controls.Add(newpassword);
            
            // 
            // username
            newusername = new TextBox();

            newusername.Location = new System.Drawing.Point(usernamel.Right+3,usernamel.Location.Y);
            newusername.Size = new System.Drawing.Size(121, 18);
            newusername.TabIndex = 1;
            page.Controls.Add(newusername);


            
            b = new Button();
            b.Text = "Add";
            b.Location = new System.Drawing.Point(typeofuser.Location.X, typeofuser.Location.Y+30);
            b.Size = new System.Drawing.Size(121, 23);
            b.UseVisualStyleBackColor = true;
            b.Click += new EventHandler(AddClick);
            page.Controls.Add(b);

            tab.TabPages.Add(page);


        }
        private void AddClick(object sender, EventArgs e)
        {
            if(newusername.Text.Length==0)
            {
                MessageBox.Show("Wprowadz login uzytkownika");
                newusername.Focus();
                return;
            }
            if (newpassword.Text.Length == 0)
            {
                MessageBox.Show("Wprowadz haslo uzytkownika");
                newpassword.Focus();
                return;
            }
            if(typeofuser.SelectedItem==null)
            {
                MessageBox.Show("Wybierz typ uzytkownika");
                typeofuser.DroppedDown = true;
                return;
            }
            Int64 liczba = 0;
            cmd = new SQLiteCommand(connection);
            cmd.CommandText="Select count(1) from user where username=@username";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@username", DbType.String).Value = newusername.Text;
            SQLiteDataReader rdr;
            rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                liczba = (Int64)rdr[0];
            }
            
            if(liczba!=0)
            {
                MessageBox.Show("Uzytownik o takim loginie juz istnieje");
                newusername.Focus();
                newusername.SelectAll();
                return;
                
            }
            rdr.Close();
            AddUser();
            

            
            
        }
        private void AddUser()
        {
            cmd.CommandText= "INSERT into user(USERNAME, PASSWORD,ISADMIN) values(@username,@password,@isadmin)";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@username", DbType.String).Value = newusername.Text;
            cmd.Parameters.Add("@password", DbType.String).Value = secure.Hash(newpassword.Text);
            Int64 temp = 0;
            
            if (typeofuser.SelectedItem.ToString() == "ADMIN")
                temp = 1;
            cmd.Parameters.Add("@isadmin", DbType.Int64).Value = temp;
            if(cmd.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Dodano pomyslnie");
                tab.SelectTab("Users");
                ListUser();
                EraseTextbox();
                return;
            }
            MessageBox.Show("Cos nie poszlo");
            
            
        }
        private void EraseTextbox()
        {
            typeofuser.SelectedItem = null;
            newusername.Text = String.Empty;
            newpassword.Text = String.Empty;
        }
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            
            CreateTabControl();
            ListUser();

        }
        private void ListUser()
        {
            if (connection.State ==ConnectionState.Open)
            {
                TabPage temptab=null;
                DataGridView dg = null;
                foreach(TabPage t in tab.TabPages)          //szukanie taba
                {
                    if (t.Text == "Users")
                        temptab = t;
                }
                if(temptab!=null)
                {
                    foreach(Control c in temptab.Controls)      //szukanie kontrolki
                    {
                        if (c is DataGridView)
                            dg = (c as DataGridView);
                    }
                }
                if(dg!=null)                    //zaladowanie danych
                {
                    dataadapter = new SQLiteDataAdapter("SELECT ID,USERNAME,ISADMIN FROM USER", connection);
                    dataset = new DataSet();
                    dataadapter.Fill(dataset, "USER");
                    dg.DataSource = dataset;
                    dg.DataMember = "USER";
                    dg.ClearSelection();
                   
                }
               
                

            }

        }
        private void usunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in d1.SelectedRows )
            {
                if ((Int64)r.Cells[0].Value != 1)
                {
                    SQLiteCommand cmd = new SQLiteCommand("delete from user where id=@id", connection);
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@ID", DbType.Int64).Value = r.Cells[0].Value;
                    if (cmd.ExecuteNonQuery() > 0)
                        d1.Rows.Remove(r);
                }
                    
            }
            
        }
    }
}
