using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteEntity.Data;
using TesteEntity.Models;

namespace TesteEntity.Controllers {
    public class PessoaController : Controller {
        private readonly ApplicationDbContext _context;

        public PessoaController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: Pessoa
        public async Task<IActionResult> Index() {
            return View(await _context.Pessoa.Include(x => x.ListaTelefones).Include(x => x.ListaEnderecos).ToListAsync());
        }

        // GET: Pessoa/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null) {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoa/Create
        public IActionResult Create() {
            var opcoes = new List<teste>();
            var teste1 = new teste(1, "teste1");
            var teste2 = new teste(2, "teste2");
            var teste3 = new teste(3, "teste3");
            var teste4 = new teste(4, "teste4");
            opcoes.Add(teste1);
            opcoes.Add(teste2);
            opcoes.Add(teste3);
            opcoes.Add(teste4);
            ViewBag.opcoes = opcoes;
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Pessoa pessoa) {
            if (ModelState.IsValid) {
                pessoa.ListaEnderecos.Add(pessoa.Endereco);
                pessoa.ListaTelefones.Add(pessoa.Telefone);
                _context.Add(pessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null) {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Pessoa pessoa) {
            if (id != pessoa.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!PessoaExists(pessoa.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoa == null) {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var pessoa = await _context.Pessoa.FindAsync(id);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id) {
            return _context.Pessoa.Any(e => e.Id == id);
        }
    }

    public class teste {
        public teste(int id, string nome) {
            this.id = id;
            this.nome = nome;
        }
        public int id { get; set; }
        public string nome { get; set; }
    }

}
