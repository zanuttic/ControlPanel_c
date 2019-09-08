using Microsoft.EntityFrameworkCore;

namespace ControlPanel.Data
{
    public class ControlPanelContext : DbContext
    {
        public ControlPanelContext (DbContextOptions<ControlPanelContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Juego> Juego { get; set; }
    }
}
