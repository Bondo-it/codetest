using System.Diagnostics;
using System.Linq;
using codetest.Models;
using codetest.Models.ViewModels;
using codetest.MongoDB.DbBuilder;
using codetest.Repositories;
using codetest.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace codetest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index ()
        {
            var userRepository = new BaseRepository<User> (new BaseDbBuilder ());
            var users = userRepository.GetAllSync ();
            if (!users.Any ())
            {
                var usersFromJson = new GetUsersFromJson ("users.json").Execute ();
                userRepository.AddManySync (usersFromJson);
                users = usersFromJson.ToList ();
            }
            return View ("Users", new UsersViewModel { Users = users.ToList () });
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error ()
        {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}