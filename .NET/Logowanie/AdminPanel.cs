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
    public partial class AdminPanel : Form
    {
        public AdminPanel(string admin_info)
        {
            InitializeComponent();
            info_adminPanel.Text = "Jestes zalogowany jako: " + admin_info;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
