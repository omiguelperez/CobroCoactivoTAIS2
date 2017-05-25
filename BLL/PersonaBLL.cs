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
    public class PersonaBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db;
        public PersonaBLL()
        {
            db = new ApplicationDbContext();
        }
        public PersonaBLL(ApplicationDbContext context)
        {
            db = context;
        }

        public Respuesta InsertarPersona(PersonaDTO cliente)
        {
            using (db)
            {
                try
                {
                    // preparar el cliente para guardar
                    PersonaDTO persona = new PersonaBLL(db).FindPersonaByIdentificacion(cliente.Identificacion);
                    if (persona != null)
                    {//QUIERE DECIR QUE LA PERSONA YA EXISTE
                        respuesta.Mensaje = "Ya Existe la PErsona";
                        respuesta.Error = true;
                    }
                    else {
                        Persona c = Persona.MapeoDTOToDAL(cliente);
                        if (cliente.Obligaciones.Count > 0)
                        {
                            c.Obligaciones = Obligacion.ConvertList(cliente.Obligaciones);
                        }
                        db.Personas.Add(c);
                        respuesta.Error = false;
                    }

                    // preparar la respuesta
                    respuesta.FilasAfectadas = db.SaveChanges();
                    respuesta.Mensaje = "Se realizó la operación satisfactoriamente";
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    respuesta.Mensaje = ex.Message;
                    respuesta.FilasAfectadas = 0;
                    respuesta.Error = true;
                }
                catch (Exception ex)
                {
                    respuesta.Mensaje = ex.Message;
                    respuesta.FilasAfectadas = 0;
                    respuesta.Error = true;
                }

                return respuesta;
            }
        }
        public PersonaDTO FindPersonaByIdentificacion(String Identificacion)
        {
            using (db)
            {
                Persona person = db.Personas.FirstOrDefault(t => t.Identificacion.Equals(Identificacion));// Busca por llave primaria
                PersonaDTO persona=null;
                if (person!=null)
                {
                     persona= Persona.MapeoDALToDTO(person); 
                }
                return persona;
            }
        }
        public PersonaDTO FindPersonaById(int PersonaId)
        {
            using (db)
            {
                return db.Personas
                            .Select(t =>
                                new PersonaDTO
                                {
                                    PersonaId = t.PersonaId,
                                    UpdateAt = t.UpdateAt,
                                    CreatedAt = t.CreatedAt,
                                    Pais = new PaisDTO
                                    {
                                        PaisId = t.Pais.PaisId,
                                        Nombre = t.Pais.Nombre
                                    },
                                    Nacionalidad=t.Nacionalidad,
                                    MunicipioId=t.MunicipioId,
                                    Municipio=new MunicipioDTO
                                    {
                                        MunicipioId = t.Municipio.MunicipioId,
                                        Nombre = t.Municipio.Nombre
                                    },
                                    Identificacion=t.Identificacion,
                                    FechaNacimiento=t.FechaNacimiento,
                                    Email=t.Email,
                                    Apellidos=t.Apellidos,
                                    Departamento=t.Departamento,
                                    Nombres=t.Nombres,
                                    Direccion=t.Direccion,
                                    PaisCorrespondencia=t.PaisCorrespondencia,
                                    PaisId=t.PaisId,
                                    PaisNacimiento=t.PaisNacimiento,
                                    Sexo=t.Sexo,
                                    Telefono=t.Telefono,
                                    TipoPersonaId=t.TipoPersonaId,
                                    TipoPersona=new TipoPersonaDTO
                                    {
                                        Nombre=t.TipoPersona.Nombre,
                                    }
                                }
                            ).Where(t=>t.PersonaId.Equals(PersonaId)).FirstOrDefault();
            }
        }
    }
}
