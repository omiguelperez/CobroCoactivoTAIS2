using DAL;
using DAL.Infrastructure;
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
        ApplicationDbContext db = new ApplicationDbContext();

        public Respuesta InsertarPersona(PersonaDTO cliente)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    // preparar el cliente para guardar
                    Persona c = Persona.MapeoDTOToDAL(cliente);
                    if (cliente.Obligaciones.Count > 0)
                    {
                        c.Obligaciones = Obligacion.ConvertList(cliente.Obligaciones);
                    }
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
        public PersonaDTO FindPersonaByIdentificacion(String Identificacion)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Persona person = db.Personas.FirstOrDefault(t => t.Identificacion.Equals(Identificacion));// Busca por llave primaria
                PersonaDTO persona=null;
                if (person!=null)
                {
                     persona= Persona.MapeoDALToDTO(person); 
                }
                return persona;
            }
        }
    }
}
