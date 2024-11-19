namespace WeRTutorsV2.Models
{
    public class SignupModel
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
