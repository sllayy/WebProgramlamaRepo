namespace KuaforYonetimSistemi.Models
{
	public class Admin
	{
		public int AdminID { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public string Email { get; set; }
		public string Sifre { get; set; } // Şifre hashlenmiş olarak saklanmalı
		public string Rol { get; set; } = "Admin";
	}
}
