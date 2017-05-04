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
        
        public List<TipoCobroDTO> GetTiposCobros()
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
