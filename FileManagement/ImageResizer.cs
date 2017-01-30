using ImageMagick;
using System;
using System.IO;
using Common;

namespace FileManagement
{
    public class ImageResizer:IImageResizer
    {
        
        //private ApplicationLocationSettings _applicationLocationSettings;

        //public Uri ResizeImageByLengthOfLongestSide(Uri imageToResizeUri)
        //{
        //    var fileName = Path.GetFileName(imageToResizeUri.LocalPath);

        //    var magicImage = new MagickImage(Path.Combine(_fileStorageSettings.ImageStorageFolder, fileName));

        //    var size = magicImage.Height >= magicImage.Width
        //        ? new MagickGeometry(_lengthOfLongestSideOfResized, 0)
        //        : new MagickGeometry(0, _lengthOfLongestSideOfResized);

        //    size.IgnoreAspectRatio = false;

        //    magicImage.Resize(size);

        //    var newName = GenerateRandomFileName(magicImage.FileName);
        //    var pathOfNewImage = Path.Combine(_fileStorageSettings.ImageStorageFolder, newName);
        //    magicImage.Write(pathOfNewImage);

        //    return new Uri($"{_applicationLocationSettings.BackendAdress}/image/" + newName);
        //}

        private string GenerateRandomFileName(string fileName)
        {
            var randomFileName = Path.GetRandomFileName();
            return Path.ChangeExtension(randomFileName, Path.GetExtension(fileName).TrimStart('.'));
        }

        //private readonly int _lengthOfLongestSideOfResized;
        //private readonly FileStorage _fileStorageSettings;

        //public ImageResizer(int lengthOfLongestSideOfResized, FileStorage fileStorageSettings, ApplicationLocationSettings applicationLocationSettings)
        //{
        //    _lengthOfLongestSideOfResized = lengthOfLongestSideOfResized;
        //    this._fileStorageSettings = fileStorageSettings;
        //    _applicationLocationSettings = applicationLocationSettings;
        //}
    }
}

