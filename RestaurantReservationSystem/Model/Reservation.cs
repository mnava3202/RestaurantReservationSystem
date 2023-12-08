using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Model
{
    public class Reservation //Created a class called reservation
    {
        private Customer c; //Used the class Customer to create an object called c

        public void setCustomer(Customer c) //Intializes the variable with a setter, which sets the value of c with c
        {
            this.c = c;
        }

        public Customer getCustomer() //Initializes the variable with a getter, which returns the value of c
        {
            return c;
        }

        /////////////////////////////////////////////////
        private Table t; //Uses the class Table to create an object called t

        public void SetTable(Table t) //Initializes the variable with a setter, which sets the variable t to the value of t
        {
            this.t = t;
        }

        public Table GetTable() //Initializes the variable with a getter, which returns the value of t
        {
            return t;
        }

        /////////////////////////////////////////////////
        private string date; //Creates a variable called date

        public string GetDate() //Getter for the variable date
        {
            return date; //Returns the value of date
        }

        public void SetDate( string t) //Sets the variable t to a specificed value
        {
            if (t != "Sunday" && t != "Monday" && t != "Tuesday" && t != "Wednesday" && t != "Thursday" && t != "Friday" && t != "Saturday")
            {
                Console.WriteLine("Invalid day.");
            }
            else 
            {
                date = t;
            }
        } // The above code is an if else statement that restricts the user's input to the 7 days of the week; any other input results in an Invalid day output

        /////////////////////////////////////////////////
        private int NumOfGuests; //Creates a variable called NumOfGuests, which is number of guests

        public int GetNumOfGuests() //Initializes the variable with a getter, which simply returns the value
        {
            return NumOfGuests;
        }

        public void SetNumOfGuests(int g) //Initializes the variable with a setter, which uses a variable called g as the arguement and uses that as the value for NumOfGuests
        {
            if (g > 0) 
            {
                NumOfGuests = g;
            }
        }
        /////////////////////////////////////////////////
        private string Occasion; //Creates a variable called Occasion

        public string GetOccasion() //Initializes the variable with a getter, which just returns the value of Occasion
        {
            return Occasion;
        }

        public void SetOccasion(string o) //Initializes the variable with a setter, which uses the variable o as an arguement
        {
            if (o != "Business" && o != "Birthday" && o != "Anniversary" && o != "Regular")
            {
                Console.WriteLine("Invalid occassion. Please type 'Business', 'Birthday', 'Anniversary' or 'Regular'.");
            }
            else
            { 
                Occasion = o; 
            }
        } //Uses an if else statement to restrict the user's input for Ocassion; if valid, the input will be the value for Ocassion
        /////////////////////////////////////////////////
        private string RoomType; //Creates a variable called RoomType

        public string GetRoomType() //Initializes the variable with a getter, which returns the value of RoomType
        {
            return RoomType;
        }

        public void SetRoomType (string r) //Initializes the variable with a setter that uses the variable r as an arguement
        {
            if (r != "Indoor" && r != "Outdoor")
            {
                Console.WriteLine("Invalid room type. Please type 'Indoor' or 'Outdoor'.");
            }
            else 
            {
                RoomType = r;
            }
           
        } //Uses an if else statement that restricts the user's input; if the input is valid, RoomType will have the value of r

        /////////////////////////////////////////////////
        public override string ToString()
        {
            string reservationOutput = "Table: " + t + ",\n" +
                "Customer: " + c + ",\n" +
                "Date: " + date + ",\n" +
                "Number of Guests: " + NumOfGuests + ",\n" +
                "Occasion: " + Occasion + ",\n" +
                "Room Type: " + RoomType;

            return reservationOutput;
        }
    }
}
