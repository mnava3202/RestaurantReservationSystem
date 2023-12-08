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

		public void AddFreeTable(Table t)
		{
			freeTables.Add(t);
		}

		public List<Table> GetFreeTables()
		{
			return freeTables;
		}

		public void AddReservedTables(Table t)
		{
			reservedTables.Add(t);
		}

		public List<Table> GetReservedTables()
		{
			return reservedTables;
		}
    }
}

