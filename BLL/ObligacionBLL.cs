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

        public Respuesta InsertarObligacion(ObligacionDTO obligacion)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    PersonaDTO persona = new PersonaBLL().FindPersonaByIdentificacion(obligacion.Persona.Identificacion);
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

        public List<ObligacionDTO> GetObligaciones()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //IQuereable
                //var query = db.Obligaciones.Where(t => t.Cuantia > 0);
                //if (..)
                //{
                //    query = query.Where(t => t.Dueda > 0);
                //}
                //else {
                //    query = query.Where(t => t.Dueda < 100000);
                //}
                //var result = query.ToList();

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
                            Expediente = new ExpedienteDTO
                            {
                                EntidadEncargada = t.Expediente.EntidadEncargada,
                                Descripcion = t.Expediente.Descripcion,
                                Cuantia = t.Expediente.Cuantia,
                                Identificacion = t.Expediente.Identificacion,
                                DireccionEjecutado = t.Expediente.DireccionEjecutado,
                                FechaRadicacion = t.Expediente.FechaRadicacion,
                                NaturalezaObligacion = t.Expediente.NaturalezaObligacion,
                                ExpedienteId = t.Expediente.ExpedienteId,
                                UbicacionExpediente = t.Expediente.UbicacionExpediente,
                                Nombre = t.Expediente.Nombre,
                                CreatedAt = t.Expediente.CreatedAt,
                                UpdateAt = t.Expediente.UpdateAt,
                                DireccionTituloEjecutivo = t.Expediente.DireccionTituloEjecutivo
                            }
                        }
                    ).ToList();
            }
        }

        public ObligacionDTO FindObligacionById(int ObligacionId)
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
