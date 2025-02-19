using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{
    public class SubjectDto
    {

        [Required]
        public string SubjectName { get; set; }
        public int NumExams { get; set; }
        public int TotalQuestions { get; set; }

    }
}
