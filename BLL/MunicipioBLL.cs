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
    public class MunicipioBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db;
        public MunicipioBLL()
        {
            db = new ApplicationDbContext();
        }
        public MunicipioBLL(ApplicationDbContext context)
        {
            db = context;
        }

        public List<MunicipioDTO> GetMunicipiosByDepartamentoId(int DepartamentoId)
        {
            using (db)
            {
                var response=db.Municipios
                   .Where(t => t.DepartamentoId == DepartamentoId)
                   .Select(t =>
                       new MunicipioDTO
                       {
                           MunicipioId = t.MunicipioId,
                           Nombre = t.Nombre
                       }
                   ).ToList();
                return response;
            }
        }

    }
}
