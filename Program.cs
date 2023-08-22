using Microsoft.AspNetCore.Authentication.Cookies;
using ReceptBank.ApplicationServices;
using ReceptBank.Domain;
using ReceptBank.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IReceptService, ReceptService>();
builder.Services.AddScoped<IReceptRepo, ReceptRepoJson>();

//Lägg till authentication - om man inte är authentiserad så stöter man på en challange, för att få den authentiserad. 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie();
var app = builder.Build();
app.Urls.Add("http://*:5000");

// Configure the HTTP request pipeline.
//alla Use grejjor är middleware - HTTP middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//finns inte authentication än så man måste lägga till det själv, men den finns som ramverk. 
//behöver också configurera den. 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
