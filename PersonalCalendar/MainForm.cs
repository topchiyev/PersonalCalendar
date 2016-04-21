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
    public partial class MainForm : Form
    {
        Database databaseConnection = Database.Instance;

        const Boolean UPDATE_EVENT = true;
        const Boolean SAVE_NEW_EVENT = false;

        Boolean viewEventsForDay = true;

        public MainForm()
        {
            InitializeComponent();
            initializeCalendar();
        }

        private void initializeCalendar()
        {
            editEventButton.Enabled = false;
            viewEventButton.Enabled = false;
            deleteEventButton.Enabled = false;

            //initialize values to show in the actual event list pane
            eventListBox.DisplayMember = "title";
            eventListBox.ValueMember = "title";

            List<Event> allEvents = new List<Event>();
            DateTime selectedStartDate = monthCalendar1.SelectionRange.Start;
            if (viewEventsForDay)
            {
                allEvents = databaseConnection.getAllEventsForDay(selectedStartDate);
            }
            else
            {
                allEvents = databaseConnection.getAllEventsForMonth(selectedStartDate);
            }

            eventListBox.Items.Clear();
            foreach(Event e in allEvents) {
                eventListBox.Items.Add(e);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventListBox.SelectedItem == null)
            {
                editEventButton.Enabled = false;
                viewEventButton.Enabled = false;
                deleteEventButton.Enabled = false;
            }
            else
            {
                editEventButton.Enabled = true;
                viewEventButton.Enabled = true;
                deleteEventButton.Enabled = true;
            }
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event();
            newEvent.startTime = DateTime.Now; //initialize date value or else an exception will be thrown
            newEvent.endTime = DateTime.Now.AddHours(1); //initialize end date and time as one hour from start date

            EditForm editForm = new EditForm(newEvent, this, SAVE_NEW_EVENT);
            editForm.ShowDialog();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (viewEventsForDay) {
                changeEventsForDayLabel();
                initializeCalendar();
            }
        }

        //changes the label above the events pane depending on the date selected
        private void changeEventsForDayLabel()
        {
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            if (selectedDate.Date == DateTime.Today)
            {
                eventsForDayLabel.Text = "Events for Today";
            }
            else if (selectedDate.Date == DateTime.Today.AddDays(-1))
            {
                eventsForDayLabel.Text = "Events for Yesterday";
            }
            else if (selectedDate.Date == DateTime.Today.AddDays(1))
            {
                eventsForDayLabel.Text = "Events for Tomorrow";
            }
            else
            {
                eventsForDayLabel.Text = "Events for " + selectedDate.ToString("MM/dd/yyyy");
            }
        }

        private void editEventButton_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event) eventListBox.SelectedItem;
            EditForm editForm = new EditForm(selectedEvent, this, UPDATE_EVENT);
            
            editForm.ShowDialog();
        }

        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)eventListBox.SelectedItem;
            DeleteForm confirmDeleteForm = new DeleteForm(selectedEvent, this);

            confirmDeleteForm.ShowDialog();
        }

        private void viewEventButton_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)eventListBox.SelectedItem;
            ViewForm viewForm = new ViewForm(selectedEvent, this);

            viewForm.ShowDialog();
        }

        private void allEventsButton_Click(object sender, EventArgs e)
        {
            //if we're currently viewing events for a certain day and user clicks this button
            if (viewEventsForDay)
            {
                //switch to viewing events for the selected month
                eventsForDayLabel.Text = "Viewing Events For Selected Month";

                //change button to let user know they can switch back to viewing events for a selected day
                allEventsButton.Text = "All Events For Selected Day";

                viewEventsForDay = false;
            }
            //if we're currently viewing events for a certain month and user clicks this button
            else
            {
                //bring back the "today's events" label
                changeEventsForDayLabel();

                //change button text to let user know they can switch back to viewing events for a selected month
                allEventsButton.Text = "All Events For Selected Month";

                viewEventsForDay = true;
            }

            initializeCalendar();
        }

        public void reloadAndShow()
        {
            initializeCalendar();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}
