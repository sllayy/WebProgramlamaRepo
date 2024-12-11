namespace KuaforYonetimSistemi.Models
{
	public class FotoOneri
	{
		public int FotoOneriID { get; set; }
		public int MusteriID { get; set; }
		public string FotoYolu { get; set; }
		public string OnerilenModel { get; set; }
		public DateTime Tarih { get; set; } = DateTime.Now;

		// İlişkiler
		public Musteri Musteri { get; set; }
	}
}
