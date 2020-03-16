using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLABlogger.DTO;
using ITLABlogger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITLABlogger.Controllers
{
    public class PublicacionesController : Controller
    {
        private ITLABloggerContext _context;

        public PublicacionesController(ITLABloggerContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            return View();
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("TituloPublicacion,ContPublicacion,FechaPublicacion,Idpublicacion,AspNetUserId")] PublicacionesDTO dTO)
        {
            if (ModelState.IsValid)
            {
                Publicaciones newPublicacion = new Publicaciones
                {
                    TituloPublicacion = dTO.TituloPublicacion,
                    ContPublicacion = dTO.ContPublicacion
                };
                _context.Add(newPublicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction("", new { id = newPublicacion.Idpublicacion });
            }
            return View();
        }
        //EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicaciones.FindAsync(id);

            if (publicacion == null)
            {
                return NotFound();
            }

            var publicacionDTO = new PublicacionesDTO()
            {
                Idpublicacion = publicacion.Idpublicacion,
                TituloPublicacion = publicacion.TituloPublicacion,
                ContPublicacion = publicacion.ContPublicacion
            };
            return View(publicacionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("TituloPublicacion,ContPublicacion,FechaPublicacion,Idpublicacion,AspNetUserId")] PublicacionesDTO dTO)
        {
            if(id != dTO.Idpublicacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var publicacion = await _context.Publicaciones.FirstOrDefaultAsync(d => d.Idpublicacion == dTO.Idpublicacion);
                    publicacion.Idpublicacion = dTO.Idpublicacion;
                    publicacion.ContPublicacion = dTO.TituloPublicacion;
                    publicacion.ContPublicacion = dTO.ContPublicacion;

                    _context.Update(publicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacionesExists(dTO.Idpublicacion))
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
            return View(dTO);
        }

        //DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacion = await _context.Publicaciones
                .FirstOrDefaultAsync(m => m.Idpublicacion == id);
            if (publicacion == null)
            {
                return NotFound();
            }
            return View(publicacion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //Exists?
        public bool PublicacionesExists(int id)
        {
            return _context.Publicaciones.Any(e => e.Idpublicacion == id);
        }
    }
}
