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
    public class PaisBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db;
        public PaisBLL()
        {
            db = new ApplicationDbContext();
        }
        public PaisBLL(ApplicationDbContext context)
        {
            db = context;
        }

        public List<PaisDTO> GetPaises()
        {
            using (db)
            {
                return db.Paises
                    .Select(t =>
                        new PaisDTO
                        {
                            PaisId = t.PaisId,
                            Nombre = t.Nombre
                        }
                    ).ToList();
            }
        }

    }
}
