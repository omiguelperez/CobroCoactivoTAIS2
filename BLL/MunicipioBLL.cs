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
        ApplicationDbContext db = new ApplicationDbContext();
        
        public List<MunicipioDTO> GetMunicipiosByDepartamentoId(int DepartamentoId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
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
