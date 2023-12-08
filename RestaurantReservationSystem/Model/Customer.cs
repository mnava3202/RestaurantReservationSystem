using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservationSystem.Model;

public class Customer
{
    public string FirstName { get; set; } // creates attribute of frst name, so that customers can input their name when making a resrvation and so that it will be saved

    public string LastName { get; set; } // creates attribute of last name, so that customers can input their last name when making a resrvation and so that it will be saved

    public string Email { get; set; } // creates attribute of email, so that customers can input their email when making a resrvation and so that it will be saved

    public string PhoneNumber { get; set; } // creates attribute of phone number, so that customers can input their phone number when making a resrvation and so that it will be saved
}