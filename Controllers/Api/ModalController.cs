using codetest.Repositories.Interfaces;
using codetest.Services;
using Microsoft.AspNetCore.Mvc;

namespace codetest.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModalController : ControllerBase
    {
        private readonly ViewRender _view;
        private readonly IUserRepository _userRepository;

        public ModalController(ViewRender view, IUserRepository userRepository)
        {
            _view = view;
            _userRepository = userRepository;
        }

        [HttpGet]
        public string Success()
        {
            var html = _view.Render("Modal/success", new { Title = "Success", Message = "" });
            return html;
        }

        [HttpGet]
        public string Failed()
        {
            var html = _view.Render("Modal/success", new { Title = "Success", Message = "" });
            return html;
        }

        [HttpGet]
        public string User(string id)
        {
            var user = _userRepository.GetSingleByExpression(x => x.Id == id).Result;
            var html = _view.Render("Modal/User", user);
            return html;
        }

        [HttpGet]
        public string Get(string viewType)
        {
            var viewPath = $"Modal/{viewType}";
            var html = _view.Render(viewPath, new { Title = "Success", Message = "" });
            return html;
        }
    }
}