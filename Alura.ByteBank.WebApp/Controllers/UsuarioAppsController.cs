using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.WebApp.Views.ViewModel;
using Alura.ByteBank.WebApp.Util;
using Microsoft.AspNetCore.Http;

namespace Alura.ByteBank.WebApp.Controllers
{
    public class UsuarioAppsController : Controller
    {
        private UsuarioAppRepositorio _context;

        public UsuarioAppsController()
        {
            _context = new UsuarioAppRepositorio();
        }

        // GET: UsuarioApps
        public ActionResult Index()
        {
            return View(_context.ObterTodos());
        }

        // GET: UsuarioApps/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioApp = _context.ObterPorId(id);
               
            if (usuarioApp == null)
            {
                return NotFound();
            }

            return View(usuarioApp);
        }

        // GET: UsuarioApps/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,UserName,Email,Senha")] UsuarioApp usuarioApp)
        {
            if (ModelState.IsValid)            {
                _context.Adicionar(usuarioApp);             
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioApp);
        }

        // GET: UsuarioApps/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioApp = _context.ObterPorId(id);
            if (usuarioApp == null)
            {
                return NotFound();
            }
            return View(usuarioApp);
        }

        // POST: UsuarioApps/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,UserName,Email,Senha")] UsuarioApp usuarioApp)
        {
            if (id != usuarioApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Atualizar(id,usuarioApp);                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioAppExists(usuarioApp.Id))
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
            return View(usuarioApp);
        }

        // GET: UsuarioApps/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioApp = _context.ObterPorId(id);
               
            if (usuarioApp == null)
            {
                return NotFound();
            }

            return View(usuarioApp);
        }

        // POST: UsuarioApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioApp = _context.ObterPorId(id);
            _context.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioAppExists(int id)
        {
            var usuarioApp = _context.ObterPorId(id);
            return usuarioApp == null ? true : false;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioAppViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                string salto = Configuracao.Secret + usuario.Senha;
                string senha = Criptografia.sha256encrypt(salto);
                var _usuario = _context.ObterPorEmail(usuario.Email);                
                if (_usuario!=null)
                {
                    var token = TokenService.GenerateToken(_usuario);
                    if (_usuario.Senha == senha)
                    {
                        HttpContext.Request.Headers.Remove("Authorization");
                        HttpContext.Request.Headers.Add("Authorization","Bearer " + token);
                        HttpContext.Session.SetString("JWToken", token);
                        HttpContext.Session.SetString("user", _usuario.UserName);                        
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();           
           return RedirectToAction("Login","UsuarioApps");
        }
    }
}
