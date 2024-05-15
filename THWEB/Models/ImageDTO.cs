using System.ComponentModel.DataAnnotations;

namespace THWEB.Models
{
    public class ImageDTO
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]

        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; }
    }
}
