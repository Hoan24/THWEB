using System.ComponentModel.DataAnnotations;

namespace THWEB.Models
{
    public class Authors
    {
        [Key] public int AuthorId { get; set; }
        [Required]
        public string FullName { get; set; }
        public List<Book_Author> Book_Authors { get; set; }
    }
}
