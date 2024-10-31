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
        public IActionResult TutorRecommendation()
        {
            return View(new List<TutorSignupModel>());
        }


        [HttpPost]
        public async Task<IActionResult> TutorRecommendation(List<string> subjects, List<string> experiences, List<string> levels, List<string> languages)
        {
            try
            {
                FirebaseResponse response = await _client.GetAsync("tempTutor");
                var tutorsData = response.ResultAs<Dictionary<string, TutorSignupModel>>();

                if (tutorsData == null || tutorsData.Count == 0)
                {
                    ViewBag.Message = "No tutors found.";
                    return View(new List<TutorSignupModel>());
                }

                var tutorsList = tutorsData.Values.ToList();

                // Filter tutors based on selected criteria
                var filteredTutors = tutorsList.Where(tutor =>
                    (subjects == null || subjects.Count == 0 || (tutor.Subjects != null && tutor.Subjects.Any(subject => subjects.Contains(subject)))) &&
                    (experiences == null || experiences.Count == 0 || (tutor.TutoringExperience != null && experiences.Contains(tutor.TutoringExperience))) &&
                    (levels == null || levels.Count == 0 || (tutor.PreferredTeachingLevel != null && levels.Contains(tutor.PreferredTeachingLevel))) &&
                    (languages == null || languages.Count == 0 || (tutor.Languages != null && tutor.Languages.Any(language => languages.Contains(language))))
                ).ToList();

                if (filteredTutors.Count == 0)
                {
                    ViewBag.Message = "No tutors match the search criteria.";
                }

                return View(filteredTutors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching tutors: {ex.Message}");
                ViewBag.Message = $"Error searching tutors: {ex.Message}";
                return View(new List<TutorSignupModel>());
            }
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
                    ViewBag.Message = $"Error creating user: {ex.Message}";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    ViewBag.Message = $"Unexpected error: {ex.Message}";
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



        [HttpGet]
        public IActionResult TutorProfile()
        {
            // Load profile data from TempData to display in the view
            var tutorProfile = new TutorSignupModel
            {
                Name = TempData["Name"]?.ToString(),
                Surname = TempData["Surname"]?.ToString(),
                Email = TempData["Email"]?.ToString(),
                PhoneNumber = TempData["PhoneNumber"]?.ToString(),
                Subjects = TempData["Subjects"]?.ToString().Split(',').ToList(),
                TutoringExperience = TempData["TutoringExperience"]?.ToString(),
                PreferredTeachingLevel = TempData["PreferredTeachingLevel"]?.ToString(),
                Languages = TempData["Languages"]?.ToString().Split(',').ToList(),
                Location = TempData["Location"]?.ToString()
            };

            return View(tutorProfile);
        }

        [HttpPost]
        public IActionResult SetTutorTempData(TutorSignupModel tutor)
        {
            TempData["Name"] = tutor.Name;
            TempData["Surname"] = tutor.Surname;
            TempData["Email"] = tutor.Email;
            TempData["PhoneNumber"] = tutor.PhoneNumber;
            TempData["Subjects"] = string.Join(",", tutor.Subjects); // Convert to comma-separated string
            TempData["TutoringExperience"] = tutor.TutoringExperience;
            TempData["PreferredTeachingLevel"] = tutor.PreferredTeachingLevel;
            TempData["Languages"] = string.Join(",", tutor.Languages); // Convert to comma-separated string
            TempData["Location"] = tutor.Location;

            return RedirectToAction("TutorProfile");
        }
    }
}
