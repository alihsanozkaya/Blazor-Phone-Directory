using Microsoft.JSInterop;
using Models.Directory;
using Models.Response;
using Models.User;
using System.Net.Http.Json;

namespace Services.User
{
    public class UpdateService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private const string ApiUrl = "https://localhost:7002/api/User/";

        public UpdateService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        private async Task SetAuthorizationHeaderAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<UserModel> UpdateUserAsync(UpdateUserModel updateUserModel)
        {
            await SetAuthorizationHeaderAsync();
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}updateUser", updateUserModel);
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<UserModel>>();
            return apiResponse?.Data;
        }

    }
}
