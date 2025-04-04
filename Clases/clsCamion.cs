using ExamenApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ExamenApp2.Clases
{
	public class clsCamion
	{
        private DBExamenEntities dbExamen = new DBExamenEntities(); // Es el atributo (Propiedad) para gestionar la conexión a la base de datos
        public Camion Camion { get; set; } //Propiedad para manipular la información en la base de datos: Permite agregar, modificar o eliminar
        public string Insertar()
        {
            try
            {
                dbExamen.Camions.Add(Camion); //Agregar el objeto Camion a la lista de "Camions". Todavía no se agrega a la base de datos. Se debe invocar el método SaveChanges()
                dbExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Camion insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el Camion: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                //Antes de actualizar un elemento (Camion), se debe consultar para verificar que exista, y ahí si poderlo actualizar
                Camion cam = Consultar(Camion.Placa);
                if (cam == null)
                {
                    return "El Camion con el Placa ingresado no existe, por lo tanto no se puede actualizar";
                }
                //El Camion existe lo podemos actualizar
                dbExamen.Camions.AddOrUpdate(Camion); //Actualiza el objeto Camion en la lista de "Camions". Todavía no se actualiza en la base de datos. Se debe invocar el método SaveChanges()
                dbExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se actualizó el Camion correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el Camion: " + ex.Message;
            }
        }
        public List<Camion> ConsultarTodos()
        {
            return dbExamen.Camions
                .OrderBy(c => c.Marca) //OrderBy() es una función que permite ordenar los elementos de una lista de acuerdo a un criterio específico. En este caso, se ordena por el primer apellido
                .ToList(); //ToList() es una función que convierte una lista de datos en una lista de objetos
        }
        public Camion Consultar(string Placa)
        {
            //Expresiones lambda.  => permite definir funciones anónimas o instancias de objetos, sin la creación formal, dependiendo de la lista a la cual se hace referencia
            //FirstOrDefault. Es una función que permite consultar el primer elemento de una lista que cumple las condiciones solicitadas
            return dbExamen.Camions.FirstOrDefault(e => e.Placa == Placa);
        }
        public string Eliminar()
        {
            try
            {
                //Antes de eliminar se debe verificar si el Camion existe
                Camion cam = Consultar(Camion.Placa);
                if (cam == null)
                {
                    return "El Camion con el Placa ingresado no existe, por lo tanto no se puede eliminar";
                }
                //El Camion existe lo podemos eliminar. Se elimina el objeto Camion que se busca, no el que se envía como parámetro
                dbExamen.Camions.Remove(cam); //Eliminar el objeto Camion de la lista de "Camions". Todavía no se elimina de la base de datos. Se debe invocar el método SaveChanges()
                dbExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el Camion correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el Camion: " + ex.Message;
            }
        }
        public string Eliminar(string Placa)
        {
            try
            {
                //Antes de eliminar se debe verificar si el Camion existe
                Camion cam = Consultar(Placa);
                if (cam == null)
                {
                    return "El Camion con el Placa ingresado no existe, por lo tanto no se puede eliminar";
                }
                //El Camion existe lo podemos eliminar. Se elimina el objeto Camion que se busca, no el que se envía como parámetro
                dbExamen.Camions.Remove(cam); //Eliminar el objeto Camion de la lista de "Camions". Todavía no se elimina de la base de datos. Se debe invocar el método SaveChanges()
                dbExamen.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el Camion correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el Camion: " + ex.Message;
            }
        }
    }
}