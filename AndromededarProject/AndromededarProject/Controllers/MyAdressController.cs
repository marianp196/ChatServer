using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Adresses;
using Andromedarproject.Users.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndromededarProject.Web.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class MyAdressController : ControllerBase
	{
		public MyAdressController(IUserReader userReader)
		{
			_userReader = userReader ?? throw new ArgumentNullException(nameof(userReader));
		}

		[HttpGet]
		public async Task<MyAdressInfo> GetMyAdressInfo()
		{
			var userName = User.Identity.Name;
			var userResult = await _userReader.GetUserByUserName(userName);
			if (!userResult.Success)
				BadRequest("User not found");
			if (userResult.Value?.Adress == null)
				BadRequest("No Adress");

			return new MyAdressInfo { Adress = userResult.Value.Adress };
		}

		private readonly IUserReader _userReader;

	}

	public class MyAdressInfo
	{
		public Adress Adress { get; set; }
	}

}