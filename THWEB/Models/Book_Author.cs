using System.ComponentModel.DataAnnotations;

namespace THWEB.Models
{
    public class Book_Author
    {
        [Key] public int Id { get; set; }
        public Books? Book { get; set; }
        public int? BookId { get; set;}
        public Authors? Authors { get; set; }
        public int? AuthorId { get; set; }
    }
}
