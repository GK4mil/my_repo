using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApplication2
{
    public partial class UserPanel : Form
    {
        
        public UserPanel(string nazwa)
        {
            InitializeComponent();
            info_userPanel.Text = "Jestes zalogowany jako: " + nazwa;
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            
        }
    }
}
