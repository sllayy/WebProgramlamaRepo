using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KuaforYonetimSistemi.Models;
using System.Collections.Generic;

namespace KuaforYonetimSistemi.Data
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Admin> Adminler { get; set; }
		public DbSet<Musteri> Musteriler { get; set; }
		public DbSet<Salon> Salonlar { get; set; }
		public DbSet<Calisan> Calisanlar { get; set; }
		public DbSet<Islem> Islemler { get; set; }
		public DbSet<Randevu> Randevular { get; set; }
		public DbSet<FotoOneri> FotoOneriler { get; set; }
	}
}
