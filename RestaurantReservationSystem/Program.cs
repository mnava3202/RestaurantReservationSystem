using RestaurantReservationSystem.Model;

namespace RestaurantReservationSystem;

internal class Program
{
    // an object is declared from the class Availability that is called a
    private static Availability a;

    // a list is declared that holds objects from the Reservation class and its called reservationList
    private static List<Reservation> reservationList;

    // the Main method
    static void Main(string[] args)
    {
        // calls the Initialize() method
        Initialize();

        // calls the StartMenu() method
        StartMenu();
    }

    // a method that initializes all the objects needed for the program, such as Tables and lists 
    static void Initialize()
    {
        // all the tables needed are declared and initialized
        Table t1 = new Table(1, 5, "12:00PM");

        Table t1_2 = new Table(1, 5, "2:00PM");

        Table t1_3 = new Table(1, 5, "4:00PM");

        Table t1_4 = new Table(1, 5, "6:00PM");

        Table t1_5 = new Table(1, 5, "8:00PM");

        Table t2 = new Table(2, 8, "12:00PM");

        Table t2_2 = new Table(2, 8, "2:00PM");

        Table t2_3 = new Table(2, 8, "4:00PM");

        Table t2_4 = new Table(2, 8, "6:00PM");

        Table t2_5 = new Table(2, 8, "8:00PM");

        Table t3 = new Table(3, 12, "12:00PM");

        Table t3_2 = new Table(3, 12, "2:00PM");

        Table t3_3 = new Table(3, 12, "4:00PM");

        Table t3_4 = new Table(3, 12, "6:00PM");

        Table t3_5 = new Table(3, 12, "8:00PM");

        // object a is initialized
        a = new Availability();

        // the Table objects are added to the list of free tables
        a.AddFreeTable(t1);

        a.AddFreeTable(t1_2);

        a.AddFreeTable(t1_3);

        a.AddFreeTable(t1_4);

        a.AddFreeTable(t1_5);

        a.AddFreeTable(t2);

        a.AddFreeTable(t2_2);

        a.AddFreeTable(t2_3);

        a.AddFreeTable(t2_4);

        a.AddFreeTable(t2_5);

        a.AddFreeTable(t3);

        a.AddFreeTable(t3_2);

        a.AddFreeTable(t3_3);

        a.AddFreeTable(t3_4);

        a.AddFreeTable(t3_5);

        // reservationList is initialized
        reservationList = new List<Reservation>();
    }

    // a method that acts like a menu for the user
    static void StartMenu()
    {
        // a boolean is intialized and it is used to see if the user wants to continue using the program
        bool done = false;

        // a while loop that keeps going until the user decides to end the program
        while(!done)
        {
            // displays the different options to the user
            Console.WriteLine("Options: Reservation System: 1 --- Reservation List: 2 --- Quit: q ---");

            // asks the user for their choice
            Console.Write("Choice: ");

            // stores the user's choice in a string variable
            string choice = Console.ReadLine();

            // a switch statement that calls different methods depending on the user's input
            switch(choice)
            {
                case "1":
                    // clears the terminal screen
                    Console.Clear();

                    // calls the ReservationProcess() method
                    ReservationProcess();

                    // breaks out of the switch statement
                    break;
                case "2":
                    // clears the termainl screen
                    Console.Clear();

                    // calls the ReservationList() method
                    ReservationList();

                    // breaks out of the switch statement
                    break;
                case "q":
                    // clears the terminal screen
                    Console.Clear();

                    // the boolean variable done is changed to true
                    done = true;

                    // breaks out of the switch statement
                    break;
                default:
                    // clears the terminal screen
                    Console.Clear();

                    // tells the user that they inputed an invalid command
                    Console.WriteLine("Invalid command!");

                    // breaks out of the switch statement
                    break;
            }
        }
    }

    // a method that does the process for the reservation system
    static void ReservationProcess()
    {
        // shows a greeting to the user
        Console.WriteLine("Hello! Thank you for choosing us for your dining needs.");

        // asks the user to enter the size of their party
        Console.Write("Please enter the size of your party: ");

        // converts the user's input into an integer and stores it in an integer variable
        int size = Convert.ToInt32(Console.ReadLine());

        // finds all the free tables that are greater than or equal to the party size
        var availableTables = a.freeTables.Where(o => o.SeatingCapacity >= size);

        // an if statement that checks to see if their are no available tables
        if(availableTables.Count() == 0)
        {
            // used to give space
            Console.WriteLine();

            // tells the user that there are no free tables available
            Console.WriteLine("Sorry, there are no free tables available at the moment that accomodates your party size.");

            // used to give space
            Console.WriteLine();

            // stops the execution of the current thread so the user can read the message
            Thread.Sleep(2000);

            // returns to the code that called the method
            return;
        }

        // used to give space
        Console.WriteLine();

        // shows the user the available tables
        Console.WriteLine("These are the available tables:");

        // a for loop that goes through the list of free tables
        for (int i = 0; i < a.freeTables.Count; i++)
        {
            // a if statement to see if the table meets the required size
            if (a.freeTables[i].SeatingCapacity >= size)
            {
                // displays the table to the user
                Console.WriteLine(a.freeTables[i]);
            }
        }

        // used to give space
        Console.WriteLine();

        // askes the user to enter the ID of the table that they want and the time they would like to choose
        Console.Write("Please type the ID of the table you would like to choose " +
            "followed by the time with a space in between (eg. 1 2:00PM): ");

        // stores the user's input in a string variable
        string input = Console.ReadLine();

        // splits the users input and stores them in a string array
        string[] idTime = input.Split(' ');

        // converts the user's input for the table ID to an integer and stores it in an integer variable
        int id = Convert.ToInt32(idTime[0]);

        // stores the user's input for time in a string variable
        string time = idTime[1];

        // finds the table that has the same ID and time as the user requested
        var findTable = a.freeTables.Where(o => (o.ID == id) && (o.time == time));

        // stores the desired table in a Table object
        Table chosenTable = findTable.First();

        // a for loop that goes through the list of free tables
        for (int i = 0; i < a.freeTables.Count; i++)
        {
            // stores the current table in a Table object
            Table t = a.freeTables[i];

            // a if statement to check to see if that is the table the user requested
            if (chosenTable.ID == t.ID && chosenTable.time == t.time)
            {
                // remove the table from the free tables list
                a.freeTables.RemoveAt(i);

                // adds the table to the list of reserved tables
                a.AddReservedTables(t);
            }
        }

        // a Reservation object is declared and initialized
        Reservation r = new Reservation();

        // calls the method SetTable and has chosenTable as the argument
        r.SetTable(chosenTable);

        // asks the user to enter the day of their reservation
        Console.Write("Please enter the day for your reservation (eg. Monday): ");

        // stores the user's desired day in a string variable
        string day = Console.ReadLine();

        // calls the method SetDate and has day as the argument
        r.SetDate(day);

        // a while loop that checks to see if the date attribute in the Reservation r object is null
        while (r.GetDate() == null)
        {
            // tells the user to enter the day again if their previous input was invalid
            Console.Write("Please enter the day for your reservation (eg. Monday): ");

            // stores the user's input in the same string variable day
            day = Console.ReadLine();

            // calls the method SetDate and has day as the argument
            r.SetDate(day);
        }

        // calls the method SetNumOfGuests and has size as the argument
        r.SetNumOfGuests(size);

        // tells the user to enter the occasion for their reservation
        Console.Write("Please enter the occasion for the reservation (eg. Business, Birthday, Anniversary or Regular): ");

        // stores the user's input in a string variable
        string occasion = Console.ReadLine();

        // calls the method SetOccasion and has occassion as the argument
        r.SetOccasion(occasion);

        // a while loop that checks to see if the occassion attribute in the Reservation r object is null
        while (r.GetOccasion() == null)
        {
            // tells the user to enter the occasion again if their previous input was invalid
            Console.Write("Please enter the occasion for the reservation (eg. Business, Birthday, Anniversary or Regular): ");

            // stores the user's input in the same string variable occasion
            occasion = Console.ReadLine();

            // calls the method SetOccasion and has occasion as the argument
            r.SetOccasion(occasion);
        }

        // asks the user to enter the room type for their reservation
        Console.Write("Please enter the room type you would like to have (Indoor or Outdoor): ");

        // stores the user's input in a string variable
        string type = Console.ReadLine();

        // calls the method SetRoomType and has type as the argument
        r.SetRoomType(type);

        // a while loop that checks to see if the RoomType attribute in the Reservation r object is null
        while (r.GetRoomType() == null)
        {
           // tells the user to enter the room type again if their previous input was invalid
           Console.Write("Please enter the room type you would like to have (Indoor or Outdoor): ");

           // stores the user's input in the same string variable type
           type = Console.ReadLine();

           // calls the method SetRoomType and has type as the argument
           r.SetRoomType(type);
        }

        // declares and initializes a Customer object called c
        Customer c = new Customer();

        // asks the user to enter their first and last name
        Console.Write("Please enter your first and last name: ");

        // stores the user's input in a string variable
        string inputTwo = Console.ReadLine();

        // splits the user's input and stores them in a string array
        string[] name = inputTwo.Split(' ');

        // stores the first element of the array in a string variable to represent the user's first name
        string firstName = name[0];

        // stores the second element of the array in a string variable to represent the user's last name
        string lastName = name[1];

        // sets the FirstName attribute in the Customer object c
        c.FirstName = firstName;

        // sets the LastName attribute in the Customer object c
        c.LastName = lastName;

        // asks the user to enter their email
        Console.Write("Please enter your email: ");

        // stores the user's input in a string variable
        string email = Console.ReadLine();

        // sets the Email attribute in the Customer object c
        c.Email = email;

        // asks the user to enter their phone number
        Console.Write("Please enter your phone number: ");

        // stores the user's input in a string variable
        string number = Console.ReadLine();

        //sets the PhoneNumber attribute in the Customer object c
        c.PhoneNumber = number;

        // calls the SetCustomer method and has c as the argument
        r.setCustomer(c);

        // adds the Reservation object r to the reservation list
        reservationList.Add(r);

        // used to give space
        Console.WriteLine();

        Console.WriteLine();

        // the user is thanked and tells them that their reservation details will be shown
        Console.WriteLine("Thank you for reserving with us! Below will be the " +
            "details of your reservation.");

        // stops the execution of the current thread so that the user can read the message before their reservation details are shown
        Thread.Sleep(3000);

        // used to give space
        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine();

        // displays the reservation details to the user
        Console.WriteLine(r);

        // stops the execution of the current thread so that the user can see their reservation details before they are brought back to the start menu
        Thread.Sleep(3000);

        // used to give space
        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine();
    }

    // a method that displays the reservation list to the employees
    static void ReservationList()
    {
        // tells the user that the reservation list is for employees only
        Console.WriteLine("---For Employees Only---");

        // tells the user that they have to login
        Console.WriteLine("Please login to view the reservation list.");

        // asks the user to enter the username
        Console.Write("Username: ");

        // stores the user's input in a string variable
        string username = Console.ReadLine();

        // asks the user to enter the password
        Console.Write("Password: ");

        // stores the user's input in a string variable
        string password = Console.ReadLine();

        // used to give space
        Console.WriteLine();

        Console.WriteLine();

        // a if statement to see if the user's inputs match the correct username and password
        if(username == "Sizzle" && password == "JuicySteaks")
        {
            // a for loop that displays the reservations in the list
            for(int i = 0; i < reservationList.Count; i++)
            {
                // prints out the reservations in the list
                Console.WriteLine(reservationList[i]);

                // used to give space
                Console.WriteLine();

                Console.WriteLine();
            }

            // used to give space
            Console.WriteLine();

            Console.WriteLine();
        }
        else
        {
            // tells the user that the username or password is incorrect and that they will be taken to the start menu
            Console.WriteLine("Incorrect username or password. You will be returned to the start menu.");

            //used to give space
            Console.WriteLine();

            Console.WriteLine();

            // stops the execution of the current thread so that the user can read the message before being taken back to the start menu
            Thread.Sleep(3000);

            // returns to the code where the method was called
            return;
        }
    }
}