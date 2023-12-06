using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Model
{
    public class Table
    {
        public int ID;

        public int SeatingCapacity;

        public string time;

        public Table(int id, int capacity, string t)
        {
            ID = id;

            SeatingCapacity = capacity;

            time = t;
        }
    }


}
