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
        public static Obligacion MapeoDTOToDAL(ObligacionDTO DTO)
        {
            Obligacion obligacion = new Obligacion();
            obligacion.ObligacionId = DTO.ObligacionId;
            obligacion.UpdateAt = DTO.UpdateAt;
            obligacion.CreatedAt = DTO.CreatedAt;
            obligacion.Cuantia = DTO.Cuantia;
            obligacion.Dueda = DTO.Dueda;
            obligacion.Estado = DTO.Estado;
            if (DTO.Expediente != null)
            {
                obligacion.Expediente = Expediente.MapeoDTOToDAL(DTO.Expediente);
            }
            if (DTO.Persona != null)
            {
                obligacion.Persona = Persona.MapeoDTOToDAL(DTO.Persona);
            }
            obligacion.FechaPreinscripcion = DTO.FechaPreinscripcion;
            obligacion.PersonaId = DTO.PersonaId;
            obligacion.ExpedienteId = DTO.ExpedienteId;
            return obligacion;
        }

        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DAL</returns>
        public static ObligacionDTO MapeoDALToDTO(Obligacion DAL)
        {
            ObligacionDTO obligacion = new ObligacionDTO();
            obligacion.ObligacionId = DAL.ObligacionId;
            obligacion.UpdateAt = DAL.UpdateAt;
            obligacion.CreatedAt = DAL.CreatedAt;
            obligacion.Cuantia = DAL.Cuantia;
            obligacion.Dueda = DAL.Dueda;
            obligacion.Estado = DAL.Estado;
            if (DAL.Expediente != null)
            {
                obligacion.Expediente = Expediente.MapeoDALToDTO(DAL.Expediente);
            }
            if (DAL.Persona != null)
            {
                obligacion.Persona = Persona.MapeoDALToDTO(DAL.Persona);
            }
            obligacion.FechaPreinscripcion = DAL.FechaPreinscripcion;
            obligacion.PersonaId = DAL.PersonaId;
            obligacion.ExpedienteId = DAL.ExpedienteId;
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
                Obligaciones.Add(MapeoDTOToDAL(item));
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
