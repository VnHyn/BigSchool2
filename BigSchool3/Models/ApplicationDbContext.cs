using System.Data.Entity;

namespace BigSchool3.Models
{
    public interface IApplicationDbContext
    {
       DbSet<Category> Categories { get; set; }
       DbSet<Course> Courses { get; set; }
    }
}