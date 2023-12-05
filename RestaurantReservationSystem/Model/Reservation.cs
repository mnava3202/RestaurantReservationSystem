using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Model
{
    internal class Reservation
    {
        public DateTime date { get; set; }
        public int NumOfGuests { get; set; }

        public string Occasion { get; set; }

        public string RoomType { get; set; }


    }
}
