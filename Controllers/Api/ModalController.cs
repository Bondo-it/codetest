using codetest.Models;
using codetest.MongoDB.DbBuilder;
using codetest.Repositories;
using codetest.Services;
using Microsoft.AspNetCore.Mvc;

namespace codetest.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModalController : ControllerBase
    {

        private readonly ViewRender view;

        public ModalController(ViewRender view)
        {
            this.view = view;
        }

        [HttpGet]
        public string Success()
        {
            var html = view.Render("Modal/success", new { Title = "Success", Message = "" });
            return html;
        }

        [HttpGet]
        public string Failed()
        {
            var html = view.Render("Modal/success", new { Title = "Success", Message = "" });
            return html;
        }

        [HttpGet]
        public string User(string id)
        {
            var userRepository = new BaseRepository<User>(new BaseDbBuilder());
            var user = userRepository.GetSingleByExpression(x => x.Id == id).Result;
            string html = view.Render("Modal/User", user);
            return html;
        }

        [HttpGet]
        public string Get(string viewType)
        {
            var viewPath = string.Format("Modal/{0}", viewType);

            var html = view.Render(viewPath, new { Title = "Success", Message = "" });
            return html;
        }
    }
}