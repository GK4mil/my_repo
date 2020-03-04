using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();
            CreateUsers();
        }
        AdminPanel _AdminPanel;
        UserPanel _UserPanel;
        List<User> users;   //lista uzytkownikow
        

        private void CreateUsers()
        {
            users = new List<User>();
            users.Add(new User("admin", "1234", true));    //dodanie uzytkownikow
            users.Add(new User("kamil", "12345", true));
            users.Add(new User("kamila", "2345", false));
            users.Add(new User("karol", "12345", false));
            users.Add(new User("zdzisiek", "61345", false));
            users.Add(new User("janek", "12345", false));
            users.Add(new User("janusz", "12345", true));
            users.Add(new User("halina", "12395", false));
            users.Add(new User("grazyna", "1345", false));
            users.Add(new User("piotr", "192345", false));
            



        }
        private void login_Click(object sender, EventArgs e)
        { 

            if (loginBox.Text.Length == 0)
            {
                loginBox.Focus();
                return;
            }
            if (passBox.Text.Length == 0)
            {
                passBox.Focus();
                return;
            }
            auth(loginBox.Text, passBox.Text);

        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void auth(string user, string pass)
        {
            
            foreach (User usr in users)
            {
                

                if (usr.username==user&&usr.passiscorrect(pass))
                {
                    
                    if (usr.isAdmin)
                    {
                        if((_AdminPanel=(AdminPanel)checkifwinopen(typeof(AdminPanel)))==null
                            && (_UserPanel = (UserPanel)checkifwinopen(typeof(UserPanel))) == null)
                        {
                            _AdminPanel = new AdminPanel(usr.username);
                            _AdminPanel.Show();
                        }
                    }
                    else
                    {
                        if ((_AdminPanel = (AdminPanel)checkifwinopen(typeof(AdminPanel))) == null
                            && (_UserPanel = (UserPanel)checkifwinopen(typeof(UserPanel))) == null)
                        {
                            _UserPanel = new UserPanel(usr.username);
                            _UserPanel.Show();
                        }
                    }
                }

            }

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

        private void passBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                login_Click(sender, e);
        }

        private void loginBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                login_Click(sender, e);
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
