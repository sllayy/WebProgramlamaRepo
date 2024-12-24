ApplicationDbContext.cs


using WebKuaforProje.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebKuaforProje
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<FotoOneri> FotoOneriler { get; set; }
        public DbSet<Islem> Islemler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Price> Fiyatlar { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Salon> Salonlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and foreign keys
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Musteri)
                .WithMany(m => m.Randevular)
                .HasForeignKey(r => r.MusteriID)
                .OnDelete(DeleteBehavior.Cascade); // If you want cascading deletes

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Calisan)
                .WithMany(c => c.Randevular)
                .HasForeignKey(r => r.CalisanID)
                .OnDelete(DeleteBehavior.SetNull); // Change based on your logic

            modelBuilder.Entity<Islem>()
                .HasOne(i => i.Salon)
                .WithMany(s => s.Islemler)
                .HasForeignKey(i => i.SalonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Calisan>()
                .HasOne(c => c.Salon)
                .WithMany(s => s.Calisanlar)
                .HasForeignKey(c => c.SalonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FotoOneri>()
                .HasOne(f => f.Salon)
                .WithMany(s => s.FotoOneriler)
                .HasForeignKey(f => f.SalonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FotoOneri>()
                .HasOne(f => f.Musteri)
                .WithMany(m => m.FotoOneriler)
                .HasForeignKey(f => f.MusteriID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Salon>()
                .HasOne(s => s.Admin)
                .WithMany(a => a.Salonlar)
                .HasForeignKey(s => s.AdminID)
                .OnDelete(DeleteBehavior.Cascade);

            // Add indexes on frequently queried columns (optional)
            modelBuilder.Entity<Randevu>()
                .HasIndex(r => r.MusteriID);
            modelBuilder.Entity<Randevu>()
                .HasIndex(r => r.CalisanID);

            modelBuilder.Entity<FotoOneri>()
                .HasIndex(f => f.MusteriID);
            modelBuilder.Entity<FotoOneri>()
                .HasIndex(f => f.SalonID);

            modelBuilder.Entity<Calisan>()
                .HasIndex(c => c.SalonID);

            // Seed initial data (optional)
            // Uncomment and modify the code if you want to seed data.
            // modelBuilder.Entity<Admin>().HasData(
            //     new Admin { Id = 1, Name = "Admin Name", Email = "admin@example.com" }
            // );
        }
    }
}
