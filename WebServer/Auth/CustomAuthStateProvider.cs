using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace WebServer.Auth
{
	public class CustomAuthStateProvider: AuthenticationStateProvider
    {
		private readonly ProtectedSessionStorage _sessionStorage;
		private readonly ProtectedLocalStorage _localStorage
    }
}
