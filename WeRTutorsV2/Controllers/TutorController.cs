using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin;
using FireSharp.Interfaces;
using FireSharp.Response;
using WeRTutorsV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeRTutorsV2.Controllers
{
    public class TutorController : Controller
    {
        private readonly IFirebaseClient _client;

        public TutorController(IFirebaseClient client)
        {
            _client = client ?? throw new System.Exception("Cannot connect to Firebase.");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(TutorSignupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a new user in Firebase Authentication
                    var user = await FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
                    {
                        Email = model.Email,
                        Password = model.Password,
                        DisplayName = $"{model.Name} {model.Surname}"
                    });

                    // Set up tutor details to store in the Realtime Database
                    var tutorDetails = new TutorSignupModel
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Subjects = model.Subjects,
                        TutoringExperience = model.TutoringExperience,
                        PreferredTeachingLevel = model.PreferredTeachingLevel,
                        Languages = model.Languages,
                        Location = model.Location
                    };

                    // Store the tutor details under the user's UID in Firebase
                    await _client.SetAsync($"tempTutor/{user.Uid}", tutorDetails);
                    ViewBag.Message = "Tutor registered successfully!";
                }
                catch (FirebaseAuthException ex)
                {
                    ViewBag.Message = $"Error: {ex.Message}";
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllTutors()
        {
            try
            {
                // Retrieve all tutor data from Firebase
                FirebaseResponse response = await _client.GetAsync("tempTutor");

                // Deserialize response to dictionary
                var tutorsData = response.ResultAs<Dictionary<string, TutorSignupModel>>();

                if (tutorsData == null || tutorsData.Count == 0)
                {
                    ViewBag.Message = "No tutors found.";
                    return View(new List<TutorSignupModel>());
                }

                // Convert dictionary values to a list and pass it to the view
                var tutorsList = tutorsData.Values.ToList();
                return View(tutorsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tutors: {ex.Message}");
                ViewBag.Message = $"Error fetching tutors: {ex.Message}";
                return View(new List<TutorSignupModel>());
            }
        }
    }
}
