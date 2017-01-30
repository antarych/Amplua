using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FileManagement
{
    public class MultipartStreamProvider : MultipartFormDataStreamProvider
    {
        public MultipartStreamProvider(string rootPath) : base(rootPath)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var fileName = headers?.ContentDisposition?.FileName?.Trim('"');
            fileName = fileName ?? base.GetLocalFileName(headers);
            return Path.GetFileName(fileName);
        }
    }
}
