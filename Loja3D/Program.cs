using Loja3D.Components;
using Loja3D.Data;
using Loja3D.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura a Interatividade (ESSENCIAL para o botão Comprar funcionar)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Configura o Banco de Dados MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LojaContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 3. Configura o Login com Google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddGoogle(googleOptions => {
        // O "?? string.Empty" corrige o aviso amarelo CS8601
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? string.Empty;
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? string.Empty;
    });

// 4. Adiciona suporte a Controllers (para o Login funcionar)
builder.Services.AddControllers();

// 5. Permite que o estado de login seja visto em qualquer página
builder.Services.AddCascadingAuthenticationState();

// 6. Registra o Serviço do Carrinho
builder.Services.AddScoped<CarrinhoService>();

var app = builder.Build();

// --- Configuração do Pipeline (A ordem importa!) ---

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Ativa autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Mapeia os Controllers (Login)
app.MapControllers();

// Mapeia os Componentes Blazor com Interatividade
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();