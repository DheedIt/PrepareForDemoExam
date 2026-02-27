namespace AuthLaba1.Models.Dto
{
	public class ItemMarksDto
	{
		public required int Id { get; set; }
		public required string ItemName { get; set; }
		public List<Mark>? Mark { get; set; }
	}
}
