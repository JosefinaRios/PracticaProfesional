using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaSupervisada.Models;

namespace PracticaSupervisada.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ComentariosController : Controller
    {
        private readonly PracticaPtallerContext _context;

        public ComentariosController(PracticaPtallerContext context)
        {
            _context = context;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comentarios.ToListAsync());
            //var comentarios = _context.Comentarios.OrderByDescending(c => c.Fecha).Take(5).ToList();
            //return View(comentarios);
            //var comentarios = _context.Comentarios.Include(c => c.Cliente).ToList(); // Consulta la base de datos
            //if (comentarios == null || !comentarios.Any())
            //{
            //    // Si no hay comentarios, inicializa una lista vacía
            //    comentarios = new List<Comentario>();
            //}
             // Envía los datos a la vista
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
            
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentarios/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComentarioId,Fecha,NombreCliente,Mensaje")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                 comentario.Fecha = DateOnly.FromDateTime(DateTime.Now); // Establecer la fecha actual
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redirigir al Home después de guardar
            }
            return View(comentario);
            
        }
      

        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);
          
            if (comentario == null)
            {
                return NotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComentarioId,Fecha,NombreCliente,Mensaje")] Comentario comentario)
        {
            if (id != comentario.ComentarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.ComentarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(comentario);
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
            
                .FirstOrDefaultAsync(m => m.ComentarioId == id);
            
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.ComentarioId == id);
        }
    }
}
