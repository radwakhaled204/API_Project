using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API_PRO.Data.Models
{
    public class Files
    {
        [Key]
        public int FileId { get; set; }

        public string? FilePath { get; set; }  // مسار الملف المخزن
        public string? FileName { get; set; }  // اسم الملف الأصلي

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }  // مفتاح خارجي

        public virtual Subject Subject { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }  // لن يتم تخزينه في قاعدة البيانات
    }

}
