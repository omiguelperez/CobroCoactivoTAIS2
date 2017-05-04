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

        public List<TipoDocumentoDTO> GetTipoDocumentos()
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
