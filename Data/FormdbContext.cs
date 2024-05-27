using Microsoft.EntityFrameworkCore;
using RegistrationForm.Domain;

namespace RegistrationForm.Data
{
    public class FormdbContext : DbContext
    {
        public FormdbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<FormData> FormDatas { get; set; }
    }
}
