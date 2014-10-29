using Microsoft.AspNet.Identity.EntityFramework;

namespace Test1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Test1.Models.MyTestModel> MyTestModels { get; set; }
    }
}