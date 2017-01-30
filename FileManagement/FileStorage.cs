using System.Web;
using Journalist;

namespace FileManagement
{
    public class FileStorage
    {
        public FileStorage(
            string imageStorageFolder,
            string[] allowedImageExtensions)
        {
            Require.NotEmpty(imageStorageFolder, nameof(imageStorageFolder));
            Require.NotNull(allowedImageExtensions, nameof(allowedImageExtensions));

            _imageStoragePath = imageStorageFolder;
            AllowedImageExtensions = allowedImageExtensions;
        }

        public string ImageStorageFolder => HttpContext.Current.Server.MapPath(_imageStoragePath);

        public string[] AllowedImageExtensions { get; private set; }

        private readonly string _imageStoragePath;
    }
}
