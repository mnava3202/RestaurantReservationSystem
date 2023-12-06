using System;
namespace RestaurantReservationSystem.Model
{
	public class Availability
	{
		public List<Table> freeTables;

		public List<Table> reservedTables; 

		public Availability()
		{
			freeTables = new List<Table>();

			reservedTables = new List<Table>();
		}

		public void addFreeTable(Table t)
		{
			freeTables.Add(t);
		}

		public List<Table> getFreeTables()
		{
			return freeTables;
		}

		public void addReservedTables(Table t)
		{
			reservedTables.Add(t);
		}

		public List<Table> getReservedTables()
		{
			return reservedTables;
		}
	}
}

