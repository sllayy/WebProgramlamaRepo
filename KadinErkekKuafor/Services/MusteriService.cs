using KuaforYonetimSistemi.Data;
using KuaforYonetimSistemi.Models;
using Microsoft.EntityFrameworkCore;

public class MusteriService : IMusteriService
{
    private readonly ApplicationDbContext _context;

    public MusteriService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Musteri GetMusteriByEmail(string email)
    {
        return _context.Musteriler.FirstOrDefault(m => m.Email == email);
    }

    public void CreateMusteri(Musteri musteri)
    {
        _context.Musteriler.Add(musteri);
        _context.SaveChanges();
    }
}
