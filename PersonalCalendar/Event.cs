using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace PersonalCalendar
{
    public class Event
    {
        //data and time variable
        public int id { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public Event()
        {
            // TODO: Complete member initialization
        }
    }
}
