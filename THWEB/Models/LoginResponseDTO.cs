using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace THWEB.Models
{
    public class LoginResponseDTO
    {
        public string JwtToken { set; get; }
    }
}
