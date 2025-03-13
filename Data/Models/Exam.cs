using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_PRO.Data.Models
{
    public class Exam
    {

            [Key]
            public int ExamId { get; set; }
       //change the name in data and set another type 
            [Column("exam_name" , TypeName ="varchar(20)")]
            [Required]
            public required string ExamName { get; set; }

            public string QuestionType { get; set; }

            public int NumQuestions { get; set; }

            public int? NumCorrectQuestions { get; set; }

            public int? NumWrongQuestions { get; set; }

            public string DifficultyLevel { get; set; }

            public string? McqQuestionsData { get; set; }

            public string? TfQuestionsData { get; set; }

            public TimeOnly? TimeTaken { get; set; }

            public int? TotalScore { get; set; }

            public int XpCollected { get; set; }
            public DateTime CreatedDate { get; set; }

            //we must to make the forign key nullable to avoid migrations problem
            [ForeignKey("FileId")]
            public int? FileId { get; set; }
         
            public virtual Files? File { get; set; }
            public int UserId { get; set; }

            public int SubjectId { get; set; }


        public virtual Subject? Subject { get; set; }

        public virtual Users? User { get; set; }
        }
    
}
