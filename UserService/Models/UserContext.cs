using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserService.Models
{
    public class UserContext(DbContextOptions<UserContext> options) : IdentityDbContext(options)
    {
    }
}
