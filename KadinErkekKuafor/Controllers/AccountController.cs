using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;


public class AccountController : Controller
{
    // Login POST Action
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _userService.GetUserByEmail(email);  // E-posta ile kullanıcıyı bul

        if (user == null) // Eğer kullanıcı yoksa
        {
            TempData["ErrorMessage"] = "Hesabınız yok, lütfen kaydolun.";  // Hata mesajı
            return RedirectToAction("Login");  // Login sayfasına yönlendir
        }

        if (user.Password != password) // Parola yanlışsa
        {
            TempData["ErrorMessage"] = "Geçersiz e-posta veya parola.";  // Hata mesajı
            return RedirectToAction("Login");
        }

        // Başarılı giriş işlemi
        TempData["SuccessMessage"] = "Hoş geldiniz! Oturum başarıyla açıldı.";  // Başarı mesajı
        return RedirectToAction("Index", "Home");  // Ana sayfaya yönlendir
    }

    // Register GET Action
    public IActionResult Register()
    {
        return View();
    }

    // Register POST Action
    [HttpPost]
    public IActionResult Register(string email, string password, string confirmPassword)
    {
        if (password != confirmPassword)  // Parola eşleşmesi kontrolü
        {
            TempData["ErrorMessage"] = "Parolalar eşleşmiyor.";  // Hata mesajı
            return RedirectToAction("Register");  // Register sayfasına yönlendir
        }

        var existingUser = _userService.GetUserByEmail(email);  // E-posta ile kontrol et
        if (existingUser != null)
        {
            TempData["ErrorMessage"] = "Bu e-posta adresiyle bir hesap zaten var.";  // Hata mesajı
            return RedirectToAction("Register");
        }

        // Yeni kullanıcıyı oluştur ve kaydet
        var user = new User
        {
            Email = email,
            Password = password
        };
        

        TempData["SuccessMessage"] = "Kayıt başarılı! Artık oturum açabilirsiniz.";  // Başarı mesajı
        return RedirectToAction("Login");  // Oturum açma sayfasına yönlendir
    }
}
