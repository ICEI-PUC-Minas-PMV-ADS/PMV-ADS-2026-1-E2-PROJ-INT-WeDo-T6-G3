using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeDo.Models;
using WeDo.Services;

namespace WeDo.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;// Injeção do serviço de email

        public UsuariosController(AppDbContext context, EmailService emailService )
        {
            _emailService = emailService;
            _context = context;
        }

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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email); // Verifica se o email existe no banco de dados
            if (usuario == null)
            {
                ViewBag.Error = "Se o email existir no nosso sistema, você receberá as instruções para redefinir sua senha.";
                return View("ConfirmacaoEnvio");
            }

            // Gera um token de recuperacao unico e define a data de expiração para 1 hora
            string token = Guid.NewGuid().ToString();
            usuario.TokenRecuperacao = token;
            usuario.DataExpiracaoToken = DateTime.Now.AddHours(1);
            
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            //monta o link de recuperacao 
            string linkRecuperacao = Url.Action("RefazerSenha", "Usuarios", new { token = token }, Request.Scheme); //o Request.Scheme garante que o link seja gerado com o protocolo correto (http ou https)

            //montando a mensagem do emailc
            string assunto = "Instruções para Redefinir sua Senha - WeDo";
            string mensagem = $"<h2>Olá {usuario.Nome}!</h2>" +
                      $"<p>Você solicitou a recuperação da sua senha.</p>" +
                      $"<p>Clique no link abaixo para criar uma nova senha. Este link é válido por apenas 1 hora.</p>" +
                      $"<a href='{linkRecuperacao}' style='display:inline-block; padding:10px 20px; background-color:#147A3B; color:white; text-decoration:none; border-radius:5px;'>Redefinir Minha Senha</a>" +
                      $"<p>Se você não solicitou isso, apenas ignore este e-mail.</p>";

            await _emailService.EnviarEmailAsync(usuario.Email, assunto, mensagem); // Envia o email com a nova senha temporária
            ViewBag.Message = "";
            return View("ConfirmacaoEnvio");
        }
        // GET: exibe a tela para o usuário criar uma nova senha, validando o token de recuperação
        [HttpGet]
        public IActionResult RefazerSenha(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Home"); // Redireciona para a página inicial se o token for inválido ou ausente
            }
            // Verifica se o token é válido e não expirou
            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRecuperacao == token && u.DataExpiracaoToken > DateTime.Now);
            if (usuario == null)
            {
                ViewBag.Error = "Link de recuperação inválido ou expirado. Solicite um novo link."; 
                // nao temos uma tela especifica de erros, usamos de forma generica
                return View("ConfirmacaoEnvio");
            }
            ViewBag.Token = token; // Passa o token para a view para que ele seja enviado de volta no formulário de redefinição de senha
            return View();
        }
        // POST: processa a redefinição de senha, validando o token e atualizando a senha do usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RefazerSenha(string Token,string novaSenha,string confirmarSenha)
        {
            ViewBag.Token = Token; //devolve o token para tela caso de algum erro
            
            if(novaSenha!=confirmarSenha)
            {
                ViewBag.Error = "As senhas não coincidem. Por favor, tente novamente.";
                return View();
            }
            // Validação de Senha Forte (8 chars, 1 maiúscula, 1 número, 1 especial)
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            if (!regex.IsMatch(novaSenha))
            {
                ViewBag.Error = "A senha deve conter pelo menos 8 caracteres, incluindo uma letra maiúscula, um número e um caractere especial.";
                return View();
            }
            // Verifica se o token é válido e não expirou
            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRecuperacao == Token && u.DataExpiracaoToken > DateTime.Now);
            if (usuario == null)
            {
                ViewBag.Error = "Link de recuperação inválido ou expirado. Solicite um novo link.";
                return View("ConfirmacaoEnvio");
            }
            usuario.Senha= novaSenha; // Atualiza a senha do usuário
            usuario.TokenRecuperacao = null; // Invalida o token de recuperação
            usuario.DataExpiracaoToken = null; // Limpa a data de expiração do token

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
