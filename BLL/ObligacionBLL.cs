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
    public class ObligacionBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db = new ApplicationDbContext();

        public Respuesta Insertar(ObligacionDTO obligacion)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    PersonaDTO persona = new PersonaBLL().FindByIdentificacion(obligacion.Persona.Identificacion);
                    if (persona != null)
                    {//QUIERE DECIR QUE LA PERSONA YA EXISTE
                        obligacion.PersonaId = persona.PersonaId;
                        obligacion.Persona = null;
                    }
                    // preparar el cliente para guardar
                    db.Obligaciones.Add(Obligacion.MapeoDTOToDAL(obligacion));

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

        public List<ObligacionDTO> GetRecords()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Obligaciones
                    .Select(t =>
                        new ObligacionDTO
                        {
                            ObligacionId = t.ObligacionId,
                            UpdateAt = t.UpdateAt,
                            CreatedAt = t.CreatedAt,
                            Cuantia = t.Cuantia,
                            Dueda = t.Dueda,
                            Estado = t.Estado,
                            FechaPreinscripcion = t.FechaPreinscripcion,
                            PersonaId = t.PersonaId,
                            ExpedienteId = t.ExpedienteId,
                            TipoObligacionId = t.TipoObligacionId,
                            Expediente= db.Expedientes.Select(s => new ExpedienteDTO
                            {
                                EntidadEncargada=s.EntidadEncargada,
                                Descripcion=s.Descripcion,
                                Cuantia=s.Cuantia,
                                Identificacion=s.Identificacion,
                                DireccionEjecutado=s.DireccionEjecutado,
                                FechaRadicacion=s.FechaRadicacion,
                                NaturalezaObligacion=s.NaturalezaObligacion,
                                ExpedienteId=s.ExpedienteId,
                                UbicacionExpediente=s.UbicacionExpediente,
                                Nombre=s.Nombre,
                                CreatedAt=s.CreatedAt,
                                UpdateAt=s.UpdateAt,
                                DireccionTituloEjecutivo=s.DireccionTituloEjecutivo
                            }).Where(r => r.ExpedienteId.Equals(t.ExpedienteId)).FirstOrDefault()
                        }
                    ).ToList();
            }
        }

        public ObligacionDTO FindById(int ObligacionId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var obliga = db.Obligaciones.Find(ObligacionId);
                ObligacionDTO expediente = Obligacion.MapeoDALToDTO(obliga); // Busca por llave primaria
                return expediente;
            }
        }

    }
}
