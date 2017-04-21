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

        public Respuesta Insertar(ObligacionDTO cliente)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    // preparar el cliente para guardar
                    db.Obligaciones.Add(Obligacion.MapeoDTOToDAL(cliente));

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
                        }
                    ).ToList();
            }
        }

    }
}
