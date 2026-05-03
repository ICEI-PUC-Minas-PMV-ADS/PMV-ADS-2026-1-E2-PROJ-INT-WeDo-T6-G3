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
            // Gerar uma nova senha temporária
            string novaSenhaTemporaria =$"WeDo@{Guid.NewGuid().ToString().Substring(0, 6)}"; 
            usuario .Senha = novaSenhaTemporaria; // Atualiza a senha do usuário no banco de dados
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            string assunto = "Redefinição de Senha - WeDo";
            string mensagem = $"<h2>Olá {usuario.Nome}!</h2>"+
                              $"<p>Sua nova senha de acesso temporária é: <strong>{novaSenhaTemporaria}</strong></p>" +
                              $"<p>Recomendamos que você altere essa senha assim que fizer o login.</p>";
            await _emailService.EnviarEmailAsync(usuario.Email, assunto, mensagem); // Envia o email com a nova senha temporária
            ViewBag.Message = "Sua nova senha foi enviada para o seu e-mail!";
            return View("ConfirmacaoEnvio");
        }
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
