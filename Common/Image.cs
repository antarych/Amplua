using System;

namespace Common
{
    public class Image
    {
        public Image()
        {
            
        }

        public Image(Uri bigImage)
        {
            BigImage = bigImage;
            //SmallImage = smallImage;
        }

        public virtual Uri BigImage { get; set; }
        //public virtual Uri SmallImage { get; set; }
    }
}
