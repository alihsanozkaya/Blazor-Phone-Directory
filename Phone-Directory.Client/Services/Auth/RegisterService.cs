using Models.Auth;
using Models.Response;
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
            return "Şifreler eşleşmedi.";
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
                return errorResponse?.Message ?? "Kayıt başarısız oldu.";
            }
        }
        catch (Exception ex)
        {
            return $"Bir hata oluştu: {ex.Message}";
        }
    }
}
