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
    public partial class DeleteForm : Form
    {
        Event selectedEvent;
        MainForm mainForm;
        Database databaseConnection = Database.Instance;

        public DeleteForm(Event selectedEvent, MainForm mainForm)
        {
            InitializeComponent();

            this.selectedEvent = selectedEvent;
            this.mainForm = mainForm;
        }

        //delete button click, confirm user wants to delete the event
        private void button1_Click(object sender, EventArgs e)
        {
            databaseConnection.deleteEventFromDatabase(selectedEvent.id);

            ConfirmDeleteForm confirmDeleteForm = new ConfirmDeleteForm(mainForm, this);
            confirmDeleteForm.ShowDialog();
        }

        //after event is confirmed deleted, return to main form
        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }
}
