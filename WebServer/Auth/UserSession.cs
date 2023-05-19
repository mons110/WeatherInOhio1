namespace WebServer.Auth
{
    public class UserSession
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool Auth { get; set; }
    }
}
