using DomainModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using DataComponent.Repositories.Interfaces;
using Specification.Specifications;
using Microsoft.Extensions.Logging;

namespace Frontend.Controllers.Api
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly ILogger<UserController> _log;

		public UserController(ILogger<UserController> logger, IUserRepository userRepository)
		{
			_log = logger ?? throw new ArgumentNullException(nameof(logger));
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		[HttpGet]
		public JsonResult Get()
		{
			var users = _userRepository.GetAllSync();
			return new JsonResult(users);
		}

		[HttpPost]
		public JsonResult Add([FromBody] User user)
		{
			if (!new UserSpecification().IsSatisfiedBy(user))
			{
				throw new ArgumentException("User not valid.");
			}
			if (_userRepository.AnySync(x =>
				x.Email == user.Email ||
				x.UserName == user.UserName))
			{
				throw new ArgumentException("User email or username already taken.");
			}
			_userRepository.AddSync(user);
			return new JsonResult(new { success = true, responseText = "User successfully added!" });
		}

		[HttpPatch]
		public JsonResult Change(string id, [FromBody] User user)
		{
			_userRepository.ReplaceOneSync(id, user);
			return new JsonResult(new { success = true, responseText = "User successfully modified!" });
		}

		[HttpDelete]
		public JsonResult Delete(string id)
		{
			_userRepository.DeleteSync(x => x.Id == id);
			return new JsonResult(new { success = true, responseText = "User successfully deleted!" });
		}
	}
}
