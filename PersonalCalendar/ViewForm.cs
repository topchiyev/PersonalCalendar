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
    public partial class ViewForm : Form
    {
        Event selectedEvent;
        MainForm mainForm;

        public ViewForm(Event selectedEvent, MainForm mainForm)
        {
            InitializeComponent();

            this.selectedEvent = selectedEvent;
            this.mainForm = mainForm;

            //initialize labels with selected event info
            startDateTimeLabel.Text = selectedEvent.startTime.ToString();
            endDateTimeLabel.Text = selectedEvent.endTime.ToString();
            titleLabel.Text = selectedEvent.title;
            descriptionLabel.Text = selectedEvent.description;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
