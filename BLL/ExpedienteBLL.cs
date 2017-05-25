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
            
                List<Expediente> lista= db.Expedientes.ToList();
                List<ExpedienteDTO> response = new List<ExpedienteDTO>();
                foreach (Expediente a in lista)
                {
                    response.Add(Expediente.MapeoDALToDTO(a));
                }
                return response;
            
        }

        public ExpedienteDTO FindExpedienteById(int ExpedienteId)
        {

            //List<Expediente> lista = db.Expedientes.ToList();
            var exped = db.Expedientes.Where(t => t.ExpedienteId == ExpedienteId).FirstOrDefault();
                ExpedienteDTO expediente = Expediente.MapeoDALToDTO(exped); // Busca por llave primaria
                return expediente;
            
        }
    }
}
