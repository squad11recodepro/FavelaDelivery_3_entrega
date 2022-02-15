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
    public class CadastroEntregadorsController : Controller
    {
        private readonly Context _context;

        public CadastroEntregadorsController(Context context)
        {
            _context = context;
        }

        // GET: CadastroEntregadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.cadastroentregador.ToListAsync());
        }

        // GET: CadastroEntregadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEntregador = await _context.cadastroentregador
                .FirstOrDefaultAsync(m => m.Identregador == id);
            if (cadastroEntregador == null)
            {
                return NotFound();
            }

            return View(cadastroEntregador);
        }

        // GET: CadastroEntregadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroEntregadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Identregador,NomeCompleto,CPF,EnderecoPersonalizado,Email,Telefone,Login,Senha")] CadastroEntregador cadastroEntregador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroEntregador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroEntregador);
        }

        // GET: CadastroEntregadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEntregador = await _context.cadastroentregador.FindAsync(id);
            if (cadastroEntregador == null)
            {
                return NotFound();
            }
            return View(cadastroEntregador);
        }

        // POST: CadastroEntregadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Identregador,NomeCompleto,CPF,EnderecoPersonalizado,Email,Telefone,Login,Senha")] CadastroEntregador cadastroEntregador)
        {
            if (id != cadastroEntregador.Identregador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroEntregador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroEntregadorExists(cadastroEntregador.Identregador))
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
            return View(cadastroEntregador);
        }

        // GET: CadastroEntregadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEntregador = await _context.cadastroentregador
                .FirstOrDefaultAsync(m => m.Identregador == id);
            if (cadastroEntregador == null)
            {
                return NotFound();
            }

            return View(cadastroEntregador);
        }

        // POST: CadastroEntregadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroEntregador = await _context.cadastroentregador.FindAsync(id);
            _context.cadastroentregador.Remove(cadastroEntregador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroEntregadorExists(int id)
        {
            return _context.cadastroentregador.Any(e => e.Identregador == id);
        }
    }
}
