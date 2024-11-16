using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WeRTutorsV2.Models
{
    public class TutorSignupModel
    {

        //public string Uid { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Subjects { get; set; } // Update this to a list to handle multiple subjects

        [Required]
        
        public string TutoringExperience { get; set; }

        [Required]
        
        public string PreferredTeachingLevel { get; set; }

        [Required]
        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Languages { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } // Add Password field

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } // Add ConfirmPassword field for validation
    }
}
