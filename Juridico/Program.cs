using Juridico.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Juridico.IoC.App_Start;
using Microsoft.AspNetCore.Authentication.Cookies;
using Juridico.Application.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

string connection = "Server=localhost;Port=3306;Database=Juridico;user=root;password=Levi2405";

builder.Services.AddDbContext<JuridicoContext>(options =>
                                                    options.UseMySql(connection,
                                                                     ServerVersion.AutoDetect(connection)));

builder.Services.AddAutoMapper(typeof(AutomapperConfig));

InjectionDependencyCore.ConfigureServices(builder.Services);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Autenticacao/Index";
            options.LogoutPath = "/Autenticacao/Logout";
        });

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
