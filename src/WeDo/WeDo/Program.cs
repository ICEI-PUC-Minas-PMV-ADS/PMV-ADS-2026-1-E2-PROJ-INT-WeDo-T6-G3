using WeDo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies; // ADICIONADO

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// adicionando o contexto do banco de dados SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrando o serviço de email para injeção de dependência
builder.Services.AddScoped<WeDo.Services.EmailService>();

// --- ADICIONADO: Configuração do sistema de Cookies ---
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Usuarios/Login"; // Rota para onde o usuário vai se não estiver logado
        options.AccessDeniedPath = "/Usuarios/Login";
    });
// -------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// --- ADICIONADO: Ativação da Autenticação ---
app.UseAuthentication(); // O sistema reconhece quem é o usuário
// --------------------------------------------

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuarios}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();