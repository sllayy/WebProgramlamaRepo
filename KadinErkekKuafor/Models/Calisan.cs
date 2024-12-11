namespace KuaforYonetimSistemi.Models
{
	public class Calisan
	{
		public int CalisanID { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public string UzmanlikAlani { get; set; }
		public int SalonID { get; set; }

		// İlişkiler
		public Salon Salon { get; set; }
	}
}
