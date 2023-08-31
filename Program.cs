using Microsoft.AspNetCore.Authentication.Cookies;
using ReceptBank.ApplicationServices;
using ReceptBank.Domain;
using ReceptBank.Infrastructure;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IReceptService, ReceptService>();
builder.Services.AddScoped<IReceptRepo, ReceptRepoJson>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = "427153378544-8is36bt9akjoev54nqkp6o12h4s63hus.apps.googleusercontent.com";
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? throw new ArgumentNullException("Authentication:Google:ClientSecret");
})
.AddOpenIdConnect(options =>
{
    options.ClientId = builder.Configuration["Authentication:Cognito:ClientId"] ?? throw new InvalidOperationException("Cognito ClientId is not set.");
    options.ResponseType = builder.Configuration["Authentication:Cognito:ResponseType"] ?? throw new InvalidOperationException("Cognito ResponseType is not set.");
    options.MetadataAddress = builder.Configuration["Authentication:Cognito:MetadataAddress"] ?? throw new InvalidOperationException("Cognito MetadataAddress is not set.");
    options.Events = new OpenIdConnectEvents
    {
        OnRedirectToIdentityProviderForSignOut = context =>
        {
            context.ProtocolMessage.Scope = builder.Configuration["Authentication:Cognito:Scope"] ?? throw new InvalidOperationException("Cognito Scope is not set.");
            context.ProtocolMessage.ResponseType = builder.Configuration["Authentication:Cognito:ResponseType"] ?? throw new InvalidOperationException("Cognito ResponseType is not set."); ;
            // context.ProtocolMessage.IssuerAddress = CognitoHelpers.GetCognitoLogoutUrl(builder.Configuration, context.HttpContext);
            // Create Cognito logout URL
            var cognitoDomain = builder.Configuration["Authentication:Cognito:CognitoDomain"] ?? throw new InvalidOperationException("Cognito CognitoDomain is not set.");
            var clientId = builder.Configuration["Authentication:Cognito:ClientId"] ?? throw new InvalidOperationException("Cognito ClientId is not set.");
            var appSignOutUrl = builder.Configuration["Authentication:Cognito:AppSignOutUrl"] ?? throw new InvalidOperationException("Cognito AppSignOutUrl is not set.");
            var logoutUrl = $"{context.Request.Scheme}://{context.Request.Host}{appSignOutUrl}";
            var cognitoLogoutUrl = $"{cognitoDomain}/logout?client_id={clientId}&logout_uri={logoutUrl}";
            context.ProtocolMessage.IssuerAddress = cognitoLogoutUrl;
            // Close authentication sessions
            context.Properties.Items.Remove(CookieAuthenticationDefaults.AuthenticationScheme);
            context.Properties.Items.Remove(OpenIdConnectDefaults.AuthenticationScheme);
            return Task.CompletedTask;
        }
    };
});
//Lägg till authentication - om man inte är authentiserad så stöter man på en challange, för att få den authentiserad. 

var app = builder.Build();
    //app.Urls.Add("https://*:5000");

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


