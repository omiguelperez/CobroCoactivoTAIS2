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
    public class DocumentoBLL
    {
        Respuesta respuesta = new Respuesta();
        ApplicationDbContext db = new ApplicationDbContext();

        public Respuesta Insertar(DocumentoDTO cliente)
        {
            using (db = new ApplicationDbContext())
            {
                try
                {
                    // preparar el cliente para guardar
                    db.Documentos.Add(Documento.MapeoDTOToDAL(cliente));

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

        public DocumentoDTO FindById(int Id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Documento documento = db.Documentos.FirstOrDefault(t => t.DocumentoId.Equals(Id));// Busca por llave primaria
                DocumentoDTO document = null;
                if (documento != null)
                {
                    document = Documento.MapeoDALToDTO(documento);
                }
                return document;
            }
        }

    }
}
