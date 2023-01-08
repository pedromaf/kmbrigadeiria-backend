using Microsoft.EntityFrameworkCore;

namespace KMBrigadeiria.Data
{
    public class KMContext : DbContext
    {
        public KMContext(DbContextOptions<KMContext> opt) : base(opt)
        {

        }

    }
}
