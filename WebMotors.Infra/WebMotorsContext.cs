using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using WebMotors.Domain;
using WebMotors.Domain.Entities;

namespace WebMotors.Infra
{
    public class WebMotorsContext : DbContext
    {
        public DbSet<AnuncioWebmotors> AnuncioWebmotors { get; set; }

        public WebMotorsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebMotorsContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
