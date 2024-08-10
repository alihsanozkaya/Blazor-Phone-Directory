using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Models.Directory;
using Models.Response;

public class DirectoryService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    private const string ApiUrl = "https://localhost:7002/api/Directory/";

    public DirectoryService(HttpClient httpClient, IJSRuntime jsRuntime)
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

    public async Task<DirectoryModel[]> GetDirectoriesByUserIdAsync(int userId)
    {
        await SetAuthorizationHeaderAsync();

        var response = await _httpClient.GetAsync($"{ApiUrl}getDirectoriesByUserId?userId={userId}");
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<DirectoryModel[]>>();
        return apiResponse?.Data ?? Array.Empty<DirectoryModel>();
    }

    public async Task<DirectoryModel> GetDirectoryByIdAsync(int id)
    {
        await SetAuthorizationHeaderAsync();

        var response = await _httpClient.GetAsync($"{ApiUrl}getDirectoryById?id={id}");
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<DirectoryModel>>();
        return apiResponse?.Data;
    }

    public async Task<DirectoryModel> AddDirectoryAsync(AddDirectoryModel addDirectoryModel)
    {
        await SetAuthorizationHeaderAsync();

        var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}addDirectory", addDirectoryModel);
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<DirectoryModel>>();
        return apiResponse?.Data;
    }

    public async Task<DirectoryModel> UpdateDirectoryAsync(UpdateDirectoryModel updateDirectoryModel)
    {
        await SetAuthorizationHeaderAsync();

        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}updateDirectory", updateDirectoryModel);
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<DirectoryModel>>();
        return apiResponse?.Data;
    }

    public async Task<string> DeleteDirectoryAsync(int id)
    {
        await SetAuthorizationHeaderAsync();

        var response = await _httpClient.DeleteAsync($"{ApiUrl}deleteDirectory?id={id}");
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
        return apiResponse?.Data ?? string.Empty;
    }
}
