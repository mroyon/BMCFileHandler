using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core.Frame.Helpers
{
    public class TinyUrlHelper
    {
        public static string GetShortCodeFromTinyUrl(string tinyUrl)
        {
            try
            {
                Uri uri = new Uri(tinyUrl);
                string path = uri.AbsolutePath;

                string[] pathSegments = path.Trim('/').Split('/');
                string shortcode = pathSegments[pathSegments.Length - 1];

                return shortcode;
            }
            catch (UriFormatException)
            {
                return null;
            }
        }
    }
}
