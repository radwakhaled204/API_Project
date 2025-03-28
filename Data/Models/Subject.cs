﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace API_PRO.Data.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Column("sub_name", TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Please Enter Subject Name")]
        public required string SubjectName { get; set; }

        public int NumExams { get; set; } = 0;

        public int TotalQuestions { get; set; } = 0;




        //public required int UserId { get; set; }

        //public ICollection<Exam> Exams { get; set; } = new List<Exam>();

        //[Required]
        //public required User User { get; set; }
    }
}
