using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using Journalist;
using Journalist.Extensions;

namespace FileManagement
{
    public class FileManager:IFileManager
    {
        public FileManager(FileStorage fileStorage)
        {
            Require.NotNull(fileStorage, nameof(fileStorage));

            _fileStorage = fileStorage;
            CreateFolder();
        }

        public Stream GetImage(string imageName)
        {
            var fullPath = Path.Combine(_fileStorage.ImageStorageFolder, imageName);
            var exists = File.Exists(fullPath);
            if (!exists)
            {
                throw new FileNotFoundException();
            }

            return new FileStream(fullPath, FileMode.Open, FileAccess.Read);
        }

        public async Task<Image> UploadImageAsync(HttpContent content)
        {
            Require.NotNull(content, nameof(content));
            var bigFilePath = await UploadAnyFileAsync(
                content,
                _fileStorage.AllowedImageExtensions,
                _fileStorage.ImageStorageFolder);

            //var smallFilePath = _imageResizer.ResizeImageByLengthOfLongestSide(new Uri(bigFilePath));

            var bigFileName = Path.GetFileName(bigFilePath);
            var newBigFileName = GenerateRandomFileName(bigFileName);
            var newBigFilePath = Path.Combine(_fileStorage.ImageStorageFolder, newBigFileName);
            RenameFile(bigFilePath, newBigFilePath);

            return new Image(new Uri(newBigFilePath));
        }

        private string GenerateRandomFileName(string fileName)
        {
            var randomFileName = Path.GetRandomFileName();
            return Path.ChangeExtension(randomFileName, GetFileExtension(fileName));
        }

        private void RenameFile(string originalFullName, string newFileFullName)
        {
            File.Move(originalFullName, newFileFullName);
        }

        private void CreateFolder()
        {
            if (!Directory.Exists(_fileStorage.ImageStorageFolder))
            {
                Directory.CreateDirectory(_fileStorage.ImageStorageFolder);
            }
        }

        private async Task<string> UploadAnyFileAsync(
            HttpContent httpContent,
            string[] allowedExtensions,
            string folderPath)
        {
            if (!httpContent.IsMimeMultipartContent("form-data"))
            {
                throw new NotSupportedException();
            }

            var provider = new MultipartStreamProvider(folderPath);
            await httpContent.ReadAsMultipartAsync(provider);
            var fullFileName = provider.FileData.First().LocalFileName;
            var extension = GetFileExtension(fullFileName);
            if (!allowedExtensions.Contains(extension))
            {
                await Task.Factory.StartNew(() => File.Delete(fullFileName));
                throw new InvalidDataException("Extension {0} is not allowed".FormatString(extension));
            }

            return fullFileName;
        }

        private string GetFileExtension(string fileName)
        {
            return Path.GetExtension(fileName).TrimStart('.');
        }

        private readonly FileStorage _fileStorage;
    }
}
