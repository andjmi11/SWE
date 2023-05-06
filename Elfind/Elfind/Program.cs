using Elfind.Data;
using Elfind.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
builder.Services.AddCors(p =>
{
    p.AddPolicy("CORS", builder =>
    {
        builder.WithOrigins(new string[]
                    {
                        "http://localhost:5056",
                        "http://127.0.0.1:5056",
                        "http://localhost:5500",
                        "http://127.0.0.1:5500",
                        "http://localhost:8080",
                        "http://127.0.0.1:8080",
                        "https://localhost:5500",
                        "https://127.0.0.1:5500",
                        "https://localhost:8080",
                        "https://127.0.0.1:8080",
                        "http://localhost:5050",
                        "http://127.0.0.1:5050",
                        "https://localhost:5050",
                        "https://127.0.0.1:5050",
                        "https://localhost:5056",
                        "https://127.0.0.1:5056"
                    })
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<ElfindContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Elfind"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpsRedirection(x => { x.HttpsPort = 5001; }) ; 
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
    });
}

//app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.UseRouting();

//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

//app.Run();
//app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();

