using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FavelaDelivery.Models;

namespace FavelaDelivery.Controllers
{
    public class CadastroClientesController : Controller
    {
        private readonly Context _context;

        public CadastroClientesController(Context context)
        {
            _context = context;
        }

        // GET: CadastroClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.cadastrocliente.ToListAsync());
        }

        // GET: CadastroClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCliente = await _context.cadastrocliente
                .FirstOrDefaultAsync(m => m.Idcliente == id);
            if (cadastroCliente == null)
            {
                return NotFound();
            }

            return View(cadastroCliente);
        }

        // GET: CadastroClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcliente,NomeCompleto,CPF,EnderecoPersonalizado,Email,Telefone,Login,Senha")] CadastroCliente cadastroCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroCliente);
        }

        // GET: CadastroClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCliente = await _context.cadastrocliente.FindAsync(id);
            if (cadastroCliente == null)
            {
                return NotFound();
            }
            return View(cadastroCliente);
        }

        // POST: CadastroClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcliente,NomeCompleto,CPF,EnderecoPersonalizado,Email,Telefone,Login,Senha")] CadastroCliente cadastroCliente)
        {
            if (id != cadastroCliente.Idcliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroClienteExists(cadastroCliente.Idcliente))
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
            return View(cadastroCliente);
        }

        // GET: CadastroClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCliente = await _context.cadastrocliente
                .FirstOrDefaultAsync(m => m.Idcliente == id);
            if (cadastroCliente == null)
            {
                return NotFound();
            }

            return View(cadastroCliente);
        }

        // POST: CadastroClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroCliente = await _context.cadastrocliente.FindAsync(id);
            _context.cadastrocliente.Remove(cadastroCliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroClienteExists(int id)
        {
            return _context.cadastrocliente.Any(e => e.Idcliente == id);
        }
    }
}
