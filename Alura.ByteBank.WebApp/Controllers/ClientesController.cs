using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alura.ByteBank.Dados.Contexto;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dados.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Alura.ByteBank.Aplicacao.AplicacaoServico;
using Alura.ByteBank.Dominio.Interfaces.Servicos;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Dominio.Services;
using Alura.ByteBank.Aplicacao.DTO;

namespace Alura.ByteBank.WebApp.Controllers
{
    
    public class ClientesController : Controller
    {
        
        private readonly IClienteRepositorio _repositorio;
        private readonly IClienteServico _servico;
        private readonly ClienteServicoApp clienteServicoApp;
        public ClientesController(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
            _servico = new ClienteServico(_repositorio);
            clienteServicoApp = new ClienteServicoApp(_servico);
        }

        // GET: Clientes
        [Authorize]
        public IActionResult Index()
        {
            return View(clienteServicoApp.ObterTodos());
        }

        // GET: Clientes/Details/5
        [Authorize]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicoApp.ObterPorId(id);
                
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Create([Bind("Id,Identificador,CPF,Nome,Profissao")] ClienteDTO cliente)
        {
            if (ModelState.IsValid)
            {
                clienteServicoApp.Adicionar(cliente);               
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicoApp.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, [Bind("Id,Identificador,CPF,Nome,Profissao")] ClienteDTO cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    clienteServicoApp.Atualizar(id,cliente);                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = clienteServicoApp.ObterPorId(id);
              
            if (cliente == null)
            {
                return NotFound();
            }

            clienteServicoApp.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = clienteServicoApp.ObterPorId(id);
            clienteServicoApp.Excluir(id);     
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id) {
            var cliente = clienteServicoApp.ObterPorId(id);
            return cliente == null ? true : false;
        }
    }
}
