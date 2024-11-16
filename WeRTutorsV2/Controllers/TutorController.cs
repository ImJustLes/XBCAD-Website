using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using FirebaseAdmin;
using FireSharp.Interfaces;
using FireSharp.Response;
using WeRTutorsV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

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
        public async Task<IActionResult> TutorRecommendation(List<string> subjects, List<string> experiences, List<string> levels, List<string> languages, double clientLat, double clientLng)
        {
            try
            {
                Console.WriteLine($"Client Latitude: {clientLat}, Client Longitude: {clientLng}");
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

                // Further filter tutors based on proximity to the client
                var nearbyTutors = filteredTutors.Where(tutor => CalculateDistance(clientLat, clientLng, tutor.Latitude, tutor.Longitude) <= 50).ToList();  // 50 km radius

                if (nearbyTutors.Count == 0)
                {
                    ViewBag.Message = "No tutors found within the specified criteria and location.";
                }

                // Pass the filtered tutors and map data to the view
                ViewBag.TutorsForMap = nearbyTutors.Select(t => new { t.Name, t.Latitude, t.Longitude }).ToList();
                return View(nearbyTutors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching tutors: {ex.Message}");
                ViewBag.Message = $"Error searching tutors: {ex.Message}";
                return View(new List<TutorSignupModel>());
            }
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double RadiusOfEarthKm = 6371; // Earth radius in kilometers

            var latDistance = ToRadians(lat2 - lat1);
            var lonDistance = ToRadians(lon2 - lon1);
            var a = Math.Sin(latDistance / 2) * Math.Sin(latDistance / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(lonDistance / 2) * Math.Sin(lonDistance / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return RadiusOfEarthKm * c;
        }

        private double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
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
                        Location = model.Location,
                        Latitude = model.Latitude,
                        Longitude = model.Longitude,
                        PhoneNumber = model.PhoneNumber,
                        Subjects = model.Subjects,
                        TutoringExperience = model.TutoringExperience,
                        PreferredTeachingLevel = model.PreferredTeachingLevel,
                        Languages = model.Languages,
                        
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
                Location = TempData["Location"]?.ToString(),
                Subjects = TempData["Subjects"]?.ToString().Split(',').ToList(),
                TutoringExperience = TempData["TutoringExperience"]?.ToString(),
                PreferredTeachingLevel = TempData["PreferredTeachingLevel"]?.ToString(),
                Languages = TempData["Languages"]?.ToString().Split(',').ToList()
                
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
            TempData["Location"] = tutor.Location;
            TempData["Subjects"] = string.Join(",", tutor.Subjects); // Convert to comma-separated string
            TempData["TutoringExperience"] = tutor.TutoringExperience;
            TempData["PreferredTeachingLevel"] = tutor.PreferredTeachingLevel;
            TempData["Languages"] = string.Join(",", tutor.Languages); // Convert to comma-separated string
            

            return RedirectToAction("TutorProfile");
        }
    }
}
