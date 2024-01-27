using System;
using System.Globalization;
using System.IO;
using CLL.Abstract;

namespace CLL.LLClasses.Models
{
    
    public  class _trantinyurlaccessinfo : _Common
    {
         private static IResourceProvider resourceProvider_trantinyurlaccessinfo = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LanguagesFiles/_trantinyurlaccessinfo.xml"));//DbResourceProvider(); //  
         
         
        public static string trantinyurlaccessinfoList
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("trantinyurlaccessinfoList", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string trantinyurlaccessinfoCreate
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("trantinyurlaccessinfoCreate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string trantinyurlaccessinfoUpdate
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("trantinyurlaccessinfoUpdate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string trantinyurlaccessinfoDetails
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("trantinyurlaccessinfoDetails", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         
     
         public static string tinyurlid
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("tinyurlid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string tinyurlidRequired
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("tinyurlidRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string otisused
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("otisused", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string otusedtime
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("otusedtime", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
         public static string otusedfromip
        {
            get
            {
                return resourceProvider_trantinyurlaccessinfo.GetResource("otusedfromip", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
      
    }
}
