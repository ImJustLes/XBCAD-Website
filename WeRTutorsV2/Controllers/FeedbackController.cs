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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a unique ID for each feedback using Guid
                    var feedbackId = Guid.NewGuid().ToString();

                    var feedbackData = new
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        Comment = model.Comment,
                        TutorName = model.TutorName,
                        Subject = model.Subject
                    };

                    // Store the feedback data in Firebase under the 'feedback' path
                    var response = await _firebaseClient.SetAsync($"feedback/{feedbackId}", feedbackData);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.Message = "Feedback submitted successfully!";
                    }
                    else
                    {
                        ViewBag.Message = "Failed to submit feedback!";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Error: {ex.Message}";
                }
            }

            return View();
        }
    }
}
