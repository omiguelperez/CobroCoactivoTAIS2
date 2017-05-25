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
        ApplicationDbContext db;
        public TipoDocumentoBLL()
        {
            db = new ApplicationDbContext();
        }
        public TipoDocumentoBLL(ApplicationDbContext context)
        {
            db = context;
        }

        public List<TipoDocumentoDTO> GetTipoDocumentos()
        {
            using (db)
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
