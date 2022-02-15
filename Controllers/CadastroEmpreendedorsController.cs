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
    public class CadastroEmpreendedorsController : Controller
    {
        private readonly Context _context;

        public CadastroEmpreendedorsController(Context context)
        {
            _context = context;
        }

        // GET: CadastroEmpreendedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.cadastroempreendedor.ToListAsync());
        }

        // GET: CadastroEmpreendedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEmpreendedor = await _context.cadastroempreendedor
                .FirstOrDefaultAsync(m => m.Idempreendedor == id);
            if (cadastroEmpreendedor == null)
            {
                return NotFound();
            }

            return View(cadastroEmpreendedor);
        }

        // GET: CadastroEmpreendedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroEmpreendedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idempreendedor,NomeCompleto,CPF,EnderecoPersonalizado,Email,Telefone,Login,Senha")] CadastroEmpreendedor cadastroEmpreendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroEmpreendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroEmpreendedor);
        }

        // GET: CadastroEmpreendedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEmpreendedor = await _context.cadastroempreendedor.FindAsync(id);
            if (cadastroEmpreendedor == null)
            {
                return NotFound();
            }
            return View(cadastroEmpreendedor);
        }

        // POST: CadastroEmpreendedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idempreendedor,NomeCompleto,CPF,EnderecoPersonalizado,Email,Telefone,Login,Senha")] CadastroEmpreendedor cadastroEmpreendedor)
        {
            if (id != cadastroEmpreendedor.Idempreendedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroEmpreendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroEmpreendedorExists(cadastroEmpreendedor.Idempreendedor))
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
            return View(cadastroEmpreendedor);
        }

        // GET: CadastroEmpreendedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroEmpreendedor = await _context.cadastroempreendedor
                .FirstOrDefaultAsync(m => m.Idempreendedor == id);
            if (cadastroEmpreendedor == null)
            {
                return NotFound();
            }

            return View(cadastroEmpreendedor);
        }

        // POST: CadastroEmpreendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroEmpreendedor = await _context.cadastroempreendedor.FindAsync(id);
            _context.cadastroempreendedor.Remove(cadastroEmpreendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroEmpreendedorExists(int id)
        {
            return _context.cadastroempreendedor.Any(e => e.Idempreendedor == id);
        }
    }
}
