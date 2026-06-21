using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeDo.Models;
using WeDo.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace WeDo.Controllers
{
    [Authorize] // Bloqueia todas as ações deste Controller por padrão
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;
        private readonly Microsoft.Extensions.Localization.IStringLocalizer<UsuariosController> _localizer;

        public UsuariosController(AppDbContext context, EmailService emailService, Microsoft.Extensions.Localization.IStringLocalizer<UsuariosController> localizer)
        {
            _emailService = emailService;
            _context = context;
            _localizer = localizer;
        }

        // --- Autenticação e Cadastro ---

        [AllowAnonymous] // Passe livre: permite acesso sem estar logado
        [HttpGet]
        public IActionResult Login()
        {
            return View(new WeDo.Models.ViewModels.LoginCadastroViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(WeDo.Models.ViewModels.LoginCadastroViewModel model)
        {
            if (string.IsNullOrEmpty(model.CadNome) || string.IsNullOrEmpty(model.CadEmail) || string.IsNullOrEmpty(model.CadSenha))
            {
                ViewBag.Error = "Preencha todos os campos do cadastro.";
                return View("Login", model);
            }

            if (_context.Usuarios.Any(u => u.Email == model.CadEmail))
            {
                ViewBag.Error = "Este e-mail já está cadastrado.";
                return View("Login", model);
            }

            // Instancia a entidade mapeando os dados recebidos da View
            var novoUsuario = new Usuario(model.CadNome, "Membro WeDo", "", model.CadEmail, model.CadSenha);

            _context.Add(novoUsuario);
            await _context.SaveChangesAsync();

            ViewBag.Success = "Cadastro realizado com sucesso! Agora entre com sua conta.";
            return View("Login", new WeDo.Models.ViewModels.LoginCadastroViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entrar(WeDo.Models.ViewModels.LoginCadastroViewModel model)
        {
            if (string.IsNullOrEmpty(model.LoginEmail) || string.IsNullOrEmpty(model.LoginSenha))
            {
                ViewBag.Error = "Por favor, preencha e-mail e senha.";
                return View("Login", model);
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == model.LoginEmail && u.Senha == model.LoginSenha);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                DefinirCookieDeCultura(usuario.Idioma);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "E-mail ou senha incorretos.";
            return View("Login", model);
        }

        [HttpGet]
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // --- Gerenciamento Padrão de Usuários (CRUD) ---

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            // Redireciona qualquer acesso direto à lista ou clique em "Voltar" para o Dashboard (Home)
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,UrlFoto,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,UrlFoto,Email,Senha")] Usuario usuario)
        {
            if (id != usuario.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // --- Recuperação de Senha ---

        [AllowAnonymous]
        [HttpGet]
        public IActionResult EsqueciSenha()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EsqueciSenha(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Por favor, insira um email válido.";
                return View();
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario == null)
            {
                ViewBag.Error = "Se o email existir no nosso sistema, você receberá as instruções para redefinir sua senha.";
                return View("ConfirmacaoEnvio");
            }

            string token = Guid.NewGuid().ToString();
            usuario.TokenRecuperacao = token;
            usuario.DataExpiracaoToken = DateTime.Now.AddHours(1);

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            string linkRecuperacao = Url.Action("RefazerSenha", "Usuarios", new { token = token }, Request.Scheme);
            string assunto = "Instruções para Redefinir sua Senha - WeDo";

            // Usando o @$"" (Interpolated verbatim string) para escrever o HTML em várias linhas sem precisar do sinal de +
            string mensagem = $@"
                <div style='font-family: Arial, sans-serif; background-color: #f4f7f6; padding: 40px 0; margin: 0; width: 100%;'>
                    <table align='center' cellpadding='0' cellspacing='0' width='600' style='background-color: #ffffff; border-radius: 8px; overflow: hidden; box-shadow: 0 4px 10px rgba(0,0,0,0.05);'>
        
                        <tr>
                            <td style='background-color: #147A3B; padding: 30px; text-align: center;'>
                                <h1 style='color: #ffffff; margin: 0; font-size: 28px; letter-spacing: 1px;'>WeDo</h1>
                            </td>
                        </tr>
        
                        <tr>
                            <td style='padding: 40px 30px; color: #333333;'>
                                <h2 style='margin-top: 0; color: #147A3B; font-size: 22px;'>Olá, {usuario.Nome}!</h2>
                                <p style='font-size: 16px; line-height: 1.6; margin-bottom: 20px;'>
                                    Recebemos um pedido para redefinir a senha da sua conta no <strong>WeDo</strong>. Se foi você, clique no botão abaixo para escolher uma nova senha.
                                </p>
                
                                <table width='100%' cellpadding='0' cellspacing='0'>
                                    <tr>
                                        <td align='center' style='padding: 20px 0;'>
                                            <a href='{linkRecuperacao}' style='display: inline-block; padding: 14px 30px; background-color: #147A3B; color: #ffffff; text-decoration: none; font-size: 16px; font-weight: bold; border-radius: 6px; text-transform: uppercase; letter-spacing: 0.5px;'>
                                                Redefinir Minha Senha
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                
                                <p style='font-size: 14px; color: #777777; line-height: 1.5; margin-top: 20px;'>
                                    <em>Atenção: Este link é válido por apenas 1 hora. Se você não solicitou essa alteração, apenas ignore este e-mail e sua senha continuará a mesma.</em>
                                </p>
                            </td>
                        </tr>
        
                        <tr>
                            <td style='background-color: #f9f9f9; padding: 20px; text-align: center; border-top: 1px solid #eeeeee;'>
                                <p style='margin: 0; font-size: 12px; color: #999999;'>
                                    Você está recebendo este e-mail porque está cadastrado no sistema WeDo.<br>
                                    Não responda a esta mensagem.
                                </p>
                            </td>
                        </tr>
                    </table>
                </div>";

            await _emailService.EnviarEmailAsync(usuario.Email, assunto, mensagem);

            ViewBag.Titulo = "E-mail Enviado!";
            ViewBag.Message = "O link para redefinir sua senha foi enviado para o seu e-mail!";
            return View("ConfirmacaoEnvio");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RefazerSenha(string token)
        {
            // Se o token estiver vazio (usuário cancelou ou errou o link), volta para o Dashboard (Home)
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Index", "Home");

            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRecuperacao == token && u.DataExpiracaoToken > DateTime.Now);
            if (usuario == null)
            {
                ViewBag.Error = "Link de recuperação inválido ou expirado. Solicite um novo link.";
                return View("ConfirmacaoEnvio");
            }

            ViewBag.Token = token;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RefazerSenha(string Token, string novaSenha, string confirmarSenha)
        {
            ViewBag.Token = Token;

            if (novaSenha != confirmarSenha)
            {
                ViewBag.Error = "As senhas não coincidem. Por favor, tente novamente.";
                return View();
            }

            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            if (!regex.IsMatch(novaSenha))
            {
                ViewBag.Error = "A senha deve conter pelo menos 8 caracteres, incluindo uma letra maiúscula, um número e um caractere especial.";
                return View();
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRecuperacao == Token && u.DataExpiracaoToken > DateTime.Now);
            if (usuario == null)
            {
                ViewBag.Error = "Link de recuperação inválido ou expirado. Solicite um novo link.";
                return View("ConfirmacaoEnvio");
            }

            usuario.Senha = novaSenha;
            usuario.TokenRecuperacao = null;
            usuario.DataExpiracaoToken = null;

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            ViewBag.Titulo = "Senha Redefinida!";
            ViewBag.Message = "Senha redefinida com sucesso! Você já pode fazer login com sua nova senha.";
            return View("ConfirmacaoEnvio");
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        // --- Configurações de Perfil (RF-004) ---

        // Recupera o usuário autenticado a partir do claim NameIdentifier definido no Login.
        private async Task<Usuario> ObterUsuarioLogadoAsync()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(idClaim, out var id)) return null;
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        // Converte a preferência de idioma do usuário no código de cultura correspondente.
        private static string MapearCultura(Idioma idioma) => idioma switch
        {
            Idioma.InglesUS => "en-US",
            Idioma.EspanholES => "es-ES",
            _ => "pt-BR"
        };

        // Grava o cookie de cultura para que o RequestLocalizationMiddleware aplique o idioma nas requisições.
        private void DefinirCookieDeCultura(Idioma idioma)
        {
            var cultura = MapearCultura(idioma);
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultura)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), IsEssential = true });
        }

        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            var usuario = await ObterUsuarioLogadoAsync();
            if (usuario == null) return RedirectToAction("Login");
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Perfil(string nome, string apelido, string email, string descricao, string urlFoto)
        {
            var usuario = await ObterUsuarioLogadoAsync();
            if (usuario == null) return RedirectToAction("Login");

            // Normaliza entradas para evitar quebra em validações ou comparações.
            nome = nome?.Trim();
            apelido = apelido?.Trim();
            email = email?.Trim();
            descricao = descricao?.Trim();
            urlFoto = urlFoto?.Trim();

            // Aplica os valores ao model em memória ANTES das validações.
            // Isso garante que, em caso de erro, a view exiba o que foi digitado e não os dados antigos.
            usuario.Nome = nome;
            usuario.Apelido = apelido;
            usuario.Email = email;
            usuario.Descricao = descricao;
            usuario.UrlFoto = urlFoto;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email))
            {
                ViewBag.Error = _localizer["Nome e e-mail são obrigatórios."].Value;
                return View(usuario);
            }

            if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email))
            {
                ViewBag.Error = _localizer["Informe um e-mail em formato válido."].Value;
                return View(usuario);
            }

            // Bloqueia troca de e-mail para um que já pertença a outra conta
            if (_context.Usuarios.Any(u => u.Email == email && u.Id != usuario.Id))
            {
                ViewBag.Error = _localizer["Este e-mail já está em uso por outra conta."].Value;
                return View(usuario);
            }

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            // Atualiza os claims do cookie de autenticação caso o nome ou e-mail tenham mudado
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            ViewBag.Success = _localizer["Perfil atualizado com sucesso!"].Value;
            return View(usuario);
        }

        // --- Configurações Gerais (RF-013) ---

        [HttpGet]
        public async Task<IActionResult> Configuracoes()
        {
            var usuario = await ObterUsuarioLogadoAsync();
            if (usuario == null) return RedirectToAction("Login");
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Configuracoes(Idioma idioma, Tema tema, bool notificacoesEmail, bool notificacoesPush)
        {
            var usuario = await ObterUsuarioLogadoAsync();
            if (usuario == null) return RedirectToAction("Login");

            usuario.Idioma = idioma;
            usuario.Tema = tema;
            usuario.NotificacoesEmail = notificacoesEmail;
            usuario.NotificacoesPush = notificacoesPush;

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            // Persiste o idioma escolhido e aplica a cultura imediatamente na resposta atual
            DefinirCookieDeCultura(idioma);
            var culturaAtual = new CultureInfo(MapearCultura(idioma));
            CultureInfo.CurrentCulture = culturaAtual;
            CultureInfo.CurrentUICulture = culturaAtual;

            ViewBag.Success = _localizer["Configurações salvas com sucesso!"].Value;
            return View(usuario);
        }
    }
}