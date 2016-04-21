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

            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            endDateTimePicker.Format = startDateTimePicker.Format;
            endDateTimePicker.CustomFormat = startDateTimePicker.CustomFormat;

            titleTextBox.Text = calendarEvent.title;
            descriptionTextBox.Text = calendarEvent.description;
            startDateTimePicker.Value = calendarEvent.startTime;
            endDateTimePicker.Value = calendarEvent.endTime;
        }

        //get date selected by user before saving
        //first get all events for a certain day
        //then see if the time conflicts with another time
        //are we just using start time? or should i have included a start time and end time
        private Boolean checkForConflicts()
        {
            List<Event> allEventsForDay = databaseConnection.getAllEventsForDay(startDateTimePicker.Value);

            foreach (Event e in allEventsForDay)
            {
                //compareTo returns -1 for startDate is earlier than, 0 for same time as, 1 for greater than

                //if the two events start at the same time
                if (startDateTimePicker.Value.CompareTo(e.startTime) == 0)
                {
                    return true;
                }

                //if the chosen event starts after an existing events start time
                if (startDateTimePicker.Value.CompareTo(e.startTime) >= 1)
                {
                    //if the chosen date starts at the exact time an event ends OR if the chosen date starts before another event ends
                    if (startDateTimePicker.Value.CompareTo(e.endTime) <= 0)
                    {
                        return true;
                    }
                }

               
            }

            return false;
        }

        //save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (update)
            {
                databaseConnection.updateEventInDatabase(calendarEvent.id, titleTextBox.Text, descriptionTextBox.Text, startDateTimePicker.Value, endDateTimePicker.Value);
            }
            else
            {
                databaseConnection.saveEventToDatebase(titleTextBox.Text, descriptionTextBox.Text, startDateTimePicker.Value, endDateTimePicker.Value);
            }

            //check if no errors were found

            ConfirmSaveForm confirmSaveForm = new ConfirmSaveForm(mainForm, this);
            confirmSaveForm.ShowDialog();
        }

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
