using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PersonaBLL
    {
        Respuesta respuesta = new Respuesta();
        Contexto db = new Contexto();

        public Respuesta Insertar(PersonaDTO cliente)
        {
            using (db = new Contexto())
            {
                try
                {
                    // preparar el cliente para guardar
                    Persona c = new Persona();
                    c.PersonaId = cliente.PersonaId;
                    c.Direccion = cliente.Direccion;
                    c.Nombres = cliente.Nombres;
                    c.Telefono = cliente.Telefono;
                    c.Sexo = cliente.Sexo;
                    c.Identificacion = cliente.Identificacion;
                    db.Personas.Add(c);

                    // preparar la respuesta
                    respuesta.FilasAfectadas = db.SaveChanges();
                    respuesta.Mensaje = "Se realizó la operación satisfactoriamente";
                    respuesta.Error = false;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    respuesta.Mensaje = ex.Message;
                    respuesta.FilasAfectadas = 0;
                    respuesta.Error = true;
                }
                catch (Exception ex)
                {
                    respuesta.Mensaje = ex.Message;
                    respuesta.FilasAfectadas = 0;
                    respuesta.Error = true;
                }

                return respuesta;
            }
        }
    }
}
