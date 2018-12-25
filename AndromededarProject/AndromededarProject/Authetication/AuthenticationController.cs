using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndromededarProject.Web.Authetication
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
		[HttpPost]
		public async Task Post(AuthenticationDto authenticationDto)
		{			
			
			var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, authenticationDto.Name),
					new Claim(ClaimTypes.Role, "User"),
				};

			var claimsIdentity = new ClaimsIdentity(
				claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var authProperties = new AuthenticationProperties
			{
				//AllowRefresh = <bool>,
				// Refreshing the authentication session should be allowed.

				//ExpiresUtc = DateTimeOffset.UtcNow.AddYears(300),
				// The time at which the authentication ticket expires. A 
				// value set here overrides the ExpireTimeSpan option of 
				// CookieAuthenticationOptions set with AddCookie.

				IsPersistent = true,
				
				// Whether the authentication session is persisted across 
				// multiple requests. Required when setting the 
				// ExpireTimeSpan option of CookieAuthenticationOptions 
				// set with AddCookie. Also required when setting 
				// ExpiresUtc.

				//IssuedUtc = <DateTimeOffset>,
				// The time at which the authentication ticket was issued.

				//RedirectUri = <string>
				// The full path or absolute URI to be used as an http 
				// redirect response value.
				
			};

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties);
		}
    }
}