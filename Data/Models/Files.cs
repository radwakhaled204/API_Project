﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API_PRO.Data.Models
{
    public class Files
    {
        [Key]
        public int FileId { get; set; }

        public string? FilePath { get; set; }  
        [Required(ErrorMessage ="Please Enter File Name")]
        public string? FileName { get; set; }  
        [ForeignKey("Subject")]
        public int SubjectId { get; set; } 

        public virtual Subject Subject { get; set; }
        // don't add it in database
        [NotMapped]
        public IFormFile File { get; set; }  
    }

}
