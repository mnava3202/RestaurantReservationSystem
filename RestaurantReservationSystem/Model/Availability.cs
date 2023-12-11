using System;
namespace RestaurantReservationSystem.Model
{
	// the Availability class is created
	public class Availability
	{
		// a list that has Table objects that called freeTables, represents all the free tables available
		public List<Table> freeTables;

		// a list that has Table objects called reservedTables, represents all the reserved tables
		public List<Table> reservedTables; 

		// a class constructor that initializes freeTables and reservedTables
		public Availability()
		{
			freeTables = new List<Table>();

			reservedTables = new List<Table>();
		}

		//a method that adds a Table object to the list freeTables
		public void AddFreeTable(Table t)
		{
			freeTables.Add(t);
		}

		// a method that returns the list freeTables
		public List<Table> GetFreeTables()
		{
			return freeTables;
		}

		// a method that adds a Table object to the list reservedTables
		public void AddReservedTables(Table t)
		{
			reservedTables.Add(t);
		}

		// a method that returns the list reservedTables
		public List<Table> GetReservedTables()
		{
			return reservedTables;
		}
    }
}

