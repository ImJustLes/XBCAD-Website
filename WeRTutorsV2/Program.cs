using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;


namespace WeRTutorsV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Firebase
            try
            {
                // Map the path to the Firebase credentials file
                var firebaseCredentialPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "wertutors-v1-firebase-adminsdk-il2vg-5ba20ca7d4.json");

                // Initialize Firebase App
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(firebaseCredentialPath)
                });
                Console.WriteLine("Firebase initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Firebase initialization failed: {ex.Message}");
                throw; // rethrow to stop the app if Firebase fails to initialize
            }

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register IFirebaseClient for FireSharp
            builder.Services.AddSingleton<IFirebaseClient>(provider =>
            {
                IFirebaseConfig config = new FirebaseConfig
                {
                    AuthSecret = "Zhgb2srnouL9kwyuTmsCfqIo32zT3BKCASCDzRP7",  // Add your AuthSecret here
                    BasePath = "https://wertutors-v1-default-rtdb.firebaseio.com/"  // Add your Firebase database URL here
                };

                return new FirebaseClient(config);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
