using Microsoft.EntityFrameworkCore;

namespace ControlPanel.Data
{
    public class MemoTestContext : DbContext
    {
        public MemoTestContext(DbContextOptions<MemoTestContext> options)
           : base(options)
        {

        }

        public DbSet<Models.MemoTest> MemoTest { get; set; }
    }
}
