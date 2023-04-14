namespace WeatherInOhio.Contracts.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }

        public string Nickname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phonenumber { get; set; }

        public bool Auth { get; set; }

        public bool IsAdmin
        {
            get; set;
        }
    }
}
