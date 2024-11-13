using Microsoft.AspNetCore.Mvc;
using WeRTutorsV2.Models;

namespace WeRTutorsV2.Controllers
{
    public class ClientDashboardController : Controller
    {
        public IActionResult Index()
        {

            var model = new ClientDashboardModel
            {
                WelcomeMessage = "Welcome to the dashboard"
            };
            return View(model);
        }
    }
}
