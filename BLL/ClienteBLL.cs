using Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL
    {
        Respuesta respuesta = new Respuesta();
        Contexto db = new Contexto();

        public Respuesta Insertar(ClienteDTO cliente)
        {
            using(db = new Contexto())
            {
                try
                {
                    // preparar el cliente para guardar
                    Cliente c = new Cliente();
                    c.ClienteId = cliente.ClienteId;
                    c.Direccion = cliente.Direccion;
                    c.Nombre = cliente.Nombre;
                    c.Telefono = cliente.Telefono;
                    db.Clientes.Add(c);
                    
                    // preparar la respuesta
                    respuesta.FilasAfectadas = db.SaveChanges();
                    respuesta.Mensaje = "Se realizó la operación satisfactoriamente";
                    respuesta.Error = false;
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

        public List<ClienteDTO> GetRecords()
        {
            using(Contexto db = new Contexto())
            {
                return db.Clientes
                    .Select(t => 
                        new ClienteDTO 
                        {
                            ClienteId = t.ClienteId,
                            Nombre = t.Nombre,
                            Direccion = t.Direccion,
                            Telefono = t.Telefono
                        }
                    ).ToList();
            }
        }

        public async Task<Respuesta> Delete(int clienteId)
        {

            try
            {
                var user = await db.Clientes.FindAsync(clienteId);
                if (user == null)
                {
                    respuesta.Error = true;
                    respuesta.FilasAfectadas = 0;
                    respuesta.Mensaje = "El Usuario no exixte";
                }
                else
                {
                    db.Clientes.Remove(user);
                    // preparar la respuesta
                    respuesta.FilasAfectadas = db.SaveChanges();
                    respuesta.Mensaje = "Se realizó Elimino el usuario satisfactoriamente";
                    respuesta.Error = false;
                }
                return respuesta;

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

        public Respuesta ActualizarCliente(ClienteDTO cliente)
        {
            var user = db.Clientes.SingleOrDefault(b => b.ClienteId == cliente.ClienteId);
            Respuesta respuesta = new Respuesta();
            if (user != null)
            {
                user.Direccion = cliente.Direccion;
                user.Telefono = cliente.Telefono;
                cliente.Nombre = cliente.Nombre;
                respuesta.FilasAfectadas = db.SaveChanges();
                respuesta.Mensaje = "Información Actualizada";
                respuesta.Error = false;
            }

            respuesta.FilasAfectadas = 0;
            respuesta.Mensaje = "Información No Actualizada";
            respuesta.Error = true;
            return respuesta;
        }
    }
}
