using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    
    [RoutePrefix("api/documentos")]
    public class DocumentoController : ApiController
    {
        string Prefix = "api/documentos";// si cambian el prefix trambien cambien esto

        IList<string> AllowedFileExtensionsImages = new List<string> { ".jpg", ".gif", ".png", ".JPG", ".jpeg" };
        IList<string> AllowedFileExtensionsFiles = new List<string> {  ".xls", ".pdf", ".doc", ".docx", ".ppt", ".pptx", ".txt" };
        private string PathImages ="/Files/Images/";
        private string PathDocuments = "/Files/Documents/";

        [Route("expediente/{id}")]
        public List<DocumentoDTO> GetDocumentosByExpediente(int id)
        {
            string pathQuery = HttpContext.Current.Request.Url.PathAndQuery;
            string hostName = HttpContext.Current.Request.Url.ToString().Replace(pathQuery, "");
            hostName += "/"+Prefix + "/";
            DocumentoBLL blldocument = new DocumentoBLL();
            return blldocument.GetDocumentsByExpediente(hostName, id);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage Test(int id)
        {
            var path = "";
            DocumentoDTO document = new DocumentoBLL().FindById(id);
            HttpResponseMessage result;
            if (document != null)
            {
                path = GetPathFromRuta(document.RutaDocumento);
                result = new HttpResponseMessage(HttpStatusCode.OK);
                var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                result.Content = new StreamContent(stream);
                if (AllowedFileExtensionsImages.Contains(document.TipoArchivo))//es imagen
                {
                    string auxxx = "image/" + document.TipoArchivo.Replace(".","");
                    result.Content.Headers.ContentType =
                      new MediaTypeHeaderValue(auxxx);
                }else if (AllowedFileExtensionsFiles.Contains(document.TipoArchivo))
                {
                    if (document.TipoArchivo.Equals(".pdf")){
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    }else if (document.TipoArchivo.Equals(".doc") || document.TipoArchivo.Equals(".docx")){
                        result.Content.Headers.ContentType =new MediaTypeHeaderValue("application/msword");
                    }else{
                        result.Content.Headers.ContentType =new MediaTypeHeaderValue("application/octet-stream");
                    }
                }else
                {
                    result.Content.Headers.ContentType =new MediaTypeHeaderValue("application/octet-stream");
                }
            }else
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);
                //result.Content.Headers.Add("Error","No Existe");
            }
            return result;
        }
        
    
        [Route("Create")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Create()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;
                var Domain = httpRequest.Url.Authority;
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    string RutadocumentoDatabase = "";
                    string TipoArchivoExtension = "";
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensionsImages.Contains(extension) && !AllowedFileExtensionsFiles.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type  .jpg, .gif, .png ,.jpeg,.xls,.pdf,.doc, .docx,.ppt,.pptx,.txt");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            var filePath ="";
                            TipoArchivoExtension = extension;
                            string Nombrefile = DateTime.Now.Year +""+ DateTime.Now.Month +""+ DateTime.Now.Day +""+ DateTime.Now.Hour +""+ DateTime.Now.Minute +""+ DateTime.Now.Second +""+ DateTime.Now.Millisecond+""+ extension;
                            if (AllowedFileExtensionsImages.Contains(extension))
                            {
                                filePath = GetPathFromRuta(PathImages + Nombrefile);//postedFile.FileName);
                                RutadocumentoDatabase = PathImages+ Nombrefile;
                            }
                            else
                            {
                                 filePath = GetPathFromRuta(PathDocuments + Nombrefile);//postedFile.FileName);
                                RutadocumentoDatabase = PathDocuments+ Nombrefile;
                            }


                            postedFile.SaveAs(filePath);

                        }
                    }
                    DocumentoDTO documento = new DocumentoDTO();
                    documento.ExpedienteId= Int32.Parse(httpRequest.Form["ExpedienteId"]);
                    documento.TipoDocumentoId = Int32.Parse(httpRequest.Form["TipoDocumentoId"]);
                    documento.FechaRecepcion= DateTime.Parse(httpRequest.Form["FechaRecepcion"]);
                    documento.FechaDocumento = DateTime.Parse(httpRequest.Form["FechaDocumento"]);
                    documento.OficinaOrigen = httpRequest.Form["OficinaOrigen"];
                    documento.Remitente = httpRequest.Form["Remitente"];
                    documento.FuncionarioRecibe = httpRequest.Form["FuncionarioRecibe"];
                    documento.FuncionarioEntrega = httpRequest.Form["FuncionarioEntrega"];
                    documento.FechaEntrega = DateTime.Parse(httpRequest.Form["FechaEntrega"]);
                    documento.FechaRadicacion = DateTime.Parse(httpRequest.Form["FechaRadicacion"]);
                    documento.RutaDocumento = RutadocumentoDatabase;
                    documento.Estado = "Por Validar";
                    documento.TipoArchivo = TipoArchivoExtension;

                    Respuesta respuesta = new DocumentoBLL().InsertarDocumento(documento);
                    //var message1 = string.Format("File Updated Successfully.");
                    dict.Add("Respuesta", respuesta);
                    if (respuesta!=null)
                    {
                        if (!respuesta.Error)
                        {
                            return Request.CreateResponse(HttpStatusCode.Created, dict);
                        }else
                        {
                            return Request.CreateResponse(HttpStatusCode.InternalServerError, dict);
                        }
                    }
                    else
                    {
                        dict.Add("Respuesta", "Sucedio algun error en el BLL de Documento");
                        return Request.CreateResponse(HttpStatusCode.InternalServerError, dict);
                    }
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }

        private string GetPathFromRuta(string PrePath)
        {
            return HttpContext.Current.Server.MapPath("~" + PrePath);
        }
    }
}