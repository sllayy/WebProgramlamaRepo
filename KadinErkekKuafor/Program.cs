using KuaforYonetimSistemi.Data; // AppDbContext sýnýfýný kullanabilmek için
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsýný yapýlandýrýn (PostgreSQL veya SQL Server kullanabilirsiniz)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // SQL Server için
                                                                                           // options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // PostgreSQL için

// Identity servisi ekleyin (kullanýcý doðrulama ve yönetimi için)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
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
