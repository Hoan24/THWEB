using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace THWEB.Models
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool? IsRead {  get; set; }
        [Required]
        public DateTime Dateread { get; set; }
        [Required]
        public int Rate {  get; set; }
        [Required]
        public int Genre {  get; set; }
        [Required]
        public string CoverUrl { get; set;}
        [Required]
        public DateTime DateAdded {  get; set; }
        
        public Publishers? Publishers { get; set; }
        public int PublisherId { get; set; }
        public List<Book_Author> Book_Authors { get; set; }

    }

}