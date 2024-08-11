using Microsoft.JSInterop;
using Models.Response;
using Models.User;
using Phone_Directory.Constants;
using System.Net.Http.Json;

namespace Services.User
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private const string ApiUrl = "https://localhost:7002/api/User/";

        public UserService(HttpClient httpClient, IJSRuntime jsRuntime)
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

        public async Task<UserModel> GetUserAsync(int id)
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.GetAsync($"{ApiUrl}getUser?id={id}");
            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<UserModel>>();
            return apiResponse?.Data;
        }

        public async Task<(UserModel User, bool Success, string Message)> UpdateUserAsync(UpdateUserModel updateUserModel)
        {
            await SetAuthorizationHeaderAsync();

            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}updateUser", updateUserModel);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<UserModel>>();

            if (response.IsSuccessStatusCode && apiResponse != null)
            {
                return (apiResponse.Data, true, apiResponse.Message);
            }
            else
            {
                return (null, false, apiResponse?.Message ?? Messages.UpdateFailed);
            }
        }

    }
}
