using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Models.Auth;
using Models.Response;
using Phone_Directory.Constants;

public class LoginService
{
    private readonly HttpClient _httpClient;

    public LoginService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(string ErrorMessage, LoginResponse Response)> LoginUserAsync(LoginModel loginModel)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return (null, result);
            }
            else
            {
                return (Messages.LoginFailed, null);
            }
        }
        catch (Exception ex)
        {
            return (ex.Message, null);
        }
    }
}
