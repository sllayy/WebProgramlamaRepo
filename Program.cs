using KuaforYonetimSistemi.Data; // ApplicationDbContext'i kullanabilmek için
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL bağlantısını yapılandırın
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("VeriTabaniWebKuaforConnection")));  // PostgreSQL bağlantısı için

builder.Services.AddControllersWithViews(); // MVC yapılandırması

var app = builder.Build();

// Geliştirme ortamında hata ayrıntılarını göster
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
