using FirebaseAdmin.Auth;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WeRTutorsV2.Models;
using System.Threading.Tasks;
using System;

namespace WeRTutorsV2.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFirebaseClient _firebaseClient;

        public FeedbackController(IFirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                FirebaseResponse response = await _firebaseClient.GetAsync("tempTutor");
                var tutorNames = new List<string>();

                if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Body != "null")
                {
                    var tutorsData = response.ResultAs<JObject>();

                    foreach (var tutor in tutorsData)
                    {
                        string name = (string)tutor.Value["Name"];
                        string surname = (string)tutor.Value["Surname"];
                        tutorNames.Add($"{name} {surname}");
                    }
                }

                ViewBag.TutorNames = tutorNames;
            }
            catch (Exception ex)
            {
                ViewBag.TutorNames = new List<string>();  // In case of any error, initialize with an empty list
                Console.WriteLine($"Error retrieving tutors: {ex.Message}");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var feedbackId = Guid.NewGuid().ToString();

                    var feedbackData = new
                    {
                        Comment = model.Comment,
                        Rating = model.Rating,
                        TutorName = model.TutorName,
                        Subject = model.Subject
                    };

                    var response = await _firebaseClient.SetAsync($"feedback/{feedbackId}", feedbackData);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.Success = true; // Indicate successful submission
                    }
                    else
                    {
                        ViewBag.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Success = false;
                    ViewBag.Message = $"Error: {ex.Message}";
                }
            }

            return View();
        }
    }
}
