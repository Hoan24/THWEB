using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THWEB.Models
{
    public class Publishers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }
        public string Name {  get; set; }
        public List<Books>? Books { get; set; }
    }
}
