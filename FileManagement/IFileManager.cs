using Common;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileManagement
{
    public interface IFileManager
    {
        Stream GetImage(string imageName);

        Task<Image> UploadImageAsync(HttpContent content);
    }
}
