using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Model
{
    public class Reservation
    {
        private DateTime date;

        public DateTime GetDate() 
        {
            return date;
        }

        public void SetDate( string t) 
        {
            if (t != "Sunday" && t != "Monday" && t != "Tuesday" && t != "Wednesday" && t != "Thursday" && t != "Friday" && t != "Saturday")
            {
                Console.WriteLine("Invalid day.");
            }
            else 
            {
                date = DateTime.Parse(t);
            }
        }

        /////////////////////////////////////////////////
        private int NumOfGuests;

        public int GetNumOfGuests() 
        {
            return NumOfGuests;
        }

        public void SetNumOfGuests(int g) 
        {
            if (g > 0) 
            {
                NumOfGuests = g;
            }
        }
        /////////////////////////////////////////////////
        private string Occasion;

        public string GetOccasion() 
        {
            return Occasion;
        }

        public void SetOccasion(string o) 
        {
            if (o != "Business" && o != "Birthday" && o != "Anniversary" && o != "Regular")
            {
                Console.WriteLine("Invalid occassion. Please type 'Business', 'Birthday', 'Anniversaty' or 'Regular'.");
            }
            else
            { 
                Occasion = o; 
            }
        }
        /////////////////////////////////////////////////
        private string RoomType;

        public string GetRoomType() 
        {
            return RoomType;
        }

        public void SetRoomType (string r) 
        {
            if (r != "Indoor" && r != "Outdoor")
            {
                Console.WriteLine("Invalid room type. Please type 'Indoor' or 'Outdoor'.");
            }
            else 
            {
                RoomType = r;
            }
           
        }


    }
}
