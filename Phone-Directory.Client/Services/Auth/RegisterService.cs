using Models.Auth;
using Models.Response;
using Phone_Directory.Constants;
using System.Net.Http.Json;

public class RegisterService
{
    private readonly HttpClient _httpClient;

    public RegisterService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> RegisterUserAsync(RegisterModel registerModel)
    {
        if (registerModel.Password != registerModel.ConfirmPassword)
        {
            return Messages.PasswordNotMatch;
        }

        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", registerModel);

            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                return errorResponse?.Message ?? Messages.RegisterFailed;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
