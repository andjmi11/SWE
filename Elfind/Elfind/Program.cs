
using Elfind.Data;
using Elfind.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BlazorBootstrap;
using Microsoft.AspNetCore.Identity;
using Elfind.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("No connection string in config!");

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<TokenProvider>();

builder.Services.AddTransient<AdministratorService>();
builder.Services.AddTransient<CasService>();
builder.Services.AddTransient<ForumService>();
builder.Services.AddTransient<KursService>();
builder.Services.AddTransient<NastavnoOsobljeService>();
builder.Services.AddTransient<NotifikacijaService>();
builder.Services.AddTransient<ObjavaService>();
builder.Services.AddTransient<OpcijaService>();
builder.Services.AddTransient<ProstorijaService>();
builder.Services.AddTransient<RasporedCasovaService>();
builder.Services.AddTransient<SmerService>();
builder.Services.AddTransient<SpratService>();
builder.Services.AddSingleton<StudentService>();
builder.Services.AddTransient<ZgradaService>();


builder.Services.AddBlazorBootstrap();

builder.Services.AddDbContextFactory<ElfindContext>((DbContextOptionsBuilder options) =>
options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ElfindContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
