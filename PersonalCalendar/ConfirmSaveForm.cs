using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersonalCalendar
{
    public partial class ConfirmSaveForm : Form
    {
        MainForm mainForm;
        Form callingForm;

        public ConfirmSaveForm(MainForm mainForm, Form callingForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.callingForm = callingForm;
        }

        //OK button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            callingForm.Close();
            mainForm.reloadAndShow();
        }
    }
}
