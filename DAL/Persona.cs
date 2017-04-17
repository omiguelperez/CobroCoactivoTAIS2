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
    public class Persona
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Persona MapeoDTOToDAL(PersonaDTO DTO)
        {
            Persona c = new Persona();
            c.Apellidos = DTO.Apellidos;
            c.Direccion = DTO.Direccion;
            c.Identificacion = DTO.Identificacion;
            c.Nombres = DTO.Nombres;
            c.PersonaId = DTO.PersonaId;
            c.Sexo = DTO.Sexo;
            c.Telefono = DTO.Telefono;
            return c;
        }

        /// <summary>
        /// Este metodo convierte un DAL a DTO
        /// </summary>
        /// <param name="DAL">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static PersonaDTO MapeoDALToDTO(Persona DAL)
        {
            PersonaDTO c = new PersonaDTO();
            c.Apellidos = DAL.Apellidos;
            c.Direccion = DAL.Direccion;
            c.Identificacion = DAL.Identificacion;
            c.Nombres = DAL.Nombres;
            c.PersonaId = DAL.PersonaId;
            c.Sexo = DAL.Sexo;
            c.Telefono = DAL.Telefono;
            return c;
        }
        public Persona()
        {
            Obligaciones = new List<Obligacion>();
        }

        public int PersonaId { get; set; }


        // [Column("Fecha", TypeName = "datetime2", Order = 1)]
        [Required]
        [Index(IsUnique = true)]
        [StringLength(15)]
        //[Column(TypeName = "VARCHAR")]
        public string Identificacion { get; set; }
        [Required]
        [StringLength(35)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(35)]
        public string Apellidos { get; set; }
        [Required]
        public string Sexo { get; set; }
        public int Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        public virtual List<Obligacion> Obligaciones { get; set; }
    }
}
