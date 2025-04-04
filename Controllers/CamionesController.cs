using ExamenApp2.Clases;
using ExamenApp2.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace EXAMEN2.Controllers
{
    [RoutePrefix("api/Camiones")]
    public class CamionesController : ApiController
    {
        //GET: Se utiliza para consultar información, no se debe modificar la base de datos
        //POST: Se utiliza para insertar información en la base de datos
        //PUT: Se utiliza para modificar (Actualizar) información en la base de datos
        //DELETE: Se utiliza para eliminar información en la base de datos
        [HttpGet] //Es el servicio que se va a exponer: GET, POST, PUT, DELETE
        [Route("ConsultarTodos")] //Es el nombre de la funcionalidad que se va a ejecutar
        public List<Camion> ConsultarTodos()
        {
            //Se crea una instancia de la clase clsCamion
            clsCamion Camion = new clsCamion();
            //Se invoca el método ConsultarTodos() de la clase clsCamion
            return Camion.ConsultarTodos();
        }
        [HttpGet]
        [Route("ConsultarXPlaca")]
        public Camion ConsultarXPlaca(string Placa)
        {
            //Se crea una instancia de la clases clsCamion
            clsCamion Camion = new clsCamion();
            return Camion.Consultar(Placa);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Camion camion)
        {
            //Se crea una instancia de la clase clsCamion
            clsCamion Camion = new clsCamion();
            //Se pasa la propieadad Camion al objeto de la clases clsCamion
            Camion.Camion = camion;
            //Se invoca el método insertar
            return Camion.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Camion camion)
        {
            clsCamion Camion = new clsCamion();
            Camion.Camion = camion;
            return Camion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Camion camion)
        {
            clsCamion Camion = new clsCamion();
            Camion.Camion = camion;
            return Camion.Eliminar();
        }
        [HttpDelete]
        [Route("EliminarXPlaca")]
        public string EliminarXPlaca(string Placa)
        {
            clsCamion Camion = new clsCamion();
            return Camion.Eliminar(Placa);
        }
    }
}