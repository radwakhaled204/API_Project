using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API_PRO.Data.Models
{
    public class Files
    {
        [Key]
        public int FileId { get; set; } 
        public string? Filepath { get; set; }
        [ForeignKey("subject")]
        public int SubjectId { get; set; }

        public virtual Subject subject { get; set; }    
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
