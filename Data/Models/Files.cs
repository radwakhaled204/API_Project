using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API_PRO.Data.Models
{//12
    public class Files
    {
        [Key]
        public int FileId { get; set; }

        public string? FilePath { get; set; }  
        public string? FileName { get; set; }  
        [ForeignKey("Subject")]
        public int SubjectId { get; set; } 

        public virtual Subject Subject { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }  
    }

}
