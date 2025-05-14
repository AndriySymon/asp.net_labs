namespace CharitySystem.Models
{
	public class EventRegistrationModel
	{
        public int Id { get; set; }
        public int EventId { get; set; }
		public string EventTitle { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
