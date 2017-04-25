using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Expediente
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Expediente MapeoDTOToDAL(ExpedienteDTO DTO)
        {
            Expediente expediente = new Expediente();
            expediente.ExpedienteId = DTO.ExpedienteId;
            expediente.UpdateAt = DTO.UpdateAt;
            expediente.CreatedAt = DTO.CreatedAt;
            expediente.Cuantia = DTO.Cuantia;
            expediente.Descripcion = DTO.Descripcion;
            expediente.DireccionEjecutado = DTO.DireccionEjecutado;
            expediente.DireccionTituloEjecutivo = DTO.DireccionTituloEjecutivo;
            expediente.EntidadEncargada = DTO.EntidadEncargada;
            expediente.FechaRadicacion = DTO.FechaRadicacion;
            expediente.Identificacion = DTO.Identificacion;
            expediente.NaturalezaObligacion = DTO.NaturalezaObligacion;
            expediente.Nombre = DTO.Nombre;
            
            expediente.UbicacionExpediente = DTO.UbicacionExpediente;
            //expediente.ObligacionId = DTO.ObligacionId;
            return expediente;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DAL"></param>
        /// <returns></returns>
        public static ExpedienteDTO MapeoDALToDTO(Expediente DAL)
        {
            ExpedienteDTO expediente = new ExpedienteDTO();
            expediente.ExpedienteId = DAL.ExpedienteId;
            expediente.UpdateAt = DAL.UpdateAt;
            expediente.CreatedAt = DAL.CreatedAt;
            expediente.Cuantia = DAL.Cuantia;
            expediente.Descripcion = DAL.Descripcion;
            expediente.DireccionEjecutado = DAL.DireccionEjecutado;
            expediente.DireccionTituloEjecutivo = DAL.DireccionTituloEjecutivo;
            expediente.EntidadEncargada = DAL.EntidadEncargada;
            expediente.FechaRadicacion = DAL.FechaRadicacion;
            expediente.Identificacion = DAL.Identificacion;
            expediente.NaturalezaObligacion = DAL.NaturalezaObligacion;
            expediente.Nombre = DAL.Nombre;
            expediente.Obligacion = Obligacion.MapeoDALToDTO(DAL.Obligacion);
            expediente.UbicacionExpediente = DAL.UbicacionExpediente;
            expediente.ObligacionId = DAL.ObligacionId;
            return expediente;
        }

        public Expediente()
        {
            Documentos = new List<Documento>();
        }
        public int ExpedienteId { get; set; }
        public string EntidadEncargada { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string DireccionEjecutado { get; set; }
        public float Cuantia { get; set; }
        public string NaturalezaObligacion { get; set; }
        public string DireccionTituloEjecutivo { get; set; }
        public string Descripcion { get; set; }
        public string UbicacionExpediente { get; set; }
        public DateTime FechaRadicacion { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        public int ObligacionId { get; set; }
        [Required]
        public virtual Obligacion Obligacion { get; set; }
        public virtual List<Documento> Documentos { get; set; }
    }
}
