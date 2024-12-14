using KuaforYonetimSistemi.Data; // ApplicationDbContext sýnýfýný kullanabilmek için
//using KuaforYonetimSistemi.Services; // IMusteriService ve MusteriService için
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL veritabaný baðlantýsýný yapýlandýrýn
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // PostgreSQL baðlantýsý

// IMusteriService ve MusteriService'i DI container'a ekleyin
builder.Services.AddScoped<IMusteriService, MusteriService>();

// Identity servisi ekleyin (kullanýcý doðrulama ve yönetimi için)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// MVC'yi yapýlandýrýn
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Geliþtirme ortamýnda hata ayrýntýlarýný göster
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    // Hata sayfasý, üretim ortamýnda kullanýlacak
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Statik dosyalar (CSS, JS, resimler vb.) için middleware
app.UseStaticFiles();

// HTTP talep yönlendirmesi
app.UseRouting();

// Kullanýcý kimlik doðrulama (Authentication) middleware
app.UseAuthentication();

// Yetkilendirme middleware (yetki denetimi için)
app.UseAuthorization();

// Uygulama rota yönlendirmeleri
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulamayý çalýþtýrýn
app.Run();
