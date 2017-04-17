using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL.Infrastructure;

namespace DAL
{
    public class Obligacion
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Obligacion Mapeo(ObligacionDTO item)
        {
            Obligacion obligacion = new Obligacion();
            obligacion.ObligacionId = item.ObligacionId;
            obligacion.UpdateAt = item.UpdateAt;
            obligacion.CreatedAt = item.CreatedAt;
            obligacion.Cuantia = item.Cuantia;
            obligacion.Dueda = item.Dueda;
            obligacion.Estado = item.Estado;
            if (item.Expediente != null)
            {
                obligacion.Expediente = Expediente.Mapeo(item.Expediente);
            }
            if (item.Persona != null)
            {
                obligacion.Persona = Persona.MapeoDTOToDAL(item.Persona);
            }
            obligacion.FechaPreinscripcion = item.FechaPreinscripcion;
            obligacion.PersonaId = item.PersonaId;
            obligacion.ExpedienteId = item.ExpedienteId;
            return obligacion;
        }

        /// <summary>
        /// Este metodo Convierte una Lista DTO de Cobros a DAL, Recuerde que Para Mapear Una SubLista desde el controlador lo puede hacer
        /// </summary>
        /// <param name="ListaDTO">Lista De tipo DTO</param>
        /// <returns>Lista de Tipo DAL</returns>
        public static List<Obligacion> ConvertList(List<ObligacionDTO> ListaDTO)
        {
            List<Obligacion> Obligaciones = new List<Obligacion>();
            foreach (ObligacionDTO item in ListaDTO)
            {
                Obligaciones.Add(Mapeo(item));
            }
            return Obligaciones;
        }
        public int ObligacionId { get; set; }
        public float Cuantia { get; set; }
        public float Dueda { get; set; }
        public DateTime FechaPreinscripcion { get; set; }
        public string Estado { get; set; }
        public virtual List<Cobro> Cobros { get; set; }
        public int ExpedienteId { get; set; }
        public virtual Expediente Expediente { get; set; }
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt =new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
    }
}
