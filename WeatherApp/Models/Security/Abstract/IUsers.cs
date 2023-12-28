namespace WeatherApp.Models.Security.Abstract
{
    public interface IUsers
    {
        bool isUnique(string username);
        LoginResponse  Login(LoginRequest loginRequest); 
        UsersModel Registration (RegistrationRequest registrationRequest);  
    }
}
