using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace WebServer.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly ProtectedLocalStorage _localStorage;

        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ProtectedSessionStorage sessionStorage, ProtectedLocalStorage localStorage)
        {
            _sessionStorage = sessionStorage;
            _localStorage = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                //этот колхоз просто великолепен
                var userSessionStorageResult = await _localStorage.GetAsync<UserSession>("LocalUserSession");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                new Claim(ClaimTypes.Sid,userSession.Id),
                new Claim(ClaimTypes.Name,userSession.Nickname),
                new Claim(ClaimTypes.Email,userSession.Email),
                new Claim(ClaimTypes.Name,userSession.FirstName),
                }, "CustomAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                try
                {
                    var userSessionStorageResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                    var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;

                    if (userSession == null)
                    {
                        return await Task.FromResult(new AuthenticationState(_anonymous));
                    }
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
                    new Claim(ClaimTypes.Sid,userSession.Id),
                    new Claim(ClaimTypes.Name,userSession.Nickname),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Name,userSession.FirstName),
                }, "CustomAuth"));

                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }
                catch
                {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
            }
        }
        public async Task UpdateAuthenticationStateAsync(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)
            {
                await _localStorage.SetAsync("LocalUserSession", userSession);
                await _sessionStorage.SetAsync("UserSession", userSession);

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Sid,userSession.Id),
                    new Claim(ClaimTypes.Name,userSession.Nickname),
                    new Claim(ClaimTypes.Email,userSession.Email),
                    new Claim(ClaimTypes.Name,userSession.FirstName),
                }));

            }
            else
            {
                await _localStorage.DeleteAsync("LocalUserSession");
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anonymous;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}