using DAL.Infrastructure;
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
    public class Cobro
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Cobro Mapeo(CobroDTO item)
        {
            Cobro cobro = new Cobro();
            cobro.CobroId = item.CobroId;
            cobro.CreatedAt = item.CreatedAt;
            cobro.Nombre = item.Nombre;
            if (item.TipoCobro != null) { 
                cobro.TipoCobro = TipoCobro.Mapeo(item.TipoCobro);
            }
            cobro.UpdateAt = item.UpdateAt;
            cobro.UsuarioId = item.UsuarioId;
            if (item.Usuario!=null)
            {
                cobro.Usuario = ApplicationUser.Mapeo(item.Usuario);
            }
            cobro.TipoCobroId = item.TipoCobroId;
            return cobro;
        }

        /// <summary>
        /// Este metodo Convierte una Lista DTO de Cobros a DAL, Recuerde que Para Mapear Una SubLista desde el controlador lo puede hacer
        /// </summary>
        /// <param name="ListaDTO">Lista De tipo DTO</param>
        /// <returns>Lista de Tipo DAL</returns>
        public static List<Cobro> ConvertList(List<CobroDTO> ListaDTO)
        {
            List<Cobro> Cobros = new List<Cobro>();
            foreach (CobroDTO item in ListaDTO)
            {
                Cobros.Add(Mapeo(item));
            }
            return Cobros;
        }
        public int CobroId { get; set; }
        public string Nombre { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
        public int TipoCobroId { get; set; }
        public virtual TipoCobro TipoCobro { get; set; }
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { set; get; }
        public virtual List<Obligacion> Obligaciones { get; set; }
    }
}
