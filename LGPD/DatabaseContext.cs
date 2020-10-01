using Microsoft.EntityFrameworkCore;

namespace LGPD
{
    // DatabaseContext
    public class DatabaseContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(
                    @"Server=(local);Integrated Security=True; Database=EFCoreValueConvertion; MultipleActiveResultSets=true;"
                );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder
            //    .Entity<Cliente>()                
            //    .HasOne(h => h.EmpresaNavigation)
            //    .WithMany(w => w.ClienteNavigationList)
            //    .HasForeignKey(f => f.EmpresaId)
            //    .OnDelete(DeleteBehavior.NoAction)
            //    .IsRequired(false); ;

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    var attributes = property
                        .PropertyInfo
                        .GetCustomAttributes(typeof(SensitiveDataAttribute), false);

                    if (attributes.Length > 0)
                    {
                        property.SetValueConverter(new DataProtectionConverter());
                    }
                }
            }
        }
    }
}