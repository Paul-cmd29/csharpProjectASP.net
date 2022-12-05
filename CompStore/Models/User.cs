using Microsoft.AspNetCore.Identity;

namespace CompStore.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
