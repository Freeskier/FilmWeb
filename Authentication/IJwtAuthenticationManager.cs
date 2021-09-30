namespace Backend.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string name, int ID);
    }
} 