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
    public class TipoObligacionBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db = new ApplicationDbContext();
        
        public List<TipoObligacionDTO> GetTipoObligaciones()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.TiposObligaciones
                    .Select(t =>
                        new TipoObligacionDTO
                        {
                            TipoObligacionId = t.TipoObligacionId,
                            UpdateAt = t.UpdateAt,
                            CreatedAt = t.CreatedAt,
                            Nombre = t.Nombre
                        }
                    ).ToList();
            }
        }

    }
}
