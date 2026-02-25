namespace AuthLaba1.Models
{
	public class Group
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public List<Student> Students { get; set; } = new List<Student>();
	}
}
