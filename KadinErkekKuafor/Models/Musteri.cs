﻿namespace KuaforYonetimSistemi.Models
{
	public class Musteri
	{
		public int MusteriID { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public string Email { get; set; }
		public string Sifre { get; set; }
		public string Telefon { get; set; }
		public string Adres { get; set; }
		public DateTime? DogumTarihi { get; set; }
		public DateTime KayitTarihi { get; set; } = DateTime.Now;
	}
}
