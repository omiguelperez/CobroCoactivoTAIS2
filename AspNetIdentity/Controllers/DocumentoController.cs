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
        [Route("test")]
        [HttpGet]
        public HttpResponseMessage Test(string archivo)
        {
            var path = @""+HttpContext.Current.Server.MapPath("~/Documentos/" + archivo);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                  new MediaTypeHeaderValue("image/jpg");
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
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

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



                            var filePath = HttpContext.Current.Server.MapPath("~/Documentos/" + postedFile.FileName + extension);

                            postedFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
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



        //[Authorize]
        //[Route("")]
        //public List<DocumentoDTO> GetDocumentoes()
        //{
        //    DocumentoBLL Documento = new DocumentoBLL();
        //    return Documento.GetRecords();
        //}
        //[Authorize]
        //[Route("")]
        //public Respuesta PutProyecto(DocumentoDTO DocumentoDTO)
        //{
        //    DocumentoBLL Documento = new DocumentoBLL();
        //    return Documento.PutProyecto(DocumentoDTO);
        //}
        //[Authorize]
        //[Route("")]
        //public Respuesta DeleteProyecto(DocumentoDTO DocumentoDTO)
        //{
        //    DocumentoBLL Documento = new DocumentoBLL();
        //    return Documento.DeleteProyecto(DocumentoDTO);
        //}
    }
}