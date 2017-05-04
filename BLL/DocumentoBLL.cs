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

        public Respuesta InsertarDocumento(DocumentoDTO cliente)
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

        public List<DocumentoDTO> GetDocumentsByExpediente(string PathUrl,int ExpedienteId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Documento> lista = db.Documentos.Where(t => t.ExpedienteId.Equals(ExpedienteId)).ToList();
                List<DocumentoDTO> response = new List<DocumentoDTO>();
                foreach (Documento a in lista)
                {
                    DocumentoDTO obj = Documento.MapeoDALToDTO(a);
                    obj.PathUrl = PathUrl + obj.DocumentoId + "";
                    response.Add(obj);
                }
                return response;
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
