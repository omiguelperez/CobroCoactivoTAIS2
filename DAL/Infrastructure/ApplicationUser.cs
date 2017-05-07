using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Entities;
namespace DAL.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static ApplicationUser Mapeo(ApplicationUserDTO DTO)
        {
            ApplicationUser c = new ApplicationUser();
            c.Email = DTO.Email;
            c.FirstName = DTO.FirstName;
            c.LastName = DTO.LastName;
            if (DTO.Persona != null)
            {
                c.Persona = Persona.MapeoDTOToDAL(DTO.Persona);
            }
            c.UserName = DTO.Username;
            return c;
        }
        public ApplicationUser()
        {
            Cobros = new List<Cobro>();
        }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public byte Level { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        public virtual List<Cobro> Cobros { get; set; }
        //Rest of code is removed for brevity
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

}