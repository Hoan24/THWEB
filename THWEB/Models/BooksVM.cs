using System.ComponentModel.DataAnnotations;

namespace THWEB.Models
{
    public class BooksVM
    {
        public int BookId { get; set; }
       
        public string Title { get; set; }
      
        public string Description { get; set; }

        public bool? IsRead { get; set; }

        public DateTime Dateread { get; set; }
   
        public int Rate { get; set; }
       
        public int Genre { get; set; }
       
        public string CoverUrl { get; set; }
        
        public DateTime DateAdded { get; set; }
        public int PublisherId { get; set; }
    }
}
