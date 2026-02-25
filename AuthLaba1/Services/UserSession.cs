namespace AuthLaba1.Services
{
	public class UserSession
	{
		public int UserId { get; set; }
		public required string UserName { get; set; }
		public required string Role { get; set; }

		public event Action? OnSessionChanged;
		public void SetSession(int userId, string userName, string role)
		{
			UserId = userId;
			UserName = userName;
			Role = role;
			NotifySessionChanged();
		}
		private void NotifySessionChanged()
		{
			OnSessionChanged?.Invoke();
		}
	}
}
