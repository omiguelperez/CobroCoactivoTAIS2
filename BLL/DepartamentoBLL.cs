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
        ApplicationDbContext db = new ApplicationDbContext();
        
        public List<DepartamentoDTO> GetDepartamentosByPaisId(int PaisId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
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
