using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _trantinyurldata : _Common
    {
         private static IResourceProvider resourceProvider_trantinyurldata = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_trantinyurldata.xml"));//DbResourceProvider(); //  
         
         
        public static string trantinyurldataList
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("trantinyurldataList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string trantinyurldataCreate
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("trantinyurldataCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string trantinyurldataUpdate
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("trantinyurldataUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string trantinyurldataDetails
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("trantinyurldataDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string tinyurl
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("tinyurl", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string tinyurlRequired
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("tinyurlRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string tinyurlcode
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("tinyurlcode", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string tinyurlcodeRequired
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("tinyurlcodeRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string actualurl
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("actualurl", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string serviceid
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("serviceid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string serviceidRequired
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("serviceidRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string isactive
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("isactive", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string otisonetime
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("otisonetime", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string otisused
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("otisused", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string otusedtime
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("otusedtime", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string otusedfromip
        {
            get
            {
                return resourceProvider_trantinyurldata.GetResource("otusedfromip", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
