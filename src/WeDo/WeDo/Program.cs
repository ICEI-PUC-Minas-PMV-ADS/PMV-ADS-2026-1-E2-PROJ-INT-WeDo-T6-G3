using WeDo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies; // ADICIONADO
using Microsoft.AspNetCore.Localization; // Suporte a múltiplos idiomas (RF-013)
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Localização (i18n): arquivos .resx ficam na pasta "Resources" espelhando o caminho das views.
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
    .AddViewLocalization();

// Culturas suportadas pela aplicação. O idioma efetivo é definido por um cookie de cultura,
// que é gravado conforme a preferência salva pelo usuário em Configurações Gerais.
var supportedCultures = new[]
{
    new CultureInfo("pt-BR"),
    new CultureInfo("en-US"),
    new CultureInfo("es-ES")
};
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("pt-BR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

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

// Aplica a cultura da requisição (lendo o cookie de cultura) antes do roteamento/MVC.
app.UseRequestLocalization(app.Services.GetRequiredService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>().Value);

app.UseRouting();

// --- ADICIONADO: Ativação da Autenticação ---
app.UseAuthentication(); // O sistema reconhece quem é o usuário
// --------------------------------------------

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();