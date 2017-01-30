namespace Frontend.Models
{
    public class ImageModel
    {
        public ImageModel(string bigPhotoName)
        {
            BigPhotoName = bigPhotoName;
            //SmallPhotoName = smallPhotoName;
        }

        public string BigPhotoName { get; private set; }
        //public string SmallPhotoName { get; private set; }
    }
}