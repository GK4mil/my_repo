using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditorByGawek
{
    public partial class PieProperty : Form
    {
        MainForm mf = null;
        public PieProperty()
        {
            InitializeComponent();
            mf =(MainForm) checkifwinopen(typeof(MainForm));
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

        private void startField_ValueChanged(object sender, EventArgs e)
        {
            mf.startAngle = (float)startField.Value;
            mf.sweepAngle = (float)sweepField.Value;
        }

        private void sweepField_ValueChanged(object sender, EventArgs e)
        {
            mf.startAngle = (float)startField.Value;
            mf.sweepAngle = (float)sweepField.Value;
        }

        private void PieProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.drawPie();
        }
    }
}
