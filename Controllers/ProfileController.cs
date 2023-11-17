using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica02Backend.Controllers.Base;
using Practica02Backend.Data;
using Practica02Backend.DTO;
using Practica02Backend.Models;
using Practica02Backend.Models.PerfilesAtributos;

namespace Practica02Backend.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly DataContext _context;

        public ProfileController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PerfilDTO>>> MostrarPerfil()
        {
            //seleccionar el perfil del usuario
            var perfil = await _context.Perfiles.Where(u => u.Id == 1).ToListAsync();
            var perfilSeleccionado = perfil.FirstOrDefault();
            if(perfilSeleccionado == null)
            {
                return NotFound();
            }
            

            //cargar lista de pasatiempos de acuerdo a ese perfil
            var pasatiempos = await _context.Pasatiempos.Where(p => p.perfilId == perfilSeleccionado.Id).ToListAsync();
            var pasatiemposDTO = pasatiempos.Select(p => new PasatiemposDTO
            {

                pasatiempo = p.pasatiempo,
                descripcion = p.descripcion


            }).ToList();


            //cargar lista de frameworks de acuerdo a ese perfil
            var frameworks = await _context.PerfilFrameworks.Where(f => f.perfilId == perfilSeleccionado.Id).ToListAsync();
            var niveles = await _context.Niveles.ToListAsync();

            var frameworksDTO = (
                from framework in frameworks
                join nivel in niveles on framework.nivelId equals nivel.Id
                where framework.perfilId == perfilSeleccionado.Id
                select new FrameworksDTO
                {
                    framework = framework.framework,
                    nivel = nivel.nivelNombre,
                    anio = framework.anio

                }).ToList();

            //una vez cargadas las listas, se crea el DTO del perfil
            var perfilDTO = perfil.Select(u => new PerfilDTO
            {
                nombre = u.nombre,
                apellido = u.apellido,
                correo = u.correo,
                ciudad = u.ciudad,
                pais = u.pais,
                descripcion = u.descripcion,
                Frameworks = frameworksDTO,
                Pasatiempos = pasatiemposDTO

            }).ToList();

            return perfilDTO;

        }

    }
}
