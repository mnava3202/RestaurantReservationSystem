using RestaurantReservationSystem.Model;

namespace RestaurantReservationSystem;

internal class Program
{
    private static Availability a;
    private static List<Reservation> reservationList;

    static void Main(string[] args)
    {
        Initialize();

        StartMenu();
    }

    static void Initialize()
    {
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

        a = new Availability();

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

        reservationList = new List<Reservation>();
    }

    static void StartMenu()
    {
        bool done = false;

        while(!done)
        {
            Console.WriteLine("Options: Reservation System: 1 --- Reservation List: 2 --- Quit: q ---");

            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.Clear();
                    ReservationProcess();
                    break;
                case "2":
                    Console.Clear();
                    ReservationList();
                    break;
                case "q":
                    Console.Clear();
                    done = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }
    }

    static void ReservationProcess()
    {
        Console.WriteLine("Hello! Thank you for choosing us for your dining needs.");

        Console.Write("Please enter the size of your party: ");

        int size = Convert.ToInt32(Console.ReadLine());

        var availableTables = a.freeTables.Where(o => o.SeatingCapacity > size);

        if(availableTables.Count() == 0)
        {
            Console.WriteLine();

            Console.WriteLine("Sorry, there are no free tables available at the moment that accomodates your party size.");

            Console.WriteLine();

            Thread.Sleep(2000);

            return;
        }

        Console.WriteLine();

        Console.WriteLine("These are the available tables:");

        for (int i = 0; i < a.freeTables.Count; i++)
        {

            if (a.freeTables[i].SeatingCapacity > size)
            {

                Console.WriteLine(a.freeTables[i]);
            }
        }

        Console.WriteLine();

        Console.Write("Please type the ID of the table you would like to choose " +
            "followed by the time with a space in between (eg. 1 2:00PM): ");

        string input = Console.ReadLine();

        string[] idTime = input.Split(' ');

        int id = Convert.ToInt32(idTime[0]);

        string time = idTime[1];

        var findTable = a.freeTables.Where(o => (o.ID == id) && (o.time == time));

        Table chosenTable = findTable.First();

        for (int i = 0; i < a.freeTables.Count; i++)
        {
            Table t = a.freeTables[i];

            if (chosenTable.ID == t.ID && chosenTable.time == t.time)
            {
                a.freeTables.RemoveAt(i);
                a.AddReservedTables(t);
            }
        }

        Reservation r = new Reservation();

        r.SetTable(chosenTable);

        Console.Write("Please enter the day for your reservation (eg. Monday): ");

        string day = Console.ReadLine();

        r.SetDate(day);

        while (r.GetDate() == null)
        {
            Console.Write("Please enter the day for your reservation (eg. Monday): ");

            day = Console.ReadLine();

            r.SetDate(day);
        }

        r.SetNumOfGuests(size);

        Console.Write("Please enter the occasion for the reservation (eg. Business, Birthday, Anniversary or Regular): ");

        string occasion = Console.ReadLine();

        r.SetOccasion(occasion);

        while (r.GetOccasion() == null)
        {
            Console.Write("Please enter the occasion for the reservation (eg. Business, Birthday, Anniversary or Regular): ");

            occasion = Console.ReadLine();

            r.SetOccasion(occasion);
        }

        Console.Write("Please enter the room type you would like to have (Indoor or Outdoor): ");

        string type = Console.ReadLine();

        r.SetRoomType(type);

        while (r.GetRoomType() == null)
        {
           Console.Write("Please enter the room type you would like to have (Indoor or Outdoor): ");

           type = Console.ReadLine();

           r.SetRoomType(type);
        }

        Customer c = new Customer();

        Console.Write("Please enter your first and last name: ");

        string inputTwo = Console.ReadLine();

        string[] name = inputTwo.Split(' ');

        string firstName = name[0];

        string lastName = name[1];

        c.FirstName = firstName;

        c.LastName = lastName;

        Console.Write("Please enter your email: ");

        string email = Console.ReadLine();

        c.Email = email;

        Console.Write("Please enter your phone number: ");

        string number = Console.ReadLine();

        c.PhoneNumber = number;

        r.setCustomer(c);

        reservationList.Add(r);

        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine("Thank you for reserving with us! Below will be the " +
            "details of your reservation.");

        Thread.Sleep(3000);

        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine(r);

        Thread.Sleep(3000);

        Console.WriteLine();

        Console.WriteLine();

        Console.WriteLine();
    }

    static void ReservationList()
    {
        Console.WriteLine("---For Employees Only---");

        Console.WriteLine("Please login to view the reservation list.");

        Console.Write("Username: ");

        string username = Console.ReadLine();

        Console.Write("Password: ");

        string password = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine();

        if(username == "Sizzle" && password == "JuicySteaks")
        {
            for(int i = 0; i < reservationList.Count; i++)
            {
                Console.WriteLine(reservationList[i]);

                Console.WriteLine();

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Incorrect username or password. You will be returned to the start menu.");

            Console.WriteLine();

            Console.WriteLine();

            Thread.Sleep(3000);

            return;
        }
    }
}