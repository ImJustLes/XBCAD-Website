using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using WeRTutorsV2.Models;

namespace WeRTutorsV2.Controllers
{
    public class ClientDashboardController : Controller
    {
        // Initialize Firebase configuration
        private static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "AIzaSyBt8zopSMcOQ2aom2DKw8zJui8Ni0QB2Sc",  // Replace with your database secret
            BasePath = "https://wertutors-v2-default-rtdb.firebaseio.com/"  // Replace with your database URL
        };

        private IFirebaseClient client;

        public ClientDashboardController()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {
                throw new System.Exception("Cannot connect to Firebase.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> clientProfile()
        {
            string userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth"); // Redirect to login if UserId is missing
            }
            FirebaseResponse response = await client.GetAsync($"client/{userId}");
            var userData = response.ResultAs<ProfileModel>();

            return View(userData);
        }
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
