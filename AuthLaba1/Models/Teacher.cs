namespace AuthLaba1.Models
{
	public class Teacher : User
	{
		public required string Name { get; set; }
		public required List<Item> Items { get; set; }

	}
}
