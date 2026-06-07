using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeDo.Models;
using WeDo.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WeDo.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService; // Injeção do serviço de email

        public UsuariosController(AppDbContext context, EmailService emailService)
        {
            _emailService = emailService;
            _context = context;
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
            string mensagem = $"<h2>Olá {usuario.Nome}!</h2>" +
                              $"<p>Você solicitou a recuperação da sua senha.</p>" +
                              $"<p>Clique no link abaixo para criar uma nova senha. Este link é válido por apenas 1 hora.</p>" +
                              $"<a href='{linkRecuperacao}' style='display:inline-block; padding:10px 20px; background-color:#147A3B; color:white; text-decoration:none; border-radius:5px;'>Redefinir Minha Senha</a>" +
                              $"<p>Se você não solicitou isso, apenas ignore este e-mail.</p>";

            await _emailService.EnviarEmailAsync(usuario.Email, assunto, mensagem);
            ViewBag.Message = "";
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

            ViewBag.Message = "Senha redefinida com sucesso! Você já pode fazer login com sua nova senha.";
            return View("ConfirmacaoEnvio");
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}