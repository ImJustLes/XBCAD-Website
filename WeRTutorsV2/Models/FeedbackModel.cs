namespace WeRTutorsV2.Models
{
    public class FeedbackModel
    {
        public string TutorName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } // Add Rating field
        public List<string> Subject { get; set; }
    }
}
