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
    public class ExpedienteBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db = new ApplicationDbContext();

        public Respuesta Insertar(ExpedienteDTO expediente)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    // preparar el cliente para guardar
                    Expediente c = Expediente.MapeoDTOToDAL(expediente);
                   // c.Obligacion = Obligacion.MapeoDTOToDAL(expediente.Obligacion);
                   // c.Obligacion.Expediente = c;
                    //PersonaDTO persona = new PersonaBLL().FindByIdentificacion(c.Obligacion.Persona.Identificacion);
                    //if (persona != null) {//QUIERE DECIR QUE LA PERSONA YA EXISTE
                    //    c.Obligacion.PersonaId = persona.PersonaId;
                    //    c.Obligacion.Persona = null;
                    //}
                    if (expediente.Documentos.Count > 0)
                    {
                        c.Documentos = Documento.ConvertList(expediente.Documentos);
                    }
                    // db.Expedientes.Add(c);
                    //db.Obligaciones.Add(c.Obligacion);

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

        public List<ExpedienteDTO> GetRecords()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Expediente> lista= db.Expedientes.ToList();
                List<ExpedienteDTO> response = new List<ExpedienteDTO>();
                foreach (Expediente a in lista)
                {
                    response.Add(Expediente.MapeoDALToDTO(a));
                }
                return response;
            }
        }

        public ExpedienteDTO FindById(int ExpedienteId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var exped = db.Expedientes.Find(ExpedienteId);
                ExpedienteDTO expediente = Expediente.MapeoDALToDTO(exped); // Busca por llave primaria
                return expediente;
            }
        }
    }
}
