using KuaforYonetimSistemi.Models;

public interface IMusteriService
{
    Musteri GetMusteriByEmail(string email);
    void CreateMusteri(Musteri musteri);
}
