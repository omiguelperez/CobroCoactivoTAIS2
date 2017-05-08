using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Documento
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Documento MapeoDTOToDAL(DocumentoDTO item)
        {
            try
            {
                Documento documento = new Documento();
                documento.DocumentoId = item.DocumentoId;
                documento.UpdateAt = item.UpdateAt;
                documento.CreatedAt = item.CreatedAt;
                if (item.Expediente != null)
                {
                    documento.Expediente = Expediente.MapeoDTOToDAL(item.Expediente);
                }
                documento.ExpedienteId = item.ExpedienteId;
                documento.FechaDocumento = item.FechaDocumento;
                documento.FechaEntrega = item.FechaEntrega;
                documento.FechaRadicacion = item.FechaRadicacion;
                documento.FechaRecepcion = item.FechaRecepcion;
                documento.FuncionarioEntrega = item.FuncionarioEntrega;
                documento.FuncionarioRecibe = item.FuncionarioRecibe;
                documento.OficinaOrigen = item.OficinaOrigen;
                documento.Remitente = item.Remitente;
                documento.RutaDocumento = item.RutaDocumento;
                documento.TipoArchivo = item.TipoArchivo;
                documento.Estado = item.Estado;
                if (item.TipoDocumento != null)
                {
                    documento.TipoDocumento = TipoDocumento.MapeoDTOToDAL(item.TipoDocumento);
                }
                documento.TipoDocumentoId = item.TipoDocumentoId;
                return documento;

            }catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo convierte un DAL a DTO
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DTO</returns>
        public static DocumentoDTO MapeoDALToDTO(Documento DAL)
        {
            try
            {
                DocumentoDTO documento = new DocumentoDTO();
                documento.DocumentoId = DAL.DocumentoId;
                documento.UpdateAt = DAL.UpdateAt;
                documento.CreatedAt = DAL.CreatedAt;
                if (DAL.Expediente != null)
                {
                    documento.Expediente = Expediente.MapeoDALToDTO(DAL.Expediente);
                }
                documento.ExpedienteId = DAL.ExpedienteId;
                documento.FechaDocumento = DAL.FechaDocumento;
                documento.FechaEntrega = DAL.FechaEntrega;
                documento.FechaRadicacion = DAL.FechaRadicacion;
                documento.FechaRecepcion = DAL.FechaRecepcion;
                documento.FuncionarioEntrega = DAL.FuncionarioEntrega;
                documento.FuncionarioRecibe = DAL.FuncionarioRecibe;
                documento.OficinaOrigen = DAL.OficinaOrigen;
                documento.Remitente = DAL.Remitente;
                documento.RutaDocumento = DAL.RutaDocumento;
                documento.TipoArchivo = DAL.TipoArchivo;
                documento.Estado = DAL.Estado;
                if (DAL.TipoDocumento != null)
                {
                    documento.TipoDocumento = TipoDocumento.MapeoDALToDTO(DAL.TipoDocumento);
                }
                documento.TipoDocumentoId = DAL.TipoDocumentoId;
                return documento;

            }catch(Exception)
            {
                return null;
            }
        }


        /// <summary>
        /// Este metodo Convierte una Lista DTO de Cobros a DAL, Recuerde que Para Mapear Una SubLista desde el controlador lo puede hacer
        /// </summary>
        /// <param name="ListaDTO">Lista De tipo DTO</param>
        /// <returns>Lista de Tipo DAL</returns>
        public static List<Documento> ConvertList(List<DocumentoDTO> ListaDTO)
        {
            try
            {
                List<Documento> Obligaciones = new List<Documento>();
                foreach (DocumentoDTO item in ListaDTO)
                {
                    Obligaciones.Add(MapeoDTOToDAL(item));
                }
                return Obligaciones;
            }catch(Exception)
            {
                return null;
            }
        }
    }
}
