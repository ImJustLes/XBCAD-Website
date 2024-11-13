using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using WeRTutorsV2.Models;

namespace WeRTutorsV2.Controllers
{
    public class AuthController : Controller
    {

        // Initialize Firebase configuration
        private static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "AIzaSyBt8zopSMcOQ2aom2DKw8zJui8Ni0QB2Sc",  // Replace with your database secret
            BasePath = "https://wertutors-v2-default-rtdb.firebaseio.com/"  // Replace with your database URL
        };

        private IFirebaseClient client;

        public AuthController()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client == null)
            {
                throw new System.Exception("Cannot connect to Firebase.");
            }
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ViewBag.Message = "Passwords do not match!";
                    return View();
                }

                try
                {
                    // Create Firebase user
                    var user = await FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
                    {
                        Email = model.Email,
                        Password = model.Password,
                        DisplayName = $"{model.Name} {model.Surname}",
                    });

                    // Add user details to Firebase Realtime Database under "client" path
                    var userDetails = new
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email
                    };

                    // Save user to Firebase Realtime Database under "client" path
                    SetResponse response = await client.SetAsync($"client/{user.Uid}", userDetails);
                    ViewBag.Message = "User registered successfully!";
                    return RedirectToAction("Login", "Auth");
                }
                catch (FirebaseAuthException ex)
                {
                    ViewBag.Message = $"Error: {ex.Message}";
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Authenticate user using Firebase Authentication
                    var user = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(model.Email);

                    // Firebase does not natively provide password check, you need to handle it with your own verification or use Firebase Authentication SDK for user sign-in.
                    if (user != null)
                    {
                        ViewBag.Message = "Login successful!";
                        return RedirectToAction("Index", "ClientDashboard");  // Go to the dashboard after login
                    }
                }
                catch (FirebaseAuthException ex)
                {
                    ViewBag.Message = $"Error: {ex.Message}";
                }
            }

            ViewBag.Message = "Invalid login credentials!";
            return View();
        }
    }
}
