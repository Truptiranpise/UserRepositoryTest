using System.Web.Mvc;
using UserRepositories.Models;

namespace UserRepositories.Controllers
{
    public class UserRepositoriesController : Controller
    {
        private UserRepositoryAPIWrapper userRepositoryAPIWrapper;
        private const int TopRepositoriesCount = 5;
        
        public ActionResult GetUserRepositories()
        {
           return View();
        }

        [HttpPost]
        public ActionResult GetUserRepositories(string name)
        {
            userRepositoryAPIWrapper = new UserRepositoryAPIWrapper();
            var user = userRepositoryAPIWrapper.GetRepositories(name, TopRepositoriesCount);

            ViewBag.result = user;
            return View();
        }

        
    }
}
