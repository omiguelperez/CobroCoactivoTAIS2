using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApplicationUserDTO
    {
        public int AplicationUserId { get; set; }
        public string Username { get; set; }
        public PersonaDTO Persona { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Boolean ConfirmacionEmail { get; set; }
        public virtual List<CobroDTO> Cobros { get; set; }
        public string Rol { get; set; }//Esto lo hago para no hacer el DTO de Rol, si en algun momento se hace necesario se agrega
    }
}
