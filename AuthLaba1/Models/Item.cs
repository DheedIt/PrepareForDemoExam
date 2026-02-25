namespace AuthLaba1.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		public List<Mark> Marks { get; set; } = new List<Mark>();

		public int TeacherId { get; set; }
		public Teacher Teacher { get; set; } = null!;

		public int StudentId { get; set; }
		public Student Student { get; set; } = null!;


	}
}
