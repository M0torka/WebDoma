namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        // Navigační vlastnost
        public List<Note> Notes { get; set; } = new();
    }
}