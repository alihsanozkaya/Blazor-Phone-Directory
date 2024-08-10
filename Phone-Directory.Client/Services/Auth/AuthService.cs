using System.Threading.Tasks;
using Microsoft.JSInterop;

public class AuthService
{
    private readonly IJSRuntime _jsRuntime;

    public AuthService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "token");
        return !string.IsNullOrEmpty(token);
    }
}
