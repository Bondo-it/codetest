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

namespace codetest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var userRepository = new BaseRepository<User>(new BaseDbBuilder());
            var users = userRepository.GetAllSync();
            if (!users.Any())
            {
                var usersFromJson = new GetUsersFromJson("users.json").Execute();
                userRepository.AddManySync(usersFromJson);
                users = usersFromJson.ToList();
            }
            return View("Users", new UsersViewModel { Users = users.ToList() });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
