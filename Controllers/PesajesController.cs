using EXAMEN2.Clases;
using ExamenApp2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EXAMEN2.Controllers
{
    [RoutePrefix("api/Pesajes")]
    public class PesajesController : ApiController
    {
        [HttpGet]
        [Route("ConsultarFotos")]
        public IQueryable ConsultarFotos(int idPesaje)
        {
            clsPesaje servicio = new clsPesaje();
            return servicio.ListarFotos(idPesaje);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Pesaje> ConsultarTodos()
        {
            clsPesaje servicio = new clsPesaje();
            return servicio.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Pesaje Consultar(int id)
        {
            clsPesaje servicio = new clsPesaje();
            return servicio.Consultar(id);
        }

        [HttpGet]
        [Route("ConsultarPorPlaca")]
        public List<object> ConsultarPorPlaca(string placa)
        {
            clsPesaje servicio = new clsPesaje();
            return servicio.ConsultarPesajesPorPlaca(placa);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Pesaje pesaje)
        {
            clsPesaje servicio = new clsPesaje();
            servicio.Pesaje = pesaje;
            return servicio.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Pesaje pesaje)
        {
            clsPesaje servicio = new clsPesaje();
            servicio.Pesaje = pesaje;
            return servicio.Actualizar();
        }

        [HttpPost]
        [Route("GrabarFotos")]
        public string GrabarFotos(int idPesaje, [FromBody] List<string> Fotos)
        {
            clsPesaje servicio = new clsPesaje();
            return servicio.GrabarFotoPesaje(idPesaje, Fotos);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Pesaje pesaje)
        {
            clsPesaje servicio = new clsPesaje();
            servicio.Pesaje = pesaje;
            return servicio.Eliminar();
        }

        [HttpDelete]
        [Route("EliminarxId")]
        public string EliminarxId(int id)
        {
            clsPesaje servicio = new clsPesaje();
            return servicio.Eliminar(id);
        }
    }
}