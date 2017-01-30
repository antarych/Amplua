using System.Collections.Specialized;
using FileManagement;

namespace Frontend.App_Data
{
    public class SettingsReader
    {
        public static FileStorage ReadFileStorage(NameValueCollection settings)
        {
            return new FileStorage(               
                settings["FileStorage.ImageFolder"],
                settings["FileStorage.ImageExtensions"].Split(','));
        }
    }
}