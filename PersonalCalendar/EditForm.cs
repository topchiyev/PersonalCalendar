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
    public partial class EditForm : Form
    {
        Event calendarEvent;
        Database databaseConnection;
        MainForm mainForm;
        Boolean update; //set to true if updating existing event, false if saving brand new event

        public EditForm(Event calendarEvent, MainForm mainForm, Boolean update)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            databaseConnection = Database.Instance;
            this.calendarEvent = calendarEvent;
            this.update = update;

            //INitialize DateTime pickers
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            endDateTimePicker.Format = startDateTimePicker.Format;
            endDateTimePicker.CustomFormat = startDateTimePicker.CustomFormat;

            //initialize the input boxes with the information passed to this method. Will be empty if this is a new event.
            titleTextBox.Text = calendarEvent.title;
            descriptionTextBox.Text = calendarEvent.description;
            startDateTimePicker.Value = calendarEvent.startTime;
            endDateTimePicker.Value = calendarEvent.endTime;
        }


        //get date selected by user before saving
        //first get all events for a certain day
        //then see if the time conflicts with another time
        private Boolean conflictFound()
        {
            List<Event> allEventsForDay = databaseConnection.getAllEventsForDay(startDateTimePicker.Value);

            DateTime chosenStartTime = startDateTimePicker.Value;
            DateTime chosenEndTime = endDateTimePicker.Value;
            bool conflictFound = false;
            foreach (Event e in allEventsForDay)
            {
                //make sure we're not conflict checking with the current meeting (if we're editing)
                if(e.title != titleTextBox.Text.ToString())
                {
                    //if user selected starttime is less than other events end time and selected end time is greater than other events start time, then a conflict exists
                    if ((chosenStartTime <= e.endTime) && (chosenEndTime >= e.startTime))
                    {
                        conflictFound = true;
                        break;
                    }
                }              
            }

            return conflictFound;
        }

        //Check if an event is valid by checking if title, description are empty and seeing if the date and times are in the right format
        private Boolean eventValid()
        {
            Boolean eventValid = true;
            String title = titleTextBox.Text.ToString();
            String description = titleTextBox.Text.ToString();

            //make sure title isn't null, empty, or whitespace
            if(String.IsNullOrWhiteSpace(title))
            {
                eventValid = false;
            }
            //make sure description isn't null, empty, or whitespace
            if(String.IsNullOrWhiteSpace(description))
            {
                eventValid = false;
            }

            //dates should always be filled out, but just in case, make sure they aren't null
            DateTime startTime = startDateTimePicker.Value;
            DateTime endTime = endDateTimePicker.Value;
            if (startTime == null)
            {
                eventValid = false;
            }

            if(endTime == null)
            {
                eventValid = false;
            }

            //start time should always be after end time
            if(startTime > endTime)
            {
                eventValid = false;
            }

            return eventValid;
        }

        //save button
        private void button1_Click(object sender, EventArgs e)
        {
            //if no conflicts are found and the event is a valid event (all info filled out)
            if(!conflictFound() && eventValid()) {
                if (update)
                {
                    //update an event in the database
                    databaseConnection.updateEventInDatabase(calendarEvent.id, titleTextBox.Text, descriptionTextBox.Text, startDateTimePicker.Value, endDateTimePicker.Value);
                }
                else
                {
                    //save a new event to the database
                    databaseConnection.saveEventToDatebase(titleTextBox.Text, descriptionTextBox.Text, startDateTimePicker.Value, endDateTimePicker.Value);
                }

                //show user a form that confirms the save is done
                ConfirmSaveForm confirmSaveForm = new ConfirmSaveForm(mainForm, this);
                confirmSaveForm.ShowDialog();
            } else
            {
                //if a conflict is found with another event, show an error message
                if(conflictFound())
                {
                    MessageBox.Show("The selected event conflicts with another event, please change the times of the meeting", "Conflicting Meeting Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //if the event is not valid show an error message
                if(!eventValid())
                {
                    MessageBox.Show("Not all information has been filled out correctly", "Event Information Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Stop editing or creating the current event
        private void cancelButton_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        //when the startDateTimePicker is changed, change the end date and time to be 1 hour later on the same date
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
