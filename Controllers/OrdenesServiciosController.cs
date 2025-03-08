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
    [Authorize(Roles = "Admin")]
    public class OrdenesServiciosController : Controller
    {
        private readonly PracticaPtallerContext _context;

        public OrdenesServiciosController(PracticaPtallerContext context)
        {
            _context = context;
        }
        //[Authorize(Roles = "Admin")]
        // GET: OrdenesServicios
        public async Task<IActionResult> Index()
        {
            var practicaPtallerContext = _context.OrdenesServicios.Include(o => o.cliente).Include(o => o.vehiculo).Include(o => o.servicio);
            return View(await practicaPtallerContext.ToListAsync());
        }

        // GET: OrdenesServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenesServicio = await _context.OrdenesServicios
                .Include(o => o.cliente)
                .Include(o => o.vehiculo)
                .Include(o => o.servicio)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (ordenesServicio == null)
            {
                return NotFound();
            }

            return View(ordenesServicio);
        }

        // GET: OrdenesServicios/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca");
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "ServicioId", "Nombre"); 

            return View();
        }

        // POST: OrdenesServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdenId,Inicio,Entrega,Total,ClienteId,VehiculoId,ServicioId")] OrdenesServicio ordenesServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenesServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ordenesServicio.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca", ordenesServicio.VehiculoId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "ServicioId", "Nombre", ordenesServicio.ServicioId);
            return View(ordenesServicio);
        }

        // GET: OrdenesServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenesServicio = await _context.OrdenesServicios.FindAsync(id);
            if (ordenesServicio == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ordenesServicio.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca", ordenesServicio.VehiculoId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "ServicioId", "Nombre", ordenesServicio.ServicioId);

            return View(ordenesServicio);
        }

        // POST: OrdenesServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdenId,Inicio,Entrega,Total,ClienteId,VehiculoId,ServicioId")] OrdenesServicio ordenesServicio)
        {
            if (id != ordenesServicio.OrdenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenesServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenesServicioExists(ordenesServicio.OrdenId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ordenesServicio.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca", ordenesServicio.VehiculoId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "ServicioId", "Nombre", ordenesServicio.ServicioId);

            return View(ordenesServicio);
        }

        // GET: OrdenesServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenesServicio = await _context.OrdenesServicios
                .Include(o => o.cliente)
                .Include(o => o.vehiculo)
                .Include(o => o.servicio)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (ordenesServicio == null)
            {
                return NotFound();
            }

            return View(ordenesServicio);
        }

        // POST: OrdenesServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenesServicio = await _context.OrdenesServicios.FindAsync(id);
            if (ordenesServicio != null)
            {
                _context.OrdenesServicios.Remove(ordenesServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenesServicioExists(int id)
        {
            return _context.OrdenesServicios.Any(e => e.OrdenId == id);
        }
    }
}
