using Microsoft.AspNetCore.Mvc;
using KuaforYonetimSistemi.Models;

public class AccountController : Controller
{
    private readonly IMusteriService _musteriService;

    public AccountController(IMusteriService musteriService)
    {
        _musteriService = musteriService;
    }

    // GET: Login Sayfası
    public IActionResult Login()
    {
        return View();
    }

    // POST: Oturum Açma İşlemi
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            TempData["ErrorMessage"] = "E-posta ve parola boş bırakılamaz.";
            return RedirectToAction("Login");
        }

        var musteri = _musteriService.GetMusteriByEmail(email);

        if (musteri == null)
        {
            TempData["ErrorMessage"] = "Hesabınız bulunamadı. Lütfen kaydolun.";
            return RedirectToAction("Login");
        }

        if (musteri.Sifre != password)
        {
            TempData["ErrorMessage"] = "E-posta veya parola yanlış.";
            return RedirectToAction("Login");
        }

        TempData["SuccessMessage"] = $"Hoş geldiniz, {musteri.Ad}!";
        return RedirectToAction("Index", "Home");
    }

    // GET: Kaydol Sayfası
    public IActionResult Register()
    {
        return View();
    }

    // POST: Kaydolma İşlemi
    [HttpPost]
    public IActionResult Register(string email, string password, string confirmPassword)
    {
        if (password != confirmPassword)
        {
            TempData["ErrorMessage"] = "Parolalar eşleşmiyor.";
            return RedirectToAction("Register");
        }

        var existingMusteri = _musteriService.GetMusteriByEmail(email);

        if (existingMusteri != null)
        {
            TempData["ErrorMessage"] = "Bu e-posta adresiyle bir hesap zaten var.";
            return RedirectToAction("Register");
        }

        var musteri = new Musteri
        {
            Email = email,
            Sifre = password,
            KayitTarihi = DateTime.Now
        };

        _musteriService.CreateMusteri(musteri);

        TempData["SuccessMessage"] = "Kaydınız başarıyla oluşturuldu. Şimdi oturum açabilirsiniz.";
        return RedirectToAction("Login");
    }
}
