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

        //initialize the data in the calendar and load events in the event list depending on whether the user is viewing events for the day or for the entire month
        private void initializeCalendar()
        {
            //make sure we have disabled the buttons
            editEventButton.Enabled = false;
            viewEventButton.Enabled = false;
            deleteEventButton.Enabled = false;

            //initialize values to show in the actual event list pane
            eventListBox.DisplayMember = "title";
            eventListBox.ValueMember = "title";

            //get all of the events from the database that are required for the current view
            List<Event> allEvents = new List<Event>();
            DateTime selectedStartDate = monthCalendar1.SelectionRange.Start;
            if (viewEventsForDay)
            {
                //if user is viewing events for a certain day, only grab those events
                allEvents = databaseConnection.getAllEventsForDay(selectedStartDate);
            }
            else
            {
                //if user is viewing events for the selected month, grab those events
                allEvents = databaseConnection.getAllEventsForMonth(selectedStartDate);
            }

            //add all of the events loaded from the database to the event list on the left side
            eventListBox.Items.Clear();
            foreach(Event e in allEvents) {
                eventListBox.Items.Add(e);
            }
        }

        //if no event is selected, disabled edit, view, and delete buttons. otherwise, allow user to click them
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //disable buttons if no event selected
            if (eventListBox.SelectedItem == null)
            {
                editEventButton.Enabled = false;
                viewEventButton.Enabled = false;
                deleteEventButton.Enabled = false;
            }
            //enable buttons if an event is selected
            else
            {
                editEventButton.Enabled = true;
                viewEventButton.Enabled = true;
                deleteEventButton.Enabled = true;
            }
        }

        //bring up the form for adding an event and initialize its data
        private void addEventButton_Click(object sender, EventArgs e)
        {
            Event newEvent = new Event();

            //get the date for right now and then reinitialize it with the seconds at 0. We won't be editing seconds for the event times
            var now = DateTime.Now;
            var date = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);

            newEvent.startTime = date; //initialize date value or else an exception will be thrown
            newEvent.endTime = date.AddHours(1); //initialize end date and time as one hour from start date

            EditForm editForm = new EditForm(newEvent, this, SAVE_NEW_EVENT);
            editForm.ShowDialog();
        }

        //when the user changes the dates, change the events in the events panel on the left and reinitialize calednar to refresh everything
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //we only change stuff for viewEventsForDay because if we're viewing events for the month, all the events for the month will be in left panel anyway
            if (viewEventsForDay) {
                changeEventsForDayLabel();
                initializeCalendar();
            }
        }

        //changes the label above the events pane depending on the date selected
        private void changeEventsForDayLabel()
        {
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            //if user has selected today, yesterday, or tomorrow, change the label to refelct that by getting the current date
            //otherwise, show Events for 'specific date' in the label
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

        //if user has selected an event and clicks edit event button, bring up the edit event form
        private void editEventButton_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event) eventListBox.SelectedItem;
            EditForm editForm = new EditForm(selectedEvent, this, UPDATE_EVENT);
            
            editForm.ShowDialog();
        }

        //if the user has selected an event and clicks delete event button, bring up the delete event dialog box
        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)eventListBox.SelectedItem;
            DeleteForm confirmDeleteForm = new DeleteForm(selectedEvent, this);

            confirmDeleteForm.ShowDialog();
        }

        //if the user has selected an event and clicks view event button, bring up the view event dialog box
        private void viewEventButton_Click(object sender, EventArgs e)
        {
            Event selectedEvent = (Event)eventListBox.SelectedItem;
            ViewForm viewForm = new ViewForm(selectedEvent, this);

            viewForm.ShowDialog();
        }

        //Change whether the user is viewing events for the month or only for the selected day
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

        //refresh window
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
