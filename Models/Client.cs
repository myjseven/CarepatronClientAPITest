namespace CarepatronClientAPITest.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}
