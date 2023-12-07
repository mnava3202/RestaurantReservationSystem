using RestaurantReservationSystem.Model;

namespace RestaurantReservationSystem;

internal class Program
{
    static void Main(string[] args)
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

        Availability a = new Availability();

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

        Console.WriteLine("Hello! Thank you for choosing us for your dining needs.");

        Console.Write("Please enter the size of your party: ");

        int size = Convert.ToInt32(Console.ReadLine());

        while (size != -1)
        {
            Console.WriteLine("These are the available tables:");


            for (int i = 0; i < a.freeTables.Count; i++)
            {
                if (a.freeTables[i].SeatingCapacity > size)
                {
                    Console.WriteLine(a.freeTables[i]);
                }
            }


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

            Console.Write("Please enter the occasion for the reservation (eg. Business, Birthday, Anniversaty or Regular): ");

            string occasion = Console.ReadLine();

            r.SetOccasion(occasion);

            while (r.GetOccasion() == null)
            {
                Console.Write("Please enter the occasion for the reservation (eg. Business, Birthday, Anniversaty or Regular): ");

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

            Console.WriteLine("Thank you for reserving with us! Below will be the " +
                "details of your reservation. The reservation process will be repeated. " +
                "If you like to exit the program, please enter '-1' when prompted " +
                "to enter the size of your party.");

            Thread.Sleep(5000);

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine(r);

            Thread.Sleep(5000);

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Hello! Thank you for choosing us for your dining needs.");

            Console.Write("Please enter the size of your party: ");

            size = Convert.ToInt32(Console.ReadLine());
        }
    }
}