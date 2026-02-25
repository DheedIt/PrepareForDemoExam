namespace AuthLaba1.Models
{
	public class Mark
	{
		public int Id { get; set; }
		public int Value { get; set; }
		public int ItemId { get; set; }
		public required Item Item { get; set; }
	}
}
