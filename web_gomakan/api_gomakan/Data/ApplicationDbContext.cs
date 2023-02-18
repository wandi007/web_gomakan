using libs_gomakan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api_gomakan.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Makanan>(entity =>
            {
                entity.ToTable("makanan","public");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Image).HasColumnName("image");
                
                entity.HasMany<Pesanan>(e => e.Pesanans).WithOne();
                entity.Navigation(e => e.Pesanans).UsePropertyAccessMode(PropertyAccessMode.Property);

            });
            modelBuilder.Entity<Pesanan>(entity =>
            {
                entity.ToTable("pesanan","public");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Qty).HasColumnName("qty");
                entity.Property(e => e.Total).HasColumnName("total");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.MakananId).HasColumnName("makanan_id");
                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.HasOne<Makanan>(e => e.Makanan)
                    .WithMany(e => e.Pesanans)
                    .HasForeignKey(e=>e.MakananId);
                entity.Navigation(e => e.Makanan).UsePropertyAccessMode(PropertyAccessMode.Property);
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.ToTable("pembayaran", "public");
                entity.Property(e=>e.Id).HasColumnName("id");
                entity.Property(e => e.TotalPembayaran).HasColumnName("total_pembayaran");
                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasMany<Pesanan>(e => e.Pesanans).WithOne();
                entity.Navigation(e => e.Pesanans).UsePropertyAccessMode(PropertyAccessMode.Property);
            });
        }

        public virtual DbSet<Makanan> Makanans { get; set; }
        public virtual DbSet<Pesanan> Pesanans { get; set; }
        public virtual DbSet<Pembayaran> Pembayarans { get; set; }
    }
}