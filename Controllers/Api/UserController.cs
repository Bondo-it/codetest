using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using codetest.Models;
using codetest.MongoDB.DbBuilder;
using codetest.Repositories;
using codetest.Utilities;
using codetest.Models.ViewModels;
using System.Linq.Expressions;
using codetest.MongoDB;
using codetest.Specification;

namespace codetest.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly BaseRepository<User> _userRepository;

        public UserController()
        {
            _userRepository = new BaseRepository<User>(new BaseDbBuilder());
        }

        [HttpGet]
        public JsonResult Get()
        {
            var users = _userRepository.GetAllSync();
            return new JsonResult(users);
        }

        [HttpPost]
        public JsonResult Add([FromBody]User user)
        {
            if (!new UserSpecification().IsSatisfiedBy(user))
            {
                throw new ArgumentException("User not valid.");
            }
            if (_userRepository.AnySync(x =>
                x.Email == user.Email ||
                x.UserName == user.UserName))
            {
                throw new ArgumentException("Users email og username allready taken.");
            }
            _userRepository.AddSync(user);
            return new JsonResult(new { success = true, responseText = "User successfuly added!" });
        }

        [HttpPatch]
        public JsonResult Change(string id, [FromBody]User user)
        {
            _userRepository.ReplaceOneSync(id, user);
            return new JsonResult(new { success = true, responseText = "User successfuly modified!" });
        }

        [HttpDelete]
        public JsonResult Delete(string id)
        {
            _userRepository.DeleteSync(x => x.Id == id);
            return new JsonResult(new { success = true, responseText = "User successfuly deleted!" });
        }
    }
}
