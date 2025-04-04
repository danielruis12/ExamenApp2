using ExamenApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EXAMEN2.Clases
{
    public class clsPesaje
    {
        private DBExamenEntities dbExamen = new DBExamenEntities(); // Es el atributo (Propiedad) para gestionar la conexión a la base de datos
        public Pesaje Pesaje { get; set; }
        public string Insertar()
        {
            try
            {
                dbExamen.Pesajes.Add(Pesaje); //Agregar el objeto empleado a la lista de "empleadoes". Todavía no se agrega a la base de datos. Se debe invocar el método SaveChanges()
                dbExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Pesaje insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el Pesaje: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                Pesaje prod = Consultar(Pesaje.id);
                if (prod == null)
                {
                    return "El id del Pesaje no existe en la BD";
                }
                dbExamen.Pesajes.AddOrUpdate(Pesaje);
                dbExamen.SaveChanges();
                return "El Pesaje se actualizó correctamente";
            }
            catch (Exception ex)
            {
                return "Hubo un error al actualizar el Pesaje: " + ex.Message;
            }
        }
        public Pesaje Consultar(int id)
        {
            return dbExamen.Pesajes.FirstOrDefault(p => p.id == id);
        }
        public List<Pesaje> ConsultarTodos()
        {
            return dbExamen.Pesajes
                .OrderBy(p => p.Estacion)
                .ToList();
        }

        public string Eliminar()
        {
            try
            {
                Pesaje prod = Consultar(Pesaje.id);
                if (prod == null)
                {
                    return "El id del Pesaje no existe en la Base de Datos";
                }
                dbExamen.Pesajes.Remove(prod);
                dbExamen.SaveChanges();
                return "Se eliminó correctamente el Pesaje de la base de datos";
            }
            catch (Exception ex)
            {
                return "Hubo un error al eliminar el Pesaje: " + ex.Message;
            }
        }
        public string Eliminar(int id)
        {
            try
            {
                Pesaje prod = Consultar(id);
                if (prod == null)
                {
                    return "El id del Pesaje no existe en la Base de Datos";
                }
                dbExamen.Pesajes.Remove(prod);
                dbExamen.SaveChanges();
                return "Se eliminó correctamente el Pesaje de la base de datos";
            }
            catch (Exception ex)
            {
                return "Hubo un error al eliminar el Pesaje: " + ex.Message;
            }
        }

        public string GrabarFotoPesaje(int idPesaje, List<string> Fotos)
        {
            try
            {
                foreach (string Foto in Fotos)
                {
                    FotoPesaje FotoPesaje = new FotoPesaje();
                    FotoPesaje.idPesaje = idPesaje;
                    FotoPesaje.ImagenVehiculo = Foto;
                    dbExamen.FotoPesajes.Add(FotoPesaje);
                    dbExamen.SaveChanges();
                }
                return "Se grabó la información en la base de datos";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public IQueryable ListarFotos(int idPesaje)
        {
            return from P in dbExamen.Set<Pesaje>()
                   join I in dbExamen.Set<FotoPesaje>()
                   on P.id equals I.idPesaje
                   where P.id == idPesaje
                   orderby I.ImagenVehiculo
                   select new
                   {
                       idPesaje = P.id,
                       Pesaje = P.Estacion,
                       Foto = I.ImagenVehiculo
                   };
        }
    }
}