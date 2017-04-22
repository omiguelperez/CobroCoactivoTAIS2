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
    public class TipoCobroBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db = new ApplicationDbContext();

        public Respuesta Insertar(TipoCobroDTO cliente)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    // preparar el cliente para guardar
                    db.TiposCobros.Add(TipoCobro.MapeoDTOToDAL(cliente));

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

        public List<TipoCobroDTO> GetRecords()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.TiposCobros
                    .Select(t =>
                        new TipoCobroDTO
                        {
                            TipoCobroId = t.TipoCobroId,
                            UpdateAt = t.UpdateAt,
                            CreatedAt = t.CreatedAt,
                            Nombre = t.Nombre
                        }
                    ).ToList();
            }
        }

    }
}
