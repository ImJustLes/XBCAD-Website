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
                        Email = model.Email,
                        Phone = model.Phone,
                        Location = model.Location,
                        Latitude = model.Latitude,
                        Longitude = model.Longitude
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
                    // Firebase Authentication REST API endpoint
                    string firebaseAuthUrl = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBt8zopSMcOQ2aom2DKw8zJui8Ni0QB2Sc"; // Replace with your API key

                    var payload = new
                    {
                        email = model.Email,
                        password = model.Password,
                        returnSecureToken = true
                    };

                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsJsonAsync(firebaseAuthUrl, payload);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadFromJsonAsync<FirebaseLoginResponse>();
                            
                            // Store UID in session
                            HttpContext.Session.SetString("UserId", responseData.LocalId);

                            // Authentication successful
                            TempData["PopupMessage"] = "Login successful!";
                            return RedirectToAction("Index", "ClientDashboard"); // Redirect to the dashboard
                            
                        }
                        else
                        {
                            var errorResponse = await response.Content.ReadAsStringAsync();
                            dynamic errorData = JObject.Parse(errorResponse);
                            string errorMessage = errorData.error.message;

                            TempData["PopupMessage"] = $"Invalid login credentials!. Please try again";
                        }
                    }
                }
                catch (Exception ex)
                {
                    TempData["PopupMessage"] = $"Error: {ex.Message}";
                }
            }
            else
            {
                TempData["PopupMessage"] = "Invalid login credentials!";
            }

            return View();
        }
    }

    // Strongly-typed class for Firebase login response
    public class FirebaseLoginResponse
    {
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
        public string LocalId { get; set; }
    }

}
