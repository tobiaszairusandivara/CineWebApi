using CineWebApi.Data.Models;
using CineWebApi.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet]//COMO ESTA EN LAZY LOAD NO CARGA LO DEL NOMBRE DEL GENERO, ES DECIR, NAVIGATION VA COMO NULL
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.RecupEstrenos());
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Se produjo un error! Excepcion: {ex}");
            }
         
        }


        [HttpPost]
        public IActionResult Post([FromBody] Pelicula oPelicula)
        {
            try
            {
                if (IsValid(oPelicula))
                {
                    _service.AgregarPelicula(oPelicula);
                    return Ok("Pelicula agregada con exito!");                 
                }
                else
                {
                    return BadRequest("Los datos estan incompletos o son incorrectos!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error! Excepcion: {ex}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            try
            {
                return Ok(_service.SacarDeEstreno(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error! Excepcion: {ex}");
            }
        }

        private bool IsValid(Pelicula value)
        {
            return !string.IsNullOrEmpty(value.Titulo) && !string.IsNullOrEmpty(value.Director) && value.Anio > 0 && value.IdGenero > 0;
        }
    }
}
