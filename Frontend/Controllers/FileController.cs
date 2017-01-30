using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using FileManagement;
using Frontend.Authorization;
using Frontend.Models;
using Journalist;
using UserManagement.Domain;

namespace Frontend.Controllers
{
    public class FileController : ApiController
    {
        private readonly IFileManager _fileManager;

        public FileController(IFileManager fileManager)
        {
            Require.NotNull(fileManager, nameof(fileManager));

            _fileManager = fileManager;
        }

        [HttpGet]
        [Route("image/{imageName}")]
        public HttpResponseMessage GetImage(string imageName)
        {
            return GetAnyFile(() => _fileManager.GetImage(imageName));
        }

        [HttpPost]
        [Route("image")]
        [Authorization(AccountRoles.User)]
        public async Task<ImageModel> UploadImage()
        {
            try
            {
                var image = await _fileManager.UploadImageAsync(Request.Content);

                return new ImageModel(Path.GetFileName(image.BigImage.LocalPath));
            }
            catch (NotSupportedException)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            catch (InvalidDataException)
            {
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);
            }
        }

        private HttpResponseMessage GetAnyFile(Func<Stream> getStream)
        {
            Stream stream;
            try
            {
                stream = getStream();
            }
            catch (FileNotFoundException)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return response;
        }
    }
}
