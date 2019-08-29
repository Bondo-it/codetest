using codetest.Models;
using codetest.Models.ViewModels;
using codetest.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using codetest.Repositories.Interfaces;

namespace codetest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public IActionResult Index()
        {
            var users = _userRepository.GetAllSync();

            if (users.Any())
                return View("Users", new UsersViewModel {Users = users.ToList()});

            var usersFromJson = new GetUsersFromJson("users.json").Execute();
            _userRepository.AddManySync(usersFromJson);
            users = usersFromJson.ToList();

            return View("Users", new UsersViewModel { Users = users.ToList() });
        }

        public IActionResult CreateUser()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        [HttpDelete]
        public JsonResult Delete(string id)
        {
            _userRepository.DeleteSync(x => x.Id == id);
            return new JsonResult(new { success = true, responseText = "User successfully deleted!" });
        }
    }
}