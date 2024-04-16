using System.ComponentModel.DataAnnotations;

namespace THWEB.Models
{
    public class AuthorVM
    {
        public int AuthorId { get; set; }
        
        public string FullName { get; set; }
    }
}
