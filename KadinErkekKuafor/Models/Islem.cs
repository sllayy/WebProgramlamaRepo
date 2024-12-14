namespace KuaforYonetimSistemi.Models
{
	public class Islem
	{
		public int IslemID { get; set; }
		public string Ad { get; set; }
		public decimal Ucret { get; set; }
		public int Sure { get; set; } // Süre dakikayla ifade edilir
		public int SalonID { get; set; }

		// İlişkiler
		public Salon Salon { get; set; }
	}
}
