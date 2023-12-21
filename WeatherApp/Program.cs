using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using WeatherApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WeatherDataContext>(options =>
    options.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=WAData;Trusted_Connection=True;"));

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/Security/AuthorizationForm");

builder.Services.AddAuthorization();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Security}/{action=AuthorizationForm}/{id?}");

app.Run();
