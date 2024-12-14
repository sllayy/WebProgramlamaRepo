namespace KuaforYonetimSistemi.Models
{
	public class Randevu
	{
		public int RandevuID { get; set; }
		public int MusteriID { get; set; }
		public int CalisanID { get; set; }
		public int IslemID { get; set; }
		public DateTime Tarih { get; set; }
		public string Durum { get; set; } = "Bekliyor";

		// İlişkiler
		public Musteri Musteri { get; set; }
		public Calisan Calisan { get; set; }
		public Islem Islem { get; set; }
	}
}
