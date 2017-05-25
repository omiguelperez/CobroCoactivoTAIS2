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
    public class DepartamentoBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db;
        public DepartamentoBLL()
        {
            db = new ApplicationDbContext();
        }
        public DepartamentoBLL(ApplicationDbContext context)
        {
            db = context;
        }

        public List<DepartamentoDTO> GetDepartamentosByPaisId(int PaisId)
        {
            using (db)
            {
                return db.Departamentos
                    .Where(t => t.PaisId.Equals(PaisId))
                    .Select(t =>
                        new DepartamentoDTO
                        {
                            DepartamentoId = t.DepartamentoId,
                            Nombre = t.Nombre
                        }
                    ).ToList();
            }
        }

    }
}
