using System.ComponentModel.DataAnnotations;

namespace API_PRO.Models
{
    public class SubjectDto
    {

        [Required(ErrorMessage = "Enter The Name")]
        public string SubjectName { get; set; }
        //num of exam
        public int NumExams { get; set; }
        public int TotalQuestions { get; set; }

    }
}
