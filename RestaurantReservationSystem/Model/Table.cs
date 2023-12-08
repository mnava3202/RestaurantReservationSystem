using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Model
{
    public class Table // This is a class representing a table in a restaraunt reservation system.
    {
        public int ID; // Public variable to store the ID of the table.

        public int SeatingCapacity; // Public variable to store the seating capacity of the table.

        public string time; // Public variable to store the time of the reservation.

        public Table(int id, int capacity, string t) // Constructor method for Table class, taking three parameters: id, capacity, and t.
        {
            ID = id; // Assign the value of id to the ID variable of the current instance (object).

            SeatingCapacity = capacity; // Assign the value of capacity to the SeatingCapacity variable of the current instance (object).

            time = t; // Assign the value of t to the time variable of the current instance (object).
        }
    }


}
