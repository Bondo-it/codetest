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

namespace codetest.Controllers.Api
{
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

        [HttpPut]
        public JsonResult Add(User user)
        {
            _userRepository.AddSync(user);
            return new JsonResult(new { success = true, responseText = "User successfuly added!" });
        }

        [HttpPatch]
        public JsonResult Change(string id, User user)
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
