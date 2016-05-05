using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PersonalCalendar
{
    class Database
    {
        private static Database instance { get; set; }
        private MySqlConnection connection { get; set; }

        private Database()
        {
            openConnection();
        }

        ~Database()
        {
            closeConnection();
        }

        //create a new database instance
        public static Database Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new Database();
                }

                return instance;
            }
        }

        //update an existing event in the database
        public void updateEventInDatabase(int id, String title, String description, DateTime startTime, DateTime endTime)
        {
            //construct MYSQL query to update event in database
            String query = "UPDATE event SET title=@title, description=@description, start_time=@start_time, end_time=@end_time WHERE id=@id";
            MySqlCommand command = prepareQuery(query);

            //add event values to command to be executd by database
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@start_time", startTime);
            command.Parameters.AddWithValue("@end_time", endTime);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        //save a new event to the database
        public void saveEventToDatebase(String title, String description, DateTime startTime, DateTime endTime)
        {
            //construct MYSQL query to insert new event into database
            String query = "INSERT INTO event (title, description, start_time, end_time) VALUES (@title, @description, @start_time, @end_time)";
            MySqlCommand command = prepareQuery(query);

            //add event values to command to be executed by the database
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@start_time", startTime);
            command.Parameters.AddWithValue("@end_time", endTime);
            command.ExecuteNonQuery();
        }
        
        //delete an event from the database
        public void deleteEventFromDatabase(int id)
        {
            //construct MYSQL query to delete event from database
            String query = "DELETE FROM event WHERE id=@id";
            MySqlCommand command = prepareQuery(query);

            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
        
        //get all of the events in the database for a selected month. Will get month from the selectedStartDate passed to this method
        public List<Event> getAllEventsForMonth(DateTime selectedStartDate)
        {
            String query = "SELECT * FROM event WHERE MONTH(start_time)=@month";
            MySqlCommand command = prepareQuery(query);
            command.Parameters.AddWithValue("@month", selectedStartDate.Month);
            MySqlDataReader reader = command.ExecuteReader();

            return getAllEvents(reader);
        }

        //get all of the events in the database for a selected day
        public List<Event> getAllEventsForDay(DateTime selectedStartDate)
        {
            String query = "SELECT * FROM event WHERE date(start_time)=@start_time";
            MySqlCommand command = prepareQuery(query);
            command.Parameters.AddWithValue("@start_time", selectedStartDate);
            MySqlDataReader reader = command.ExecuteReader();

            return getAllEvents(reader);
        }

        //get all of the events in the databass. was mostly used for testing
        public List<Event> getAllEvents(MySqlDataReader reader)
        {
            List<Event> allEvents = new List<Event>();

            Event e;
            while (reader.Read())
            {
                e = new Event();

                //get id and convert to 32bit integer
                String idString = reader["id"].ToString();
                int id = Int32.Parse(idString);
                e.id = id;

                //get dateTime and convert to C# dateTime object
                String startDateTimeString = reader["start_time"].ToString();
                String endDateTimeString = reader["end_time"].ToString();
                DateTime startDateTime = DateTime.Parse(startDateTimeString);
                DateTime endDateTime = DateTime.Parse(endDateTimeString);
                e.startTime = startDateTime;
                e.endTime = endDateTime;

                //get event title and description
                e.title = reader["title"].ToString();
                e.description = reader["description"].ToString();

                //print results to console
                String printOut = "Event id: " + e.id
                    + "Event title " + e.title
                    + "Event description: " + e.description
                    + "Event Start Time and Date: " + e.startTime.ToString()
                    + "Event End Time and Date: " + e.endTime.ToString();
                Console.WriteLine(printOut);

                //add event to list of events to return
                allEvents.Add(e);
            }

            reader.Close();

            return allEvents;
        }

        //construct a command for a specific query passed to the method
        private MySqlCommand prepareQuery(String query) {
            MySqlCommand command = new MySqlCommand(query, connection);
            return command;
        }

        //open the connection to the database.
        public void openConnection()
        {
            String connectionString = "server=localhost;user=personalCalUser;database=personalcalendar;port=3306;password=p3rs0nalC@l;";
            connection = new MySqlConnection(connectionString);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //close the connection the database. will be called when the program is closed
        public void closeConnection()
        {
            connection.Close();
            Console.WriteLine("Connection closed.");
        }
    }
}
