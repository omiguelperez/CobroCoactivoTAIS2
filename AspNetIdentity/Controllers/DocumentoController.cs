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
        IList<string> AllowedFileExtensionsImages = new List<string> { ".jpg", ".gif", ".png", ".JPG", ".jpeg" };
        IList<string> AllowedFileExtensionsFiles = new List<string> {  ".xls", ".pdf", ".doc", ".docx", ".ppt", ".pptx", ".txt" };
        private string PathImages ="/Files/Images/";
        private string PathDocuments = "/Files/Documents/";
        //[Authorize] para cuestion de pruebas esta api puede ser accedida sin estar autenticado
        //[Route("create")]
        //public Respuesta PostProyecto(DocumentoDTO DocumentoDTO)
        //{
        //    Respuesta response = new Respuesta();
        //    if (DocumentoDTO.Identificacion.Equals(DocumentoDTO.Documento.Persona.Identificacion))
        //    {
        //        DocumentoBLL Documento = new DocumentoBLL();
        //        response = Documento.Insertar(DocumentoDTO);
        //    }
        //    else
        //    {
        //        response.Mensaje = "La Identificacion del Documento no Coincide con la Identificacion de la Persona.";
        //        response.Error = true;
        //        response.FilasAfectadas = 0;
        //    }
        //    return response;
        //}
        //[Route("create")]
        //public Task<HttpResponseMessage> PostFile()
        //{
        //    HttpRequestMessage request = this.Request;
        //    if (!request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
        //    var provider = new MultipartFormDataStreamProvider(root);

        //    var task = request.Content.ReadAsMultipartAsync(provider).
        //        ContinueWith<HttpResponseMessage>(o =>
        //        {

        //            //string file1 = provider.BodyPartFileNames.First().Value;
        //    // this is the file name on the server where the file was saved 

        //    return new HttpResponseMessage()
        //            {
        //                Content = new StringContent("File uploaded.")
        //            };
        //        }
        //    );
        //    return task;
        //}


        //[Route("create")]
        //public HttpResponseMessage Post()
        //{
        //    HttpResponseMessage result = null;
        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count > 0)
        //    {
        //        var docfiles = new List<string>();
        //        foreach (string file in httpRequest.Files)
        //        {
        //            var postedFile = httpRequest.Files[file];
        //            var filePath = HttpContext.Current.Server.MapPath("~/Documentos/" + postedFile.FileName);
        //            postedFile.SaveAs(filePath);

        //            docfiles.Add(filePath);
        //        }
        //        result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    return result;
        //}
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
        //public IHttpActionResult Test()
        //{
        //    var stream = new MemoryStream();

        //    var result = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ByteArrayContent(stream.GetBuffer())
        //    };
        //    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        //    {
        //        FileName = "Captura.PNG"
        //    };
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

        //    var response = ResponseMessage(result);

        //    return response;
        //}

    
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

                    Respuesta respuesta = new DocumentoBLL().Insertar(documento);
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