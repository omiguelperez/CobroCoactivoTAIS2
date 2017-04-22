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
    public class TipoDocumentoBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db = new ApplicationDbContext();

        public Respuesta Insertar(TipoDocumentoDTO cliente)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    // preparar el cliente para guardar
                    db.TiposDocumentos.Add(TipoDocumento.MapeoDTOToDAL(cliente));

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

        public List<TipoDocumentoDTO> GetRecords()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.TiposDocumentos
                    .Select(t =>
                        new TipoDocumentoDTO
                        {
                            TipoDocumentoId = t.TipoDocumentoId,
                            UpdateAt = t.UpdateAt,
                            CreatedAt = t.CreatedAt,
                            Nombre = t.Nombre
                        }
                    ).ToList();
            }
        }

    }
}
