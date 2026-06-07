using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeDo.Models;
using WeDo.Services;
using Microsoft.AspNetCore.Authentication; // ADICIONADO
using Microsoft.AspNetCore.Authentication.Cookies; // ADICIONADO
using System.Security.Claims; // ADICIONADO
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;


namespace WeDo.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;// Injeção do serviço de email
        private readonly Microsoft.Extensions.Localization.IStringLocalizer<UsuariosController> _localizer; // Tradução das mensagens (RF-013)

        public UsuariosController(AppDbContext context, EmailService emailService,
            Microsoft.Extensions.Localization.IStringLocalizer<UsuariosController> localizer)
        {
            _emailService = emailService;
            _context = context;
            _localizer = localizer;
        }

        // =====================================================================
        // --- INÍCIO DA SUA ADIÇÃO: SISTEMA DE LOGIN E CADASTRO ---
        // =====================================================================

        [HttpGet]
        public IActionResult Login()
        {

            return View(new WeDo.Models.ViewModels.LoginCadastroViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(WeDo.Models.ViewModels.LoginCadastroViewModel model)
        {
            // Valida se os campos específicos do cadastro foram preenchidos
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

            // Usando o construtor da sua classe Usuario mapeando os dados da Model
            var novoUsuario = new Usuario(model.CadNome, "Membro WeDo", "", model.CadEmail, model.CadSenha);

            _context.Add(novoUsuario);
            await _context.SaveChangesAsync();

            ViewBag.Success = "Cadastro realizado com sucesso! Agora entre com sua conta.";
            return View("Login", new WeDo.Models.ViewModels.LoginCadastroViewModel());
        }

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

                // Aplica o idioma preferido do usuário já a partir do login.
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

        // =====================================================================
        // --- CÓDIGO DO RESTANTE DO GRUPO (PRESERVADO INTEGRAMENTE SEM ALTERAÇÕES) ---
        // =====================================================================

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
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

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,UrlFoto,Email,Senha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
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

        //===============Metodos de Recuperar Senha======================//
        [HttpGet]
        public IActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EsqueciSenha(string email)
        {
            if ( string.IsNullOrEmpty(email))
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
            string mensagem = $"<h2>Olá {usuario.Nome}!</h2>" +
                              $"<p>Você solicitou a recuperação da sua senha.</p>" +
                              $"<p>Clique no link abaixo para criar uma nova senha. Este link é válido por apenas 1 hora.</p>" +
                              $"<a href='{linkRecuperacao}' style='display:inline-block; padding:10px 20px; background-color:#147A3B; color:white; text-decoration:none; border-radius:5px;'>Redefinir Minha Senha</a>" +
                              $"<p>Se você não solicitou isso, apenas ignore este e-mail.</p>";

            await _emailService.EnviarEmailAsync(usuario.Email, assunto, mensagem); // Envia o email com a nova senha temporária
            ViewBag.Titulo = "E-mail Enviado!";
            ViewBag.Message = "O link para redefinir sua senha foi enviado para o seu e-mail!";
            return View("ConfirmacaoEnvio");
        }

        [HttpGet]
        public IActionResult RefazerSenha(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Home");
            }
            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRecuperacao == token && u.DataExpiracaoToken > DateTime.Now);
            if (usuario == null)
            {
                ViewBag.Error = "Link de recuperação inválido ou expirado. Solicite um novo link.";
                return View("ConfirmacaoEnvio");
            }
            ViewBag.Token = token;
            return View();
        }

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

            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@@$!%*?&])[A-Za-z\d@@$!%*?&]{8,}$");
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

        //=================== Configurações de Perfil (RF-004) ===================//

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

        // Grava o cookie de cultura para que o RequestLocalizationMiddleware aplique o idioma
        // escolhido em todas as próximas requisições.
        private void DefinirCookieDeCultura(Idioma idioma)
        {
            var cultura = MapearCultura(idioma);
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultura)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), IsEssential = true });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            var usuario = await ObterUsuarioLogadoAsync();
            if (usuario == null) return RedirectToAction("Login");
            return View(usuario);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Perfil(string nome, string apelido, string email, string descricao, string urlFoto)
        {
            var usuario = await ObterUsuarioLogadoAsync();
            if (usuario == null) return RedirectToAction("Login");

            // Normaliza entradas: remove espaços extras que costumam quebrar comparações posteriores (login por email).
            nome = nome?.Trim();
            apelido = apelido?.Trim();
            email = email?.Trim();
            descricao = descricao?.Trim();
            urlFoto = urlFoto?.Trim();

            // Aplica os valores ao model em memória ANTES das validações para que, em caso de erro,
            // a view re-renderize exibindo o que o usuário acabou de digitar (não o que estava no banco).
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

            // Bloqueia troca de e-mail para um já cadastrado por outro usuário
            if (_context.Usuarios.Any(u => u.Email == email && u.Id != usuario.Id))
            {
                ViewBag.Error = _localizer["Este e-mail já está em uso por outra conta."].Value;
                return View(usuario);
            }

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            // Atualiza o cookie de autenticação para refletir nome/email novos
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

        //=================== Configurações Gerais (RF-013) ===================//

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Configuracoes()
        {
            var usuario = await ObterUsuarioLogadoAsync();
            if (usuario == null) return RedirectToAction("Login");
            return View(usuario);
        }

        [Authorize]
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

            // Persiste o idioma escolhido em um cookie de cultura (vale para as próximas requisições)
            // e aplica a cultura já nesta resposta, para a página recarregar traduzida na hora.
            DefinirCookieDeCultura(idioma);
            var culturaAtual = new CultureInfo(MapearCultura(idioma));
            CultureInfo.CurrentCulture = culturaAtual;
            CultureInfo.CurrentUICulture = culturaAtual;

            ViewBag.Success = _localizer["Configurações salvas com sucesso!"].Value;
            return View(usuario);
        }
    }
}