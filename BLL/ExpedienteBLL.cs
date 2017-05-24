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
    public class ExpedienteBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db;
        public ExpedienteBLL()
        {
            db = new ApplicationDbContext();
        }
        public ExpedienteBLL(ApplicationDbContext context)
        {
            db= context;
        }

        public List<ExpedienteDTO> GetExpedientes()
        {
            using (db)
            {
                List<Expediente> lista= db.Expedientes.ToList();
                List<ExpedienteDTO> response = new List<ExpedienteDTO>();
                foreach (Expediente a in lista)
                {
                    response.Add(Expediente.MapeoDALToDTO(a));
                }
                return response;
            }
        }

        public ExpedienteDTO FindExpedienteById(int ExpedienteId)
        {
            using (db)
            {
                var exped = db.Expedientes.Find(ExpedienteId);
                ExpedienteDTO expediente = Expediente.MapeoDALToDTO(exped); // Busca por llave primaria
                return expediente;
            }
        }
    }
}
