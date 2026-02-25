namespace AuthLaba1.Models
{
	public class Student : User
	{
		public required List<Item> Items { get; set; }
		public required string Name { get; set; }
		public required int GroupId { get; set; }
		public required Group Group { get; set; }
	}
}
