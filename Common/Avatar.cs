using System;

namespace Common
{
    public class Avatar
    {
        public Avatar()
        {
            
        }

        public Avatar(Uri bigImage, Uri smallImage)
        {
            BigImage = bigImage;
            SmallImage = smallImage;
        }

        public virtual Uri BigImage { get; set; }
        public virtual Uri SmallImage { get; set; }
    }
}
